using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Account
    {
        public int Id { get; set; }
        public string Amount { get; set; }
    }

    public class AccountRepository
    {
        private readonly UnitOfWork _uow;
        public AccountRepository(UnitOfWork uow)
        {
            _uow = uow;
        }
        private void PersistAdd(Account entity)
        {
            //Persist to DB
        }
        private void PersistUpdate(Account entity)
        {
            //Persist to DB
        }
        private void PersistRemove(Account entity)
        {
            //Persist to DB
        }

        public void Add(Account entity)
        {
            _uow.RegisterAdd(entity, this);
        }
        public void Save(Account entity)
        {
            _uow.RegisterChange(entity, this);
        }
        public void Delete(Account entity)
        {
            _uow.RegisterDelete(entity, this);
        }
    }

    public class UnitOfWork
    {
        private readonly IDictionary<Account, AccountRepository> _addedEntities;
        private readonly IDictionary<Account, AccountRepository> _changedEntities;
        private readonly IDictionary<Account, AccountRepository> _deletedEntities;

        public UnitOfWork()
        {
            _addedEntities = new Dictionary<Account, AccountRepository>();
            _changedEntities = new Dictionary<Account, AccountRepository>();
            _deletedEntities = new Dictionary<Account, AccountRepository>();
        }

        public void RegisterAdd(Account entity, AccountRepository repository)
        {
            _addedEntities.Add(entity, repository);
        }

        public void RegisterChange(Account entity, AccountRepository repository)
        {
            _changedEntities.Add(entity, repository);
        }


        public void RegisterDelete(Account entity, AccountRepository repository)
        {
            _deletedEntities.Add(entity, repository);
        }

        public void Commit()
        {
            _addedEntities.Keys.ToList().ForEach(entity => _addedEntities[entity].Add(entity));
            _changedEntities.Keys.ToList().ForEach(entity => _changedEntities[entity].Add(entity));
            _deletedEntities.Keys.ToList().ForEach(entity => _deletedEntities[entity].Add(entity));
        }

    }

    public class UowTest
    {
        public void Test()
        {
            UnitOfWork uow = new UnitOfWork();
            AccountRepository account1 = new AccountRepository(uow);
            AccountRepository account2 = new AccountRepository(uow);
            var account = new Account();
            account1.Add(account);
            account2.Delete(account);
            uow.Commit();

        }
    }
}
