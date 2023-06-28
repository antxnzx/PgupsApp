using PgupsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgupsApp.Services
{
    public class LoginService : ILoginRepository
    {
        Task<UserInfo> ILoginRepository.Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
