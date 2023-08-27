using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Interfaceses;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IDbContext _dbContext;

        public CompanyService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<Guid> CreateCompanyAsync(PostCompanyDTO companyDTO)
        {
            Company company = new Company();
            company.Name = companyDTO.Name;
            company.Address = companyDTO.Address;
            company.CreatedDate = companyDTO.CreatedDate;
            await _dbContext.Companys.AddAsync(company);
            _dbContext.SaveChanges();
            return company.Id;
        }

        public ValueTask DeleteCompany(Guid companyId)
        {
            Company? company = _dbContext.Companys.FirstOrDefault(u => u.Id.Equals(companyId));
            _dbContext.Companys.Remove(company);
            _dbContext.SaveChanges();
            return ValueTask.CompletedTask;
        }

        public async ValueTask<IEnumerable<Company>> GetCompanysAsync()
        {
            IEnumerable<Company> companies = await _dbContext.Companys
                .Include(company => company.Users)
                .AsNoTracking()
                .ToListAsync();
            return companies;
        }
       
        public async ValueTask<Company?> GetByCompanyId(Guid Id)
        {

            var company = _dbContext.Companys.FirstOrDefault(u => u.Id == Id);
            return company;
        }

        public ValueTask DeleteRange(Guid[] companysIds)
        {
            foreach (var id in companysIds)
            {
                DeleteCompany(id);
            }
            _dbContext.SaveChanges();
            return ValueTask.CompletedTask;
        }

        public ValueTask UpdateCompanyAsync(CompanyDTO companyDTO)
        {
            Company? company = _dbContext.Companys.FirstOrDefault(u => u.Id.Equals(companyDTO.Id));
            company.Name = companyDTO.Name;
            company.Address = companyDTO.Address;
            company.CreatedDate = companyDTO.CreatedDate;
            _dbContext.Companys.Update(company);
            _dbContext.SaveChanges();
            return ValueTask.CompletedTask;
        }

    }
}
