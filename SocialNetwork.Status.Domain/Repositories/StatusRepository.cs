using Microsoft.EntityFrameworkCore;
using SocialNetwork.Status.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Status.Domain.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatusRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StatusEntity> AddAsync(StatusEntity entity)
        {
            _unitOfWork.Context.Set<StatusEntity>().Add(entity);

            await _unitOfWork.CommitAsync();

            return entity;
        }


        public async Task<List<StatusEntity>> GetAsync(Guid userId)
        {
            var statusList = await _unitOfWork.Context.Set<StatusEntity>().Where(x => x.UserId == userId).ToListAsync();

            return statusList;
        }
    }
}
