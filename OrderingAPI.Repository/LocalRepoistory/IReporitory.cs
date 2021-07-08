using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.Repository.LocalRepoistory
{
    public interface IRepository<T> 
    {

        T getObject(int id);
        T addObject(T obj);
        List<T> getObjects(int fkid);
        void saveChanges();
        List<T> getAllObjects();

    }
}
