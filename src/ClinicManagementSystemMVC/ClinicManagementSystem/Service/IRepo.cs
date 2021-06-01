using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Service
{
    interface IRepo<T>
    {
        bool UserLogin(T t);
    }
}
