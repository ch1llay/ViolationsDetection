using AutoMapper;
using Common.Extensions;
using DataAccess.Entities.Users;
using DataAccess.Repositories.Users.Interfaces;
using Services.Files.Interfaces;
using Services.Models.Users;

namespace Services.Users;

public class UserService(
    IMapper mapper,
    IUserRepository userRepository) : IUserService
{
    public async Task<User> Add(User model)
    {
        return (await userRepository.Add(model.Map<DbUser>(mapper))).Map<User>(mapper);
    }

    public async Task<User> Update(User model)
    {
        return (await userRepository.Update(model.Map<DbUser>(mapper))).Map<User>(mapper);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await userRepository.Delete(id);
    }

    public async Task<List<User>> GetByIds(IEnumerable<Guid> ids)
    {
        var res = (await userRepository.GetByIds(ids)).MapToList<User>(mapper);

        return res;
    }

    public async Task<User> GetById(Guid id)
    {
        var res = (await userRepository.GetByIds(new List<Guid> {id})).Map<User>(mapper);

        return res;
    }
}