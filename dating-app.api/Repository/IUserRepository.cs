using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dating_app.api.Data.Entity;

namespace dating_app.api.Repository
{
    public interface IUserRepository
    {
        List<UserEntity> getUsers();
        UserEntity getUserById(int id);
        UserEntity getUserByUsername(string username);
        void createUser(UserEntity user);
        void updateUser(UserEntity user);
        void deleteUser(UserEntity user);
        bool isSaveChanges();
    }
}