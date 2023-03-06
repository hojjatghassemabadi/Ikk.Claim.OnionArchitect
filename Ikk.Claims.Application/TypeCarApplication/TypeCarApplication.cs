using Ikk.Claims.Application.Contracts.TypeCarContract;
using Ikk.Claims.Common.Entities;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.TypeCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.TypeCarApplication
{
    public class TypeCarApplication : ITypeCarApplication
    {
        private readonly ITypeCarRepository _typeCarRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TypeCarApplication(ITypeCarRepository typeCarRepository, IUnitOfWork unitOfWork)
        {
            _typeCarRepository = typeCarRepository;
            _unitOfWork = unitOfWork;
        }
        public void ChangeStatus(long id)
        {
            _unitOfWork.BeginTran();
            var role = _typeCarRepository.Get(id);
            role.ChangeStatus(!role.Status);
            _unitOfWork.CommitTran();
        }

        public void Create(RegisterTypeCarViewModel command)
        {
            _unitOfWork.BeginTran();
            var role = new TypeCar(command.Name, command.Status);
            _typeCarRepository.Create(role);
            _unitOfWork.CommitTran();
        }

        public void Edit(EditTypeCarViewModel command)
        {
            _unitOfWork.BeginTran();
            var role = _typeCarRepository.Get(command.Id);
            role.EditTypeCar(command.Name, command.Status, 1);
            _unitOfWork.CommitTran();
        }

        public GetTypeCarViewModel Get(long id)
        {
            var typeCar = _typeCarRepository.Get(id);
            if (typeCar != null)
            {
                return new GetTypeCarViewModel
                {
                    Id = typeCar.Id,
                    Name = typeCar.Name,
                    Status = typeCar.Status
                };
            }
            return null;
        }

        public List<GetTypeCarViewModel> List(RequestDto request)
        {
            return _typeCarRepository.GetAll().Select(x => new GetTypeCarViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status
            }).ToList();
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var role = _typeCarRepository.Get(id);
            role.Remove(1, DateTime.Now);
            _unitOfWork.CommitTran();
        }
    }
}
