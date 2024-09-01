using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorComponent.Models;
using BlazorComponent.Repositories;

namespace BlazorComponent.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("Todos os campos são obrigatórios");
            }
            await _userRepository.AddAsync(user);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task RemoveUserAsync(int id)
        {
            await _userRepository.RemoveAsync(id);
        }
    }
}