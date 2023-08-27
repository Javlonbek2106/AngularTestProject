using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Interfaceses
{
    public interface ICompanyService
    {
        ValueTask<IEnumerable<Company>> GetCompanysAsync();
        ValueTask<Company> GetByCompanyId(Guid Id);
        ValueTask<Guid> CreateCompanyAsync(PostCompanyDTO companyDTO);
        ValueTask DeleteCompany(Guid companyId);
        ValueTask DeleteRange(Guid[] companysIds);
        ValueTask UpdateCompanyAsync(CompanyDTO companyDTO);
    }
}
