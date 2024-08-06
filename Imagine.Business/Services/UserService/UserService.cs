using AutoMapper;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Entities.Dtos;
using Imagine.DataAccess.Interfaces;
using System.Linq.Expressions;

namespace Imagine.Business.Services.UserService.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public User CheckCredentials(User user)
        {
            User confirmCredentials = _userRepository.Get(u => u.Email == user.Email && u.Password == user.Password);
            return confirmCredentials;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(Expression<Func<User, bool>> filter)
        {
            return _userRepository.Get(filter);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
        public UserDtoForUpdate GetOneUserToUpdate(string email)
        {
            var user = _userRepository.Get(u => u.Email == email);
            return _mapper.Map<UserDtoForUpdate>(user);
        }

        public void RemoveUser(User user)
        {
            _userRepository.Remove(user);
        }
    }
}
