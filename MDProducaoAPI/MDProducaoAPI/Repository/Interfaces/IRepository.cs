using System;
using System.Linq;
using System.Linq.Expressions;
using MDProducaoAPI.Repository;

namespace MDProducaoAPI.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
    }
}