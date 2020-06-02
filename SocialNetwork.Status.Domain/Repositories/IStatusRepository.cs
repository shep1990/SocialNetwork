using SocialNetwork.Status.Domain.Data;
using System.Threading.Tasks;

namespace SocialNetwork.Status.Domain.Repositories
{
    public interface IStatusRepository
    {
        Task<StatusEntity> AddAsync(StatusEntity entity);
    }
}
