using Ikk.Claims.Application.Contracts.BatchContract;
using Ikk.Claims.Application.Contracts.CarInBatchContracts;
using Ikk.Claims.Application.Contracts.ClaemContracts;
using Ikk.Claims.Application.Contracts.PartContracts;
using Ikk.Claims.Application.Contracts.Rolecontract;
using Ikk.Claims.Application.Contracts.TypeCarContract;
using Ikk.Claims.Application.Contracts.UserContracts;
using Ikk.Claims.Common.Constants;
using Ikk.Claims.Common.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ikk.Claims.Presentation.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClaemController : ControllerBase
    {
        private readonly IUsersApplication _usersApplication;
        private readonly IRoleApplication _roleApplication;
        private readonly IPartApplication _partApplication;
        private readonly ITypeCarApplication _typeCarApplication;
        private readonly IBatchApplication _batchApplication;
        private readonly ICarInBatchApplication _carInbatchApplication;
        private readonly IClaemApplication _claemApplication;
        public ClaemController(IUsersApplication usersApplication, IRoleApplication roleApplication, IPartApplication partApplication, ITypeCarApplication typeCarApplication, IBatchApplication batchApplication, IClaemApplication claemApplication, ICarInBatchApplication carInbatchApplication)
        {
            _usersApplication = usersApplication;
            _roleApplication = roleApplication;
            _partApplication = partApplication;
            _typeCarApplication = typeCarApplication;
            _batchApplication = batchApplication;
            _claemApplication = claemApplication;
            _carInbatchApplication = carInbatchApplication;
        }
        //login 
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] AuthenticationRequest authenticationRequest)
        {
            var user = _usersApplication.SignIn(authenticationRequest.UserName, authenticationRequest.Password);
            if (user == null)
            {
                return NotFound(new { Message = "User Not Found!" });
            }

            var authResult = _usersApplication.Autentication(authenticationRequest.UserName, authenticationRequest.Password);
            if (authResult == null)
            {
                return NotFound(new { Message = "User Not Found!" });
            }
            else
            {
                return Ok(authResult);
            }
        }

        // User Operations
        #region user 
        [HttpPost]

        [Route("GetUsers")]
        public ResultGetUsers GetUsers([FromBody] RequestDto requsetDto)
        {
            var identify = HttpContext.User.Identity as ClaimsIdentity;
            if (identify == null)
            {
                return null;
            }
            else
            {

                var result = _usersApplication.List(requsetDto);
                return result;
            }
        }
        [HttpPost]
        [Route("CreateUser")]


        public ResultDto CreateUser(CreateUsersViewModel command)
        {
            _usersApplication.Create(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.SUCCESS };
        }
        [HttpPost]
        [Route("EditUser")]


        public ResultDto EditUser(EditUserViewModel command)
        {
            _usersApplication.Edit(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.EDIT };
        }
        [HttpPost]
        [Route("RemoveUser")]


        public ResultDto RemoveUser(long id)
        {
            _usersApplication.Remove(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.Remove };
        }
        [HttpPut]
        [Route("ChangeStatus")]
        public ResultDto ChangeStatus(long id)
        {
            _usersApplication.ChangeStatus(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.CHANGESTATUS };
        }
        [HttpPost]
        [Route("GetUser")]
        public EditUserViewModel GetUser(long id)
        {
            var result = _usersApplication.Get(id);
            return new EditUserViewModel
            {

                name = result.name,
                status = result.status,
                famil = result.famil,
                Id = result.Id,
                password = result.password,
                userName = result.userName,

                roles = result.roles
            };
        }
        #endregion
        // Role Operations
        #region Role

        [HttpPost]
        [Route("GetRoles")]
        public List<GetRolesWithIdViewModel> GetRoles([FromBody] RequestDto requsetDto)
        {
            var result = _roleApplication.List(requsetDto);
            return result;
        }
        [HttpPost]
        [Route("CreateRole")]
        public ResultDto CreateRole(RegisterRoleViewModel command)
        {
            _roleApplication.Create(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.SUCCESS };
        }
        [HttpPost]
        [Route("EditRole")]
        public ResultDto EditRole(EditRoleViewModel command)
        {
            _roleApplication.Edit(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.EDIT };
        }
        [HttpPost]
        [Route("RemoveRole")]
        public ResultDto RemoveRole(long id)
        {
            _roleApplication.Remove(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.Remove };
        }
        [HttpPut]
        [Route("ChangeRoleStatus")]
        public ResultDto ChangeRoleStatus(long id)
        {
            _roleApplication.ChangeStatus(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.CHANGESTATUS };
        }
        [HttpPost]
        [Route("GetRole")]
        public GetRolesViewModel GetRole(long id)
        {
            var result = _roleApplication.Get(id);
            if (result != null)
            {
                return new GetRolesViewModel
                {
                    Name = result.Name,
                    Status = result.Status
                };
            }
            return null;
        }
        #endregion

        #region parts
        [HttpPost]
        [Route("GetParts")]
        public List<GetPartViewModel> GetParts([FromBody] RequestDto requsetDto)
        {
            var result = _partApplication.List(requsetDto);
            return result;
        }
        [HttpPost]
        [Route("CreatePart")]
        public ResultDto CreatePart(RegisterPartViewModel command)
        {
            _partApplication.Create(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.SUCCESS };
        }
        [HttpPost]
        [Route("EditPart")]
        public ResultDto EditPart(EditPartViewModel command)
        {
            _partApplication.Edit(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.EDIT };
        }
        [HttpPost]
        [Route("RemovePart")]
        public ResultDto RemovePart(long id)
        {
            _partApplication.Remove(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.Remove };
        }
        [HttpPut]
        [Route("ChangePartstatus")]
        public ResultDto ChangePartstatus(long id)
        {
            _partApplication.ChangeStatus(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.CHANGESTATUS };
        }
        [HttpPost]
        [Route("GetPart")]
        public GetPartViewModel GetPart(long id)
        {
            var result = _partApplication.Get(id);
            if (result != null)
            {
                return new GetPartViewModel
                {
                    Id = result.Id,
                    PartName = result.PartName,
                    PartNumber = result.PartNumber,
                    Status = result.Status
                };
            }
            return null;
        }
        #endregion

        #region TypeCar
        [HttpPost]
        [Route("GetTypeCars")]
        public List<GetTypeCarViewModel> GetTypeCars([FromBody] RequestDto requsetDto)
        {
            var result = _typeCarApplication.List(requsetDto);
            return result;
        }
        [HttpPost]
        [Route("CreateTypeCar")]
        public ResultDto CreateTypeCar(RegisterTypeCarViewModel command)
        {
            _typeCarApplication.Create(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.SUCCESS };
        }
        [HttpPost]
        [Route("EditTypeCar")]
        public ResultDto EditTypeCar(EditTypeCarViewModel command)
        {
            _typeCarApplication.Edit(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.EDIT };
        }
        [HttpPost]
        [Route("RemoveTypeCar")]
        public ResultDto RemoveTypeCar(long id)
        {
            _typeCarApplication.Remove(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.Remove };
        }
        [HttpPut]
        [Route("ChangeTypeCarstatus")]
        public ResultDto ChangeTypeCarstatus(long id)
        {
            _typeCarApplication.ChangeStatus(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.CHANGESTATUS };
        }
        [HttpPost]
        [Route("GetTypeCar")]
        public GetTypeCarViewModel GetTypeCar(long id)
        {
            var result = _typeCarApplication.Get(id);
            if (result != null)
            {
                return new GetTypeCarViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    Status = result.Status
                };
            }
            return null;
        }
        #endregion

        #region Batch
        [HttpPost]
        [Route("GetBatchs")]
        public ResultGetBatches GetBatchs([FromBody] RequestDto requsetDto)
        {
            var result = _batchApplication.List(requsetDto);
            return result;
        }
        [HttpPost]
        [Route("CreateBatch")]
        public ResultDto CreateBatch(RegisterBatchViewModel command)
        {
            _batchApplication.Create(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.SUCCESS };
        }
        [HttpPost]
        [Route("EditBatch")]
        public ResultDto EditBatch(EditBatchViewModel command)
        {
            _batchApplication.Edit(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.EDIT };
        }
        [HttpPost]
        [Route("RemoveBatch")]
        public ResultDto RemoveBatch(long id)
        {
            _batchApplication.Remove(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.Remove };
        }
        [HttpPut]
        [Route("ChangeBatchstatus")]
        public ResultDto ChangeBatchstatus(long id)
        {
            _batchApplication.ChangeStatus(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.CHANGESTATUS };
        }
        [HttpPost]
        [Route("GetBatch")]
        public GetBatchViewModel GetBatch(long id)
        {
            var result = _batchApplication.Get(id);
            if (result != null)
            {
                return new GetBatchViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    Status = result.Status,
                    CarInBatchs = result.CarInBatchs,
                };
            }
            return null;
        }
        [HttpPost]
        [Route("GetCarInBatch")]
        public GetBatchWithCarViewModel GetCarInBatch(long id)
        {
            return _carInbatchApplication.Get(id);
        }
        #endregion

        #region Register Claem

        ///private static List<FileRecord> fileDb = new List<FileRecord>();
        [HttpPost]
        [Route("GetClaims")]
        public ResultGetClaems GetClaims([FromBody] RequestDto requsetDto)
        {
            var identify = HttpContext.User.Identity as ClaimsIdentity;
            if (identify == null)
            {
                return null;
            }
            else
            {

                var result = _claemApplication.List(requsetDto);
                return result;
            }
        }
        [HttpGet]
        [Route("GetCountClaims")]
        public int GetCountClaims()
        {
            var identify = HttpContext.User.Identity as ClaimsIdentity;
            if (identify == null)
            {
                return 0;
            }
            else
            {

                var result = _claemApplication.count();
                return result;
            }
        }
        [HttpPost]
        [Route("GetClaim")]
        public GetClaemViewModel GetClaim(string id)
        {
            var result = _claemApplication.Get(id);
            if (result != null)
            {
                return new GetClaemViewModel
                {
                    BatchId = result.BatchId,
                    ClaimNumber = result.ClaimNumber,
                    Company = result.Company,
                    CountPart = result.CountPart,
                    Country = result.Country,
                    Desc = result.Desc,
                    RegisterDate = result.RegisterDate,
                    files = result.files,
                    PartId = result.PartId,
                    BatchName = result.BatchName,
                    CarModel = result.CarModel,
                    PartName= result.PartName,
                    Id = result.Id
                };
            }
            return null;
        }
        [HttpPost]
        [Route("GetClaimPics")]
        public List<GetClaemPicsViewModel> GetClaemPics(long id)
        {
            return _claemApplication.GetClaemPics(id);
        }
        [HttpPost]
        [Route("CreateClaim")]
        [Consumes("multipart/form-data")]
        public ResultDto CreateClaim([FromForm] RegisterClaemViewModel command)
        {
            _claemApplication.Create(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.SUCCESS };
        }


        [HttpPost]
        [Route("EditClaim")]
        [Consumes("multipart/form-data")]

        public ResultDto EditClaim([FromForm] EditClaemViewModel command)
        {
            _claemApplication.Edit(command);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.EDIT };
        }

        [HttpPost]
        [Route("RemoveClaim")]
        public ResultDto RemoveClaim(long id)
        {
            _claemApplication.Remove(id);
            return new ResultDto { IsSuccess = true, Message = ErrorsText.Remove };
        }
        [HttpPost]
        [Route("RemoveImage")]
        public ResultDto RemoveImage(string image)
        {
            _claemApplication.RemoveImage(image);
           
            return new ResultDto { IsSuccess = true, Message = ErrorsText.Remove };
        }
        
        #endregion
    }

}
