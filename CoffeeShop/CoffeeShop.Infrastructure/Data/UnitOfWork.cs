using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Abstract.Repository;
using CoffeeShop.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDBContext _appDBContext;
        private IUserRepository _userRepository;
        public UnitOfWork(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_appDBContext);
                }
                return _userRepository;
            }
            set
            {
                _userRepository = value;
            }
        }


    }
}
