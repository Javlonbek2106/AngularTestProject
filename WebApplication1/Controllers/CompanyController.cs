using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Interfaceses;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        [HttpGet]
        public async ValueTask<IEnumerable<Company>> GetAsync()
        {
            return await companyService.GetCompanysAsync();
        }

        [HttpGet("companybyid")]
        public async ValueTask<Company> GetByCompanyId(Guid Id)
        {
            var res = await companyService.GetByCompanyId(Id);
            return res;
        }

        [HttpPost]
        public async ValueTask<Guid> CreateCompanyAsync([FromForm] PostCompanyDTO companyDTO)
        {
            await companyService.CreateCompanyAsync(companyDTO);
            return Guid.NewGuid();
        }
        [HttpPut]
        public async ValueTask<ValueTask> Update(CompanyDTO companyDTO)
        {
            await companyService.UpdateCompanyAsync(companyDTO);
            return ValueTask.CompletedTask;
        }
        [HttpDelete("[action]")]
        public async ValueTask<ValueTask> Delete(Guid Id)
        {
            await companyService.DeleteCompany(Id);
            return ValueTask.CompletedTask;
        }
        [HttpDelete("[action]")]
        public async ValueTask<ValueTask> DeleteRange(Guid[] RangeIds)
        {
            await companyService.DeleteRange(RangeIds);
            return ValueTask.CompletedTask;
        }
    }
}
