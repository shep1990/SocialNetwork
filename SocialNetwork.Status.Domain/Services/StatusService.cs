using SocialNetwork.Library;
using SocialNetwork.Status.Domain.Data;
using SocialNetwork.Status.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Status.Domain.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<StatusEntity> SaveStatus(StatusModel model)
        {
            var entity = new StatusEntity()
            {
                Status = model.Status,
                UserId = model.UserId,
                Name = model.Name
            };

            return await _statusRepository.AddAsync(entity);
        }

        public async Task<List<StatusModel>> GetStatusList(Guid userId)
        {
            var statusList = await _statusRepository.GetAsync(userId);

            var statusModel = new List<StatusModel>();

            foreach (var status in statusList)
            {
                statusModel.Add(new StatusModel
                {
                    UserId = status.UserId,
                    Status = status.Status,
                    Name = status.Name
                });
            }
            return statusModel;
        }
    }
}
