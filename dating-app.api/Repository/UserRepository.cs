using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dating_app.api.Data;
using dating_app.api.Data.Entity;

namespace dating_app.api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;
        public UserRepository(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public void createUser(UserEntity user)
        {
            dataContext.users.Add(user);
        }

        public void deleteUser(UserEntity user)
        {
            dataContext.users.Remove(user);
        }

        public UserEntity getUserById(int id)
        {
            return dataContext.users.FirstOrDefault(u => u.userId == id);
        }

        public UserEntity getUserByUsername(string username)
        {
            return dataContext.users.FirstOrDefault(u => u.username == username);
        }

        public List<UserEntity> getUsers()
        {
            return dataContext.users.ToList();
        }

        public bool isSaveChanges()
        {
            return dataContext.SaveChanges() > 0;
        }

        public void updateUser(UserEntity user)
        {
            dataContext.users.Update(user);
        }
    }
}