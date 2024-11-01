using System.Linq.Expressions;
using AutoMapper;
using Imagine.Business.Services.EmailService;
using Imagine.DataAccess.Entities;
using Imagine.DataAccess.Entities.Dtos;
using Imagine.DataAccess.Interfaces;

namespace Imagine.Business.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IMapper mapper, IEmailService emailService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
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

        public IEnumerable<User> GetUsers(Expression<Func<User, bool>> filter)
        {
            return _userRepository.GetUsers(filter);
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

        public User GetUserByEmail(string? email)
        {
            return _userRepository.Get(u => u.Email == email);
        }

        public async Task<(bool success, string errorMessage, string confirmUrl)> RegisterUserAsync(UserDtoForRegister user)
        {
            User checkExistingUser = GetUser(u => u.Email == user.Email);
            if (checkExistingUser != null)
            {
                return (false, "An account with this email alread   y exists.", null);
            }
            User newUser = _mapper.Map<User>(user);
            AddUser(newUser);
            var confirmUrl = GetConfirmEmail(newUser.Email);
            return (true, "A confirmation email has been sent. Please confirm your email address before logging in.",confirmUrl);

        }

        public string GetConfirmEmail(string email)
        {
            return $"https://smart-tops-pelican.ngrok-free.app/User/ConfirmEmail?email={email}";
        }
    }
}
