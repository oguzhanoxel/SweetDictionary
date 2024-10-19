using Core.Repository;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Persistence.Repositories.Abstracts;

public interface IUserRepository : IRepository<User, Guid>
{

}
