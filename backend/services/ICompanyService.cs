public interface ICompanyService
{
    Task<List<Company>> GetCompanies();
}