using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomePageDetails.Service
{
    public interface IFunction<T>
    {
        void Add(T t);
        T Get(int id);
    }
}
