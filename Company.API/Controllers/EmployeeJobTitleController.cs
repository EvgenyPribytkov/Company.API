namespace Company.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EmployeeJobTitleController
{
    private readonly IDbService _db;

    public EmployeeJobTitleController(IDbService db)
    {
        _db = db;
    }
    [HttpPost]
    public async Task<IResult> Post([FromBody] EmployeesJobTitleDTO dto)
    => await _db.HttpAddAsyncReference<EmployeesJobTitle, EmployeesJobTitleDTO>(dto);

    [HttpDelete]
    public async Task<IResult> Delete(EmployeesJobTitleDTO dto)
    => await _db.HttpDeleteAsync<EmployeesJobTitle, EmployeesJobTitleDTO>(dto);
}
