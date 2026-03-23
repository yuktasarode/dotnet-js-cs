// using
// namespace
// ApiController
// Route
// class
// Service
// type of method
// method
// UNARCSTM

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    // Dependancy Injection
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }


    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _companyService.GetCompanies();
        return Ok(companies);
    }
}
