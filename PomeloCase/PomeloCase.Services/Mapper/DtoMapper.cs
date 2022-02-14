using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Model.Dtos.Category;
using PomeloCase.Core.Model.Dtos.Post;
using PomeloCase.Core.Models.Dtos.Post;
using PomeloCase.Core.Models.Dtos.User;


namespace PomeloCase.Services.Mapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<PostPageDto, Post>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Post, PopularPostDto>().ReverseMap();
        }
    }
}
