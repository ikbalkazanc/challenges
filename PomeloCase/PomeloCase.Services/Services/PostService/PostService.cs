using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Constant;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Model.Base;
using PomeloCase.Core.Model.Dtos.Category;
using PomeloCase.Core.Model.Dtos.Post;
using PomeloCase.Core.Model.Responses.Post;
using PomeloCase.Core.Model.Responses.Posts;
using PomeloCase.Core.Models.Dtos.Post;
using PomeloCase.Core.Models.Requests.Post;
using PomeloCase.Core.Models.Responses;
using PomeloCase.Core.Models.Responses.Posts;
using PomeloCase.Data;
using PomeloCase.Services.Mapper;

namespace PomeloCase.Services.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly DataRepository _repo;

        public PostService(DataRepository repo)
        {
            _repo = repo;
        }

        public async Task<BaseResponse<PostDto>> Get(Guid id)
        {
            var response = new BaseResponse<PostDto>();

            var post = (await _repo.PostRepository.Value.Where(x => x.Id == id && !x.IsDeleted)).FirstOrDefault();
            if (post == null)
                return response.AddError(new ErrorDto("Post Not Found", "Post Nt Found in Database"));

            var categoryIds = (await _repo.PostCategoriesRepository.Value.Where(x => post.Id == x.PostId)).Select(x => x.CategoryId);
            var author = (await _repo.UserRepository.Value.Where(x => x.Id == post.UserId)).FirstOrDefault(); ;
            var postViews = (await _repo.PostViewsRepository.Value.View(id));


            List<Category> categories = default;
            if (categoryIds != null)
                categories =
                    (await _repo.CategoryRepository.Value.Where(x => categoryIds.Contains(x.Id) & !x.IsDeleted))
                    .ToList();

            var postdto = ObjectMapper.Mapper.Map<PostDto>(post);

            postdto.AuthorMail = author is not null ? author.Email : "";
            postdto.Categories = categories is not null ? ObjectMapper.Mapper.Map<List<CategoryDto>>(categories) : null;
            postdto.PostViews = postViews.ViewsCount;

            response.Data = postdto;

            return response;
        }

        public async Task<BaseResponse<GetPostPageResponse>> GetPage(GetPostPageRequest request)
        {
            var response = new BaseResponse<GetPostPageResponse>();
            Category category = default;
            List<Post> posts = default;
            if (!string.IsNullOrEmpty(request.CategoryName))
            {
                category =
                    (await _repo.CategoryRepository.Value.Where(x => !x.IsDeleted && x.Name == request.CategoryName))
                    .FirstOrDefault();

                if (category == null)
                {
                    response.AddError(new ErrorDto("Post Not Found", "Post Nt Found in Database"));
                    response.StatusCode = HttpStatusCode.BadRequest;
                    return response;
                }

                posts = await _repo.PostRepository.Value.Filter(request.PageNumber, request.PageSize, category.Id);
            }
            else
            {
                posts = await _repo.PostRepository.Value.Filter(request.PageNumber, request.PageSize);
            }


            response.Data = new GetPostPageResponse();

            response.Data.Posts = ObjectMapper.Mapper.Map<List<PostPageDto>>(posts);
            response.Data.PageSize = request.PageSize;
            response.Data.Page = request.PageNumber;
            response.Data.Category = ObjectMapper.Mapper.Map<CategoryDto>(category);

            return response;
        }

        public async Task<BaseResponse<PostPageDto>> Update(UpdateOrCreatePostDto newpost, string accessToken)
        {
            var response = new BaseResponse<PostPageDto>();
            response.Data = default;

            var user = Constant.SystemUserId;

            var oldpost = (await _repo.PostRepository.Value.Where(x => !x.IsDeleted && x.Id == newpost.Id))
                .FirstOrDefault();
            if (oldpost is null)
            {
                response.AddError(new ErrorDto("Post Not Found", "Post Not Found in Database"));
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            oldpost.Body = newpost.Body;
            oldpost.Title = newpost.Title;
            oldpost.UpdatedUserId = user;
            oldpost.UptadeDate = DateTime.Now;

            await _repo.PostRepository.Value.Update(oldpost);

            return response;
        }

        public async Task<BaseResponse<EmptyResponse>> Remove(Guid id, string accessToken)
        {
            var response = new BaseResponse<EmptyResponse>();

            var user = Constant.SystemUserId;

            var post = (await _repo.PostRepository.Value.Where(x => !x.IsDeleted && x.Id == id)).FirstOrDefault();
            if (post is null)
            {
                response.AddError(new ErrorDto("Post Not Found", "Post Not Found in Database"));
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            post.DeleteDate = DateTime.Now;
            post.DeletedUserId = user;

            await _repo.PostRepository.Value.Remove(post);


            return response;
        }

        public async Task<BaseResponse<EmptyResponse>> Create(UpdateOrCreatePostDto post, string accessToken)
        {
            var response = new BaseResponse<EmptyResponse>();


            var newpost = new Post()
            {
                UserId = post.UserId,
                Title = post.Title,
                Body = post.Body,
                CreatedDate = DateTime.Now,
                CreatedUserId = post.UserId
            };

            var createdPost = await _repo.PostRepository.Value.AddAsync(newpost);
            var categories = (await _repo.CategoryRepository.Value.Where(x => post.CategoryIds.Contains(x.Id)))
                .ToList();
 

            foreach (var category in categories)
            {
                await _repo.PostCategoriesRepository.Value.AddAsync(new PostsCategories()
                    { Id = Guid.NewGuid(),PostId = createdPost.Id, CategoryId = category.Id });
            }

  

            return response;
        }


        public async Task<BaseResponse<GetPopularPostResponse>> MostPopularPosts()
        {
            var response = new BaseResponse<GetPopularPostResponse>();
            response.Data = new GetPopularPostResponse();


            var postDic = await _repo.PostRepository.Value.GetMostPopularPost(5);

            foreach (var line in postDic)
            {
                var post = ObjectMapper.Mapper.Map<PopularPostDto>(line.Key);
                post.Views = line.Value;
                response.Data.Posts.Add(post);
            }

            response.Data.Posts.OrderByDescending(x => x.Views);

            return response;
        }
    }
}