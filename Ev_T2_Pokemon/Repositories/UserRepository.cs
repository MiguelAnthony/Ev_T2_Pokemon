using Ev_T2_Pokemon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T2_Pokemon.Repositories
{
    public interface IUserRepository
    {
        public Reg_Usuario FindUser(string username, string password);
    }

    public class UserRepository : IUserRepository
    {
        private readonly Ev_T2_Pokemon_Context context;

        public UserRepository(Ev_T2_Pokemon_Context context)
        {
            this.context = context;
        }

        public Reg_Usuario FindUser(string username, string password)
        {
            return context.Reg_Usuario
               .Where(o => o.Usuario == username && o.Contraseña == password)
               .FirstOrDefault();
        }
    }

}
