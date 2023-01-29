namespace Company.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobTitleController : ControllerBase
{
    private readonly IDbService _db;

    public JobTitleController(IDbService db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IResult> GetEmployee() => await _db.HttpGetAsync<JobTitle, JobTitleDTO>();

    [HttpGet("{id:int}")]
    public async Task<IResult> Get(int id) =>
        await _db.HttpGetAsync<JobTitle, JobTitleDTO>(id);

    [HttpPost]
    public async Task<IResult> Post([FromBody] JobTitleDTO dto)
        => await _db.HttpPostAsync<JobTitle, JobTitleDTO>(dto);

    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] JobTitleDTO dto)
        => await _db.HttpPutAsync<JobTitle, JobTitleDTO>(id, dto);

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
        => await _db.HttpDeleteAsync<JobTitle>(id);
}
