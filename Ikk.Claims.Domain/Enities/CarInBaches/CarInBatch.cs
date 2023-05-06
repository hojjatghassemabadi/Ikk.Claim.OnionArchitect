using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Domain.Enities.TypeCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Domain.Enities.CarInBaches
{
    public class CarInBatch
    {
        public long Id { get; set; }
        public long TypeCarId { get; set; }
        public TypeCar Typecar { get; set; }
        public long BatchId { get; set; }
        public Batch Batch { get; set; }

        protected CarInBatch() { }
        public CarInBatch(long typeCarId, TypeCar typecar, long batchId, Batch batch)
        {
           
            TypeCarId = typeCarId;
            Typecar = typecar;
            BatchId = batchId;
            Batch = batch;
        }
    }

   
}
