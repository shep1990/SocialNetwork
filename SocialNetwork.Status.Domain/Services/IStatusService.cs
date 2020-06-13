using SocialNetwork.Library;
using SocialNetwork.Status.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Status.Domain.Services
{
    public interface IStatusService
    {
        Task<StatusEntity> SaveStatus(StatusModel model);
        Task<List<StatusModel>> GetStatusList(Guid userId);
    }
}
