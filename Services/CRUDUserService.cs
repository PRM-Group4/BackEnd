using AutoMapper;
using BOs.Models;
using Repos.Interface;
using Services.IServices;
using Services.Modal.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
 
        public class CRUDUserService : ICRUDUserService
        {
            private readonly IUserRepos _userRepos;
            private readonly IMapper _mapper;

            public CRUDUserService(IUserRepos userRepos, IMapper mapper)
            {
                _userRepos = userRepos;
                _mapper = mapper;
            }

            public async Task<UserRequest> Create(UserRequest data)
            {
                try
                {
                    var map = _mapper.Map<User>(data);
                    var dataCreate = await _userRepos.Create(map);
                    var resutl = _mapper.Map<UserRequest>(dataCreate);
                    return resutl;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task<bool> Delete(int id)
            {
                try
                {
                    var data = await _userRepos.GetById(id);
                    if (data == null)
                    {
                        throw new Exception($"Data {id} does not exist");
                    }

                    await _userRepos.Delete(data);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task<List<UserRequest>> GetAll()
            {
                try
                {

                    var data = await _userRepos.GetAll();
                    var map = _mapper.Map<List<UserRequest>>(data);
                    return map;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task<User> GetById(int id)
            {
                var data = await _userRepos.GetById(id);
                return data;
            }


            public async Task<bool> Update(int id, UserRequest data)
            {
                try
                {
                    var cate = await _userRepos.GetById(id);
                    if (data == null)
                    {
                        return false;
                    }

                    _mapper.Map(data, cate);
                    await _userRepos.Update(cate);
                    return true;
                }
                catch (Exception ex)
                {
                    // Log the exception
                    Console.WriteLine($"Fail to update info {ex.Message}");
                    return false;
                }
            }

        }
    }

