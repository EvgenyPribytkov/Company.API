namespace Company.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DepartmentController
{
    private readonly IDbService _db;

    public DepartmentController(IDbService db)
    {
        _db = db;
    }
    [HttpGet]
    public async Task<IResult> GetEmployee() => await _db.HttpGetAsync<Department, DepartmentDTO>();

    [HttpGet("{id:int}")]
    public async Task<IResult> Get(int id) =>
        await _db.HttpGetAsync<Department, DepartmentDTO>(id);

    [HttpPost]
    public async Task<IResult> Post([FromBody] DepartmentDTO dto)
        => await _db.HttpPostAsync<Department, DepartmentDTO>(dto);

    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] DepartmentDTO dto)
        => await _db.HttpPutAsync<Department, DepartmentDTO>(id, dto);

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
        => await _db.HttpDeleteAsync<Department>(id);
}
