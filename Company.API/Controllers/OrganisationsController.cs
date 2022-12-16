namespace Company.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrganisationsController : ControllerBase
{
    private readonly IDbService _db;

    public OrganisationsController(IDbService db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IResult> Get() => await _db.HttpGetAsync<Organisation, OrganisationDTO>();

    [HttpGet("{id:int}")]
    public async Task<IResult> Get(int id) => 
        await _db.HttpGetAsync<Organisation, OrganisationDTO>(id);

    [HttpPost]
    public async Task<IResult> Post([FromBody] OrganisationDTO dto) 
        => await _db.HttpPostAsync<Organisation, OrganisationDTO>(dto);

    [HttpPut("{id}")]
    public async Task<IResult> Put(int id, [FromBody] OrganisationDTO dto)
        => await _db.HttpPutAsync<Organisation, OrganisationDTO>(id, dto);

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
        => await _db.HttpDeleteAsync<Organisation>(id);
}

