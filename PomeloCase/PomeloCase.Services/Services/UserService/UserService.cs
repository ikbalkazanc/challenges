using System;
using System.Linq;
using System.Threading.Tasks;
using PomeloCase.Core.Entites;
using PomeloCase.Core.Models.Dtos.User;
using PomeloCase.Data;
using PomeloCase.Services.Mapper;

namespace PomeloCase.Services.Services.UserService
{
    public class UserService : IUserService
    {
        private DataRepository _repo;

        public UserService(DataRepository repo)
        {
            _repo = repo;
        }


        public async Task<User> GetUserByMail(string mail)
        {
            if (mail == null) throw new ArgumentNullException();

            var user = (await _repo.UserRepository.Value.Where(x => x.Email == mail)).FirstOrDefault();

            return user;
        }

        public async Task<bool> CheckPasswordAsync(LoginDto model)
        {
            var user = (await _repo.UserRepository.Value.Where(x => x.Email == model.Email)).FirstOrDefault();
            if (user.Password == model.Password)
            {
                return true;
            }

            return false;
        }
    }
}