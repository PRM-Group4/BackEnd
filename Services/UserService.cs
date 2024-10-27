using AutoMapper;
using BOs.Models;
using Microsoft.EntityFrameworkCore;
using Repos.Interface;
using Repos.UnitOfWork;
using Services.IServices;
using Services.Modal.Request;
using Services.Modal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Services.UserService;

namespace Services
{
    
        public class UserService : IUserService
        {
            private readonly IUnitOfWork _unitOfWork;

            public UserService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public IEnumerable<User> GetUsers()
            {
                return _unitOfWork.Repository<User>().GetAll();

            }

            public async Task<User> GetUserByIdAsync(int id)
            {
                return await _unitOfWork.Repository<User>().GetById(id);
            }

            public async Task CreateUserAsync(User User)
            {
                await _unitOfWork.Repository<User>().InsertAsync(User);
                await _unitOfWork.CommitAsync();
            }

            public async Task UpdateUserAsync(User User)
            {
                await _unitOfWork.Repository<User>().Update(User, User.UserId);
                await _unitOfWork.CommitAsync();
            }

            public async Task DeleteUserAsync(int id)
            {
                var User = await _unitOfWork.Repository<User>().GetById(id);
                if (User != null)
                {
                    _unitOfWork.Repository<User>().Delete(User);
                    await _unitOfWork.CommitAsync();
                }
            }

            public async Task<bool> UserExistsAsync(int id)
            {
                var User = await _unitOfWork.Repository<User>().GetById(id);
                return User != null;
            }

            public async Task<User> GetUserByUsernameAsync(string username)
            {
                // Truy vấn người dùng từ cơ sở dữ liệu theo tên người dùng
                var user = await _unitOfWork.Repository<User>()
                    .GetAll()
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.UserName == username);

                return user;
            }





            public async Task<UserResponse> GetUserProfile(int id)
            {
                var User = await _unitOfWork.Repository<User>().GetById(id);

                if (User == null)
                {
                    throw new Exception($"User with ID {id} not found.");
                }

                var responseModel = new UserResponse
                {
                    UserId = User.UserId,
                    UserName = User.UserName,
                    RoleId = (int)User.RoleId,
                    Status = User.Status
                };

                return responseModel;
            }

        }
    }
