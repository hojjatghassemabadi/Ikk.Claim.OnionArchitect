

using Ikk.Claims.Application.Contracts.Rolecontract;
using Ikk.Claims.Application.Contracts.UserContracts;
using Ikk.Claims.Common;
using Ikk.Claims.Common.Constants;
using Ikk.Claims.Common.Entities;
using Ikk.Claims.Common.Infrastructure;
using Ikk.Claims.Common.Pagination;
using Ikk.Claims.Domain.Enities.Users;
using Ikk.Claims.Domain.Entities.Users;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ikk.Claims.Application.UserApplications
{
    public class UsersApplication : IUsersApplication
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _RoleRepository;
        private readonly IUserInRoleRepository _userInRoleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UsersApplication(IUserRepository userRepository, IRoleRepository roleRepository, IUserInRoleRepository userInRoleRepository,IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _RoleRepository = roleRepository;
            _userInRoleRepository = userInRoleRepository;
            _unitOfWork = unitOfWork;
        }

        public void ChangeStatus(long id)
        {
            _unitOfWork.BeginTran();
            var user = _userRepository.Get(id);
            user.ChangeStatus(!user.Status);
            _unitOfWork.CommitTran();
        }

        public void Create(CreateUsersViewModel command)
        {
            _unitOfWork.BeginTran();
            List<Role> roles = new List<Role>();
           foreach(var role in command.roles)
            {
                Role r = _RoleRepository.Get(role.Id);
                roles.Add(r);
            }
            var user = new User(command.name,command.famil,command.userName,command.password,command.status,1);
            var UserInRoles = new List<UserInRole>();
            foreach (var role in roles)
            {
                UserInRoles.Add(new UserInRole(user.Id, user, role.Id, role));
            }
            user.UserInRoles = UserInRoles;
            _userRepository.Create(user);
            _unitOfWork.CommitTran();
           
        }

        public void Edit(EditUserViewModel command)
        {
            _unitOfWork.BeginTran();
            var user = _userRepository.Get(command.Id);
            List<Role> roles = new List<Role>();
            foreach (var role in command.roles)
            {
                Role mainRole = _RoleRepository.Get(role.Id);
                roles.Add(mainRole);
               
            }
            var UserInRoles = new List<UserInRole>();
            user.EditUser(command.name, command.famil, command.userName, command.password, command.status,1);
            foreach(var riu in _userInRoleRepository.GetWithUser(user.Id))
            {
                var roleinUserInRole = _userInRoleRepository.GetWithRoleAndUser(command.Id,riu.RoleId);
                if (roleinUserInRole != null)
                    _userInRoleRepository.RemoveAll(user.Id,riu.RoleId);
            }
            foreach (var role in roles)
            {
                UserInRoles.Add(new UserInRole(user.Id, user, role.Id, role));
            }

            user.UserInRoles = UserInRoles;

            _unitOfWork.CommitTran();
        }
        public EditUserViewModel SignIn(string username,string password)
        {
            
            var user = _userRepository.GetBy(username);
            if(user != null)
            {
                if(user.Password != password || !user.Status)
                {
                    return null;
                }
                else
                {
                    return new EditUserViewModel
                    {
                        Id = user.Id,
                        name = user.Name,
                        famil = user.Famil,
                        status = user.Status,
                        userName = user.UserName
                    };
                }
            }
            return null;
        }
        public EditUserViewModel Get(long id)
        {
             var user=_userRepository.Get(id);
            List<RoleViewModel> roles= new List<RoleViewModel>();
            if (user.UserInRoles == null)
            {
                roles = null;
            }
            else
            {
                foreach (var role in user.UserInRoles)
                {
                    var rol = _RoleRepository.Get(role.RoleId);
                    roles.Add(new RoleViewModel { Id = rol.Id });
                }
            }
            
            return new EditUserViewModel
            {
                Id = user.Id,
                name = user.Name,
                famil = user.Famil,
                password = user.Password,
                status = user.Status,
                userName = user.UserName,
                roles=roles
            };
        }

        public ResultGetUsers List(RequestDto request)
        {
            int row = 0;
            var allusers = _userRepository.GetAll();
            var users= allusers.ToPaged(request.Page, request.PageSize, out row).OrderBy(x => x.Id);
            var result = new List<UsersViewModel>();
            foreach (var user in users)
            {
                result.Add(new UsersViewModel
                {
                    Id=user.Id,
                    Name = user.Name,
                    Famil = user.Famil,
                    Status = user.Status,
                    UserName = user.UserName,
                    DateCreated = user.DateCreated.ToString(CultureInfo.InvariantCulture)
                });
            }
            return new ResultGetUsers
            {
                RowCount = allusers.Count(),
                users = result
            };
                
        }

        public void Remove(long id)
        {
            _unitOfWork.BeginTran();
            var user = _userRepository.Get(id);
            user.Remove(1,DateTime.Now);
            _unitOfWork.CommitTran();
            
        }

        public JwtAuthResponse Autentication(string username, string password)
        {
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(Constant.JWT_TOKEN_VALIDITY_MINS);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.ASCII.GetBytes(Constant.JWT_SECURITY_KEY);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                    new Claim("username", username),
                    new Claim(ClaimTypes.PrimaryGroupSid, "User Group 01")
                }),
                Expires = DateTime.Now.AddMinutes(Constant.JWT_TOKEN_VALIDITY_MINS),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var securityTokens = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityTokens);
            return new JwtAuthResponse
            {
                Token = token,
                UserName = username,
                Expires_in = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };
        }
    }
}
