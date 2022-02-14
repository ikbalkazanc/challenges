using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomeloCase.Core.Model.Base;
using PomeloCase.Core.Model.Dtos.Post;
using PomeloCase.Core.Model.Responses.Post;
using PomeloCase.Core.Model.Responses.Posts;
using PomeloCase.Core.Models.Dtos.Post;
using PomeloCase.Core.Models.Requests.Post;
using PomeloCase.Core.Models.Responses;
using PomeloCase.Core.Models.Responses.Posts;

namespace PomeloCase.Services.Services.PostService
{
    public interface IPostService
    {
        Task<BaseResponse<PostDto>> Get(Guid id);
        Task<BaseResponse<GetPostPageResponse>> GetPage(GetPostPageRequest request);
        Task<BaseResponse<PostPageDto>> Update(UpdateOrCreatePostDto id, string accessToken);
        Task<BaseResponse<EmptyResponse>> Remove(Guid id, string accessToken);
        Task<BaseResponse<EmptyResponse>> Create(UpdateOrCreatePostDto post, string accessToken);
        Task<BaseResponse<GetPopularPostResponse>> MostPopularPosts();
    }
}
