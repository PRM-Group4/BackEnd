using Services.Modal.Request;
using Services.Modal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IAuthServices
    {
        Task<BaseResponseForLogin<LoginResponse>> AuthenticateAsync(string username, string password);

        Task<BaseResponse<TokenModel>> RegisterAsync(RegisterDTO register);
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
