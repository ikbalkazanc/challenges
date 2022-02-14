using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PomeloCase.Core.Model.Base;
using PomeloCase.Core.Model.Dtos.Post;
using PomeloCase.Core.Model.Responses.Post;
using PomeloCase.Core.Model.Responses.Posts;
using PomeloCase.Core.Models.Dtos.Post;
using PomeloCase.Core.Models.Requests.Post;
using PomeloCase.Core.Models.Responses;
using PomeloCase.Core.Models.Responses.Posts;
using PomeloCase.Services.Services.PostService;


namespace PomeloCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : PomeloController
    {
        private IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

     
        [HttpGet]
        public async Task<BaseResponse<PostDto>> Get([FromQuery]Guid id)
        {
            return await _postService.Get(id);
        }

        [HttpPost("pages")]
        public async Task<BaseResponse<GetPostPageResponse>> Get(GetPostPageRequest request)
        {
            return await _postService.GetPage(request);
        }

        [HttpPost]
        public async Task<BaseResponse<EmptyResponse>> Create(UpdateOrCreatePostDto request)
        {
            return await _postService.Create(request, AccessToken);
        }

        [HttpPut]
        public async Task Put([FromBody] UpdateOrCreatePostDto oldPost)
        {
            await _postService.Update(oldPost, AccessToken);
        }

       
        [HttpDelete]
        public async Task<BaseResponse<EmptyResponse>> Delete([FromQuery]Guid id)
        {
            return await _postService.Remove(id, AccessToken);
        }

        [HttpGet("mostpopular")]
        public async Task<BaseResponse<GetPopularPostResponse>> MostPopular()
        {
            return await _postService.MostPopularPosts();
        }
    }
}