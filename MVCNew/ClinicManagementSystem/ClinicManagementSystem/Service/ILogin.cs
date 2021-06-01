using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystem.Service
{
    interface ILogin<T>
    {
        IEnumerable<T> GetAll();
        void Add(T t);
        int UserLogin(T t);

    }
}
