using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorComponent.Models;

namespace BlazorComponent.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public Task AddAsync(User entity)
        {
            entity.Id = _nextId++;
            _users.Add(entity);
            return Task.CompletedTask;
        }

        public Task<List<User>> GetAllAsync()
        {
            return Task.FromResult(_users.ToList());
        }

        public Task<User?> GetByIdAsync(int id)
        {
            return Task.FromResult(_users.FirstOrDefault(x => x.Id == id));
        }

        public Task RemoveAsync(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return Task.CompletedTask;
        }

        public Task UpdateAsync(User user)
        {
            var existingUser = _users.FirstOrDefault(x => x.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Update(user.Name, user.Email);
            }
            return Task.CompletedTask;
        }
    }
}