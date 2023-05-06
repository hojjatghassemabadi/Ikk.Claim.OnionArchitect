using Ikk.Claims.Application.Contracts.ClaemContracts;
using Ikk.Claims.Common.Entities;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Common.Pagination;
using Ikk.Claims.Domain.Enities.Batchs;
using Ikk.Claims.Domain.Enities.Claems;
using Ikk.Claims.Domain.Enities.Claims;
using Ikk.Claims.Domain.Enities.Parts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikk.Claims.Application.CleamApplications
{
    public class ClaimApplication : IClaemApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaemRepository _claemRepository;
        private readonly IClaemPicsRepositoy _claemPicsRepository;
        private readonly IClaemInPartRepository _claemInPartRepository; 
        private readonly IPartRepository _partRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly ICarInBatchRepository _carInBatchRepository;
        private readonly string AppDirectory = Path.Combine("../IKK.CLaim.UI/src/assets/Claims");

        public ClaimApplication(IUnitOfWork unitOfWork, IClaemRepository claemRepository, IClaemPicsRepositoy claemPicsRepository,IClaemInPartRepository claemInPartRepository,IPartRepository partRepository,IBatchRepository batchRepository,ICarInBatchRepository carInBatchRepository)
        {
            _unitOfWork = unitOfWork;
            _claemRepository = claemRepository;
            _claemPicsRepository = claemPicsRepository;
            _claemInPartRepository = claemInPartRepository;
            _partRepository = partRepository;
            _batchRepository = batchRepository;
            _carInBatchRepository = carInBatchRepository;
        }

        public void ChangeStatus(long id)
        {
            _unitOfWork.BeginTran();
            var claem = _claemRepository.Get(id);
            _unitOfWork.CommitTran();
        }

        public int count()
        {
            return _claemRepository.Counts();
        }

        public void Create(RegisterClaemViewModel command)
        {
            _unitOfWork.BeginTran();
            var claem = new Claem((count()+1).ToString(),command.CountPart,command.Country,command.Company,command.Desc,command.BatchId,command.RegisterDate);
            _claemRepository.Create(claem);
            _unitOfWork.CommitTran();
            var part = _partRepository.Get(command.PartId);
            var claimInPart = new ClaimInPart(command.PartId, part, claem.Id, claem);
            _unitOfWork.BeginTran();
            _claemInPartRepository.Create(claimInPart);
            _unitOfWork.CommitTran();
            if (command.files !=null)
            {
                try
                {
                    if (!Directory.Exists(AppDirectory))
                    {
                        Directory.CreateDirectory(AppDirectory);
                    }
                    var c = 1;
                    _unitOfWork.BeginTran();
                    foreach (var file in command.files)
                    {
                        var filename = command.ClaimNumber + "_" + (c++) + Path.GetExtension(file.FileName);
                        var path = Path.Combine(AppDirectory, filename);
                       
                        var claemPic = new ClaemPic(filename,claem.Id);
                        _claemPicsRepository.Create(claemPic);
                       
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                    _unitOfWork.CommitTran();
                }
                catch
                {

                }
            }
            
        }

        public void Edit(EditClaemViewModel command)
        {
            _unitOfWork.BeginTran();
            var claem = _claemRepository.Get(command.Id);
            claem.EditClaim(command.ClaimNumber, command.CountPart, command.Country, command.Company, command.Desc, command.BatchId,command.RegisterDate, 1);
            _unitOfWork.CommitTran();
            var part = _partRepository.Get(command.PartId);
            var partInClaem=_claemInPartRepository.GetPartWithClaemId(command.Id);

            _claemInPartRepository.Delete(partInClaem.Id);
            _unitOfWork.BeginTran();

            var claimInPart = new ClaimInPart(command.PartId, part, claem.Id, claem);
            _unitOfWork.BeginTran();
            _claemInPartRepository.Create(claimInPart);
            _unitOfWork.CommitTran();
            if (command.files != null)
            {
                try
                {
                    if (!Directory.Exists(AppDirectory))
                    {
                        Directory.CreateDirectory(AppDirectory);
                    }
                    var pic = _claemPicsRepository.GetAll().Where(x => x.ClaemId == claem.Id).LastOrDefault();
                    var picname = pic.PicName.Split('.');
                    var picnmae_ = picname[0].Split('_');
                    
                    var c = picnmae_[1] + 1;
                    _unitOfWork.BeginTran();
                    foreach (var file in command.files)
                    {
                        var filename = command.ClaimNumber + "_" + (c) + Path.GetExtension(file.FileName);
                        var path = Path.Combine(AppDirectory, filename);

                        var claemPic = new ClaemPic(filename, claem.Id);
                        _claemPicsRepository.Create(claemPic);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                    _unitOfWork.CommitTran();
                }
                catch
                {

                }
            }
        }

        public GetClaemViewModel Get(string id)
        {
            var claem = _claemRepository.GetClaemWithClaemNumber(id);
            if (claem != null) { 
                var carmodel = _carInBatchRepository.GetWithBatch(claem.BatchId).CarModelName;
                var partId = _claemInPartRepository.GetPartWithClaemId(claem.Id).PartId;
                var partName = _partRepository.Get(partId).PartName;
                return new GetClaemViewModel
                {
                    Id = claem.Id,
                    Company = claem.Company,
                    CountPart = claem.CountPart,
                    RegisterDate = claem.RegisterDate,
                    BatchId = claem.BatchId,
                    BatchName = _batchRepository.Get(claem.BatchId).Name,
                    ClaimNumber = claem.ClaimNumber,
                    Country = claem.Country,
                    Desc = claem.Desc,
                    CarModel = carmodel,
                    PartId=partId,
                    PartName=partName

                };
            }
            return null;
        }

        public List<GetClaemPicsViewModel> GetClaemPics(long id)
        {
            return _claemPicsRepository.GetAll().Select(p=>new GetClaemPicsViewModel
            {
                ClaemId = p.ClaemId,
                Id = id,
                PicName=p.PicName,
            }).Where(x => x.ClaemId == id).ToList();
        }

        public ResultGetClaems List(RequestDto request)
        {
            int row = 0;
            var result= _claemRepository.GetAll().Select(x => new GetClaemViewModel
            {
                Id = x.Id,
                BatchId = x.BatchId,
                ClaimNumber = x.ClaemNumber,
                Desc=x.Desc,
                Country=x.Country,
                Company=x.Company,
                CountPart=x.CountPart
            }).ToList().ToPaged(request.Page,request.PageSize,out row);
            return new ResultGetClaems
            {
                claims = result.ToList(),
                RowCount = result.Count()
            };
        }

        public ResultGetClaems ListWithoutCkdqr(RequestDto request)
        {
            return _claemRepository.ListWithoutCkdqr(request);
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var user = _claemRepository.Get(id);
            user.Remove(1, DateTime.Now);
            _unitOfWork.CommitTran();
        }
        public void RemoveImage(string image)
        {
            _unitOfWork.BeginTran();
            _claemPicsRepository.RemoveImage(image);
            var path = Path.Combine(AppDirectory, image);
            System.IO.File.Delete(path);
            _unitOfWork.CommitTran();
        }
    }
}
