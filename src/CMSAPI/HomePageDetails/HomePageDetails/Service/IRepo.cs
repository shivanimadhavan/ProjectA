using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomePageDetails.Service
{
    public interface IRepo<T>
    {
        bool UserLogin(T t);
    }
}
