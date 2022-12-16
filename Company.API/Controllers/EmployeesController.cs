namespace Company.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IDbService _db;

    public EmployeesController(IDbService db)
    {
        _db = db;
    }
    [HttpGet]
    public async Task<IResult> GetEmployee() => await _db.HttpGetAsync<Employee, EmployeeDTO>();

    [HttpGet("{id:int}")]
    public async Task<IResult> Get(int id) =>
        await _db.HttpGetAsync<Employee, EmployeeDTO>(id);

    [HttpPost]
    public async Task<IResult> Post([FromBody] EmployeeDTO dto)
        => await _db.HttpPostAsync<Employee, EmployeeDTO>(dto);

    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] EmployeeDTO dto)
        => await _db.HttpPutAsync<Employee, EmployeeDTO>(id, dto);

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
        => await _db.HttpDeleteAsync<Employee>(id);
}
