using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Meneger.Interface
{
    interface IUserManager
    {
        public void RemoveUser() { }
        public void AddUser() { }
        public void EditUser() { }
        public void GetUserByLogin() { }
    }
}

