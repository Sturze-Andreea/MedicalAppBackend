using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;
using MedicalAppBE.Authorization;
using MedicalAppBE.Entities;
using MedicalAppBE.Helpers;
using MedicalAppBE.Models.Users;

namespace MedicalAppBE.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Register(RegisterRequest model);
        User Update(int id, UpdateRequest model);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private DataContext _context;
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UserService(
            DataContext context,
            IJwtUtils jwtUtils,
            IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }
        // public string getRoleName(int id)
        // {
        //     var role = _context.Roles.Find(id);
        //     if (role == null) throw new KeyNotFoundException("Role not found");
        //     return role.Nume;
        // }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            var response = _mapper.Map<AuthenticateResponse>(user);
            response.Token = _jwtUtils.GenerateToken(user);
            // response.Role = getRoleName(user.RoleId);
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return getUser(id);
        }

        public void Register(RegisterRequest model)
        {
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");

            var user = _mapper.Map<User>(model);

            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Update(int id, UpdateRequest model)
        {
            var user = getUser(id);

            if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");

            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCryptNet.HashPassword(model.Password);

            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }


        private User getUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
    }
}