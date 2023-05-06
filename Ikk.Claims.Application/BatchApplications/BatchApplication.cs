using Ikk.Claims.Application.Contracts.BatchContract;
using Ikk.Claims.Application.Contracts.TypeCarContract;
using Ikk.Claims.Common.Entities;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Common.Pagination;
using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Domain.Enities.CarInBaches;
using Ikk.Claims.Domain.Enities.TypeCars;
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
        private readonly ITypeCarRepository _typeCarRepository;
        private readonly ICarInBatchRepository _carInBatchRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BatchApplication(IBatchRepository batchRepository, IUnitOfWork unitOfWork, ITypeCarRepository typeCarRepository, ICarInBatchRepository carInBatchRepository)
        {
            _batchRepository = batchRepository;
            _unitOfWork = unitOfWork;
            _typeCarRepository = typeCarRepository;
            _carInBatchRepository = carInBatchRepository;
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
            List<TypeCar> typeCar = new List<TypeCar>();
            foreach (var type in command.CarInBatchs)
            {
                TypeCar r = _typeCarRepository.Get(type.Id);
                typeCar.Add(r);
            }
            var batch = new Batch(command.Name, command.Status);
            var BatchInTypeCar = new List<CarInBatch>();
            foreach (var type in typeCar)
            {
                BatchInTypeCar.Add(new CarInBatch(type.Id, type, batch.Id, batch));
            }
            batch.CarInBatchs = BatchInTypeCar;
            _batchRepository.Create(batch);
            _unitOfWork.CommitTran();

        }

        public void Edit(EditBatchViewModel command)
        {

            _unitOfWork.BeginTran();
            var batch = _batchRepository.Get(command.Id);
            List<TypeCar> typeCar = new List<TypeCar>();
            foreach (var type in command.CarInBatchs)
            {
                TypeCar r = _typeCarRepository.Get(type.Id);
                typeCar.Add(r);
            }
            var BatchInTypeCar = new List<CarInBatch>();
            batch.EditBatch(command.Name,command.Status, 1);
           
                var roleinUserInRole = _carInBatchRepository.GetWithBatch(command.Id);
                if (roleinUserInRole != null)
                    _carInBatchRepository.RemoveAll(batch.Id, roleinUserInRole.CarId);
           
            foreach (var type in typeCar)
            {
                BatchInTypeCar.Add(new CarInBatch(type.Id, type, type.Id, batch));
            }

            batch.CarInBatchs = BatchInTypeCar;

            _unitOfWork.CommitTran();

        }

        public GetBatchViewModel Get(long id)
        {
            var batch = _batchRepository.Get(id);
            List<GetIdTypeCarViewModel> typecars = new List<GetIdTypeCarViewModel>();
            if (batch.CarInBatchs == null)
            {
                batch = null;
            }
            else
            {
                foreach (var type in batch.CarInBatchs)
                {
                    TypeCar r = _typeCarRepository.Get(type.Id);
                    typecars.Add(new GetIdTypeCarViewModel { Id = type.Id });
                }
            }

            return new GetBatchViewModel
            {
                Id = batch.Id,
                Name = batch.Name,
                Status = batch.Status,
                CarInBatchs= typecars,
            };


            
        }

        public ResultGetBatches List(RequestDto request)
        {
            int row = 0;
            var allbatches = _batchRepository.GetAll().Where(x=>x.Name.Contains(request.SearchKey));
            var batches = allbatches.ToPaged(request.Page, request.PageSize, out row).OrderBy(x => x.Id);
            var result = new List<GetBatchViewModel>();
            foreach (var batch in batches)
            {
                result.Add(new GetBatchViewModel
                {
                    Id = batch.Id,
                    Name = batch.Name,
                    Status = batch.Status
                });
            }
            return new ResultGetBatches
            {
                RowCount = allbatches.Count(),
                batches = result
            };
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
