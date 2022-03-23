﻿namespace CoffeeShop.Core.Abstract.Repository
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        void RemoveUser(int id);
        void UpdateUser(User user);
    }
}
