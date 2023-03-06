using Ikk.Claims.Application.Contracts.BatchContract;
using Ikk.Claims.Common.Entities;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Batchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.BatchApplication
{
    public class BatchApplication : IBatchApplication
    {
        private readonly IBatchRepository _batchRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BatchApplication(IBatchRepository batchRepository, IUnitOfWork unitOfWork)
        {
            _batchRepository = batchRepository;
            _unitOfWork = unitOfWork;
        }
        public void ChangeStatus(long id)
        {
            _unitOfWork.BeginTran();
            var role = _batchRepository.Get(id);
            role.ChangeStatus(!role.Status);
            _unitOfWork.CommitTran();
        }

        public void Create(RegisterBatchViewModel command)
        {
            _unitOfWork.BeginTran();
            var role = new Batch(command.Name, command.Status);
            _batchRepository.Create(role);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditBatchViewModel command)
        {
            _unitOfWork.BeginTran();
            var role = _batchRepository.Get(command.Id);
            role.EditBatch(command.Name, command.Status, 1);
            _unitOfWork.CommitTran();
        }

        public GetBatchViewModel Get(long id)
        {
            var batch = _batchRepository.Get(id);
            if (batch != null)
            {
                return new GetBatchViewModel
                {
                    Id = batch.Id,
                    Name = batch.Name,
                    Status = batch.Status
                };
            }
            return null;
        }

        public List<GetBatchViewModel> List(RequestDto request)
        {
            return _batchRepository.GetAll().Select(x => new GetBatchViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status
            }).ToList();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var role = _batchRepository.Get(id);
            role.Remove(1, DateTime.Now);
            _unitOfWork.CommitTran();
        }
    }
}
