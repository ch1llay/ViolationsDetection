using AutoMapper;
using Common.Extensions;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<User?> GetByLogin(string login)
    {
        return (await _userRepository.GetByLogin(login)).Map<User>(_mapper);
    }

    public async Task<List<User>> GetAll()
    {
        return (await _userRepository.GetAll()).MapToList<User>(_mapper);
    }

    public async Task<User> Add(User user)
    {
        user.Id = Guid.NewGuid();
        user.PasswordHash = user.Password;

        return (await _userRepository.Add(user.Map<DbUser>(_mapper))).Map<User>(_mapper);
    }

    public async Task<User?> GetById(Guid id)
    {
        return (await _userRepository.GetByIds(new[] {id})).FirstOrDefault()?.Map<User>(_mapper);
    }
}