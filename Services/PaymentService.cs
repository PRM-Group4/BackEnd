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
    public class PaymentService : IPaymentService
    {
      
            private readonly IPaymentRepos _repos;
            private readonly IMapper _mapper;

            public PaymentService(IPaymentRepos repos, IMapper mapper)
            {
                _repos = repos;
                _mapper = mapper;
            }

            public async Task<PaymentRequest> Create(PaymentRequest data)
            {
                try
                {
                    var map = _mapper.Map<Payment>(data);
                    var dataCreate = await _repos.Create(map);
                    var resutl = _mapper.Map<PaymentRequest>(dataCreate);
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
                    var data = await _repos.GetById(id);
                    if (data == null)
                    {
                        throw new Exception($"Data {id} does not exist");
                    }

                    await _repos.Delete(data);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task<List<PaymentRequest>> GetAll()
            {
                try
                {

                    var data = await _repos.GetAll();
                    var map = _mapper.Map<List<PaymentRequest>>(data);
                    return map;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public async Task<Payment> GetById(int id)
            {
                var data = await _repos.GetById(id);
                return data;
            }


            public async Task<bool> Update(int id, PaymentRequest data)
            {
                try
                {
                    var cate = await _repos.GetById(id);
                    if (data == null)
                    {
                        return false;
                    }

                    _mapper.Map(data, cate);
                    await _repos.Update(cate);
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
