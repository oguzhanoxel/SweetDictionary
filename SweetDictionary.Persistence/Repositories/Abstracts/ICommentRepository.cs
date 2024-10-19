using Core.Repository;
using SweetDictionary.Domain.Entities;

namespace SweetDictionary.Persistence.Repositories.Abstracts;

public interface ICommentRepository : IRepository<Comment, Guid>
{

}
