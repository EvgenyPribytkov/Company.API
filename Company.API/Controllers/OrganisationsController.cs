using Company.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Company.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OrganisationsController : ControllerBase
{
    private readonly CompanyContext _db;

    public OrganisationsController(CompanyContext db)
    {
        _db = db;
    }
    [HttpGet()]
    public async Task<IResult> Get()
    {
        var orgs = await _db.Organisations.ToListAsync();
        return Results.Ok(orgs);
    }

    [HttpGet("{filter}")]
    public async Task<IResult> Get(string filter)
    {
        var orgs = await _db.Organisations.Where(
            o => o.OrganisationName.StartsWith(filter)).
            ToListAsync();
        return Results.Ok(orgs);
    }

    [HttpGet("{id}")]
    public async Task<IResult> Get(int id)
    {
        var org = await _db.Organisations.SingleOrDefaultAsync(
            o => o.Id.Equals(id));
        return Results.Ok(org);
    }
}
