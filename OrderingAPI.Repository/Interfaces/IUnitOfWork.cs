using Microsoft.EntityFrameworkCore;
using OrderingAPI.Repository.LocalRepoistory;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.Repository.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> _repository { get; set; }

        void Commit();

        void BeginTransasction();

        void RollbackTransaction();
    }


}
