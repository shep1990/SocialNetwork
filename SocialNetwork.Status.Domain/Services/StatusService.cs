using SocialNetwork.Library;
using SocialNetwork.Status.Domain.Data;
using SocialNetwork.Status.Domain.Repositories;
using System;
using System.Collections.Generic;
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
                UserId = model.UserId
            };

            return await _statusRepository.AddAsync(entity);
        }
    }
}
