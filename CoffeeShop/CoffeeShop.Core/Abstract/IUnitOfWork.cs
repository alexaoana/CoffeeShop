using CoffeeShop.Core.Abstract.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Abstract
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }
    }
}
