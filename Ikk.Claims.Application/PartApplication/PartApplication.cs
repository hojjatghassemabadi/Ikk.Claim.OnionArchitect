using Ikk.Claims.Application.Contracts.PartContracts;
using Ikk.Claims.Common.Entities;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.PartApplication
{
    public class PartApplication : IPartApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPartRepository _partRepository;

        public PartApplication(IUnitOfWork unitOfWork, IPartRepository partRepository)
        {
            _unitOfWork = unitOfWork;
            _partRepository = partRepository;
        }

        public void ChangeStatus(long id)
        {
            _unitOfWork.BeginTran();
            var part = _partRepository.Get(id);
            part.ChangeStatus(!part.Status);
            _unitOfWork.CommitTran();
        }

        public void Create(RegisterPartViewModel command)
        {
            _unitOfWork.BeginTran();
            var role = new Part(command.PartName,command.PartNumber, command.Status);
            _partRepository.Create(role);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditPartViewModel command)
        {
            _unitOfWork.BeginTran();
            var role = _partRepository.Get(command.Id);
            role.EditPart(command.PartName, command.PartNumber, command.Status, 1);
            _unitOfWork.CommitTran();
        }

        public GetPartViewModel Get(long id)
        {
            var part = _partRepository.Get(id);
            if (part != null)
            {
                return new GetPartViewModel
                {
                    Id = part.Id,
                    PartName = part.PartName,
                    PartNumber=part.PartNumber,
                    Status = part.Status
                };
            }
            return null;
        }

        public List<GetPartViewModel> List(RequestDto request)
        {
            return _partRepository.GetAll().Select(x => new GetPartViewModel
            {
                Id = x.Id,
                PartName= x.PartName,
                PartNumber=x.PartNumber,
                Status = x.Status
            }).ToList();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var role = _partRepository.Get(id);
            role.Remove(1, DateTime.Now);
            _unitOfWork.CommitTran();
        }
    }
}
