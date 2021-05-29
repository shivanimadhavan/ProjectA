using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManagementSystemMVC.Service
{
    interface IFunction<T>
    {
        void Add(T t);
        T Get(int id);
    }
}
