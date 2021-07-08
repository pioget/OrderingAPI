using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OrderingAPI.Repository.EFObjects;
using OrderingAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderingAPI.Repository.LocalRepoistory
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        public DbContext Context { get; }
        public IRepository<T> _repository { get; set; }

        private IDbContextTransaction _transaction;

        public UnitOfWork(OrderDBContext _context, IRepository<T> repository)
        {
            Context = _context;
            _repository = repository;
        }

       

        public void Commit()
        {
            Context.SaveChanges();
            _transaction.Commit();
        }

      

        public void Dispose()
        {

            Context.Dispose();
        }

        public void BeginTransasction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            _transaction.Rollback();
        }
    }
}
