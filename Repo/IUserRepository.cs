using System;
using System.Collections.Generic;
using Domain;

namespace Repo
{
    public interface IUserRepository
    {
        void Create(User aUser);
        IEnumerable<User> GetAll();
        void Update(User aUser);
        void Delete(User aUser);


        //TEntity GetByName(string name);
        //IEnumerable<TEntity> GetAll();
        //void Add(TEntity entity);
        //void Update(TEntity entity);
        //void Delete(TEntity entity);
    }
}
