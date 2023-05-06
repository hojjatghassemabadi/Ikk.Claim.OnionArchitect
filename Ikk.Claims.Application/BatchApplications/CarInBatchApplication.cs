using Ikk.Claims.Application.Contracts.CarInBatchContracts;
using Ikk.Claims.Common.Entities;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Domain.Enities.Batchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.BatchApplications
{
    public class CarInBatchApplication : ICarInBatchApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICarInBatchRepository _carInBatchRepository;
        public CarInBatchApplication(IUnitOfWork unitOfWork, ICarInBatchRepository carInBatchRepository)
        {
            _unitOfWork = unitOfWork;
            _carInBatchRepository = carInBatchRepository;
        }

        public GetBatchWithCarViewModel Get(long batchId)
        {
            return _carInBatchRepository.GetWithBatch(batchId);
            
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }
    }
}
