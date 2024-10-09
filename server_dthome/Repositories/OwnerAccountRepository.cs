using AutoMapper;
using server_dthome.Entities;
using server_dthome.Models;
using server_dthome.ViewModels;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace server_dthome.Repositories
{
    public class OwnerAccountRepository : IOwnerAccountRepository
    {
        private readonly DthomeContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public OwnerAccountRepository(DthomeContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }

        public OwnerAccountVM Create(OwnerAccountModel ownerAccountModel)
        {
            ownerAccountModel.Password = BCrypt.Net.BCrypt.HashPassword(ownerAccountModel.Password);
            var account = _mapper.Map<OwnerAccount>(ownerAccountModel);
            _context.OwnerAccounts.Add(account);
            _context.SaveChanges();
            return _mapper.Map<OwnerAccountVM>(account);
        }

        public bool Delete(int id)
        {
            var account = _context.OwnerAccounts.FirstOrDefault(r => r.AccountId == id);
            if (account != null)
            {
                _context.OwnerAccounts.Remove(account);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<OwnerAccountVM> GetAll()
        {
            var accounts = _context.OwnerAccounts.ToList();
            var accountVMs = _mapper.Map<List<OwnerAccountVM>>(accounts);
            return accountVMs;
        }

        public OwnerAccountVM GetById(int id)
        {
            var account = _context.OwnerAccounts.FirstOrDefault(a => a.AccountId == id);
            return _mapper.Map<OwnerAccountVM>(account);
        }

        public bool Update(int id, OwnerAccountModel ownerAccountModel)
        {
            var account = _context.OwnerAccounts.FirstOrDefault(r => r.AccountId == id);
            if (account != null)
            {
                _mapper.Map(ownerAccountModel, account);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public OwnerBuildingVM Login(LoginModel loginModel)
        {
            //var account = _context.OwnerAccounts.FirstOrDefault(a => a.AccountId == id);
            var account = _context.OwnerAccounts.FirstOrDefault(o => o.PhoneNumber == loginModel.PhoneNumber);
            if (account != null)
            {
                bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(loginModel.Password.Trim(), account.Password);
                if (isPasswordMatch)
                {
                    var owner = _context.OwnerBuildings.FirstOrDefault(o => o.PhoneNumber == loginModel.PhoneNumber);
                    return _mapper.Map<OwnerBuildingVM>(owner);
                }
            }
            return null;
        }

        public string GenerateJwtToken(OwnerAccount account)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, account.AccountId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Name, account.PhoneNumber)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),  // Token expires after 30 minutes
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
