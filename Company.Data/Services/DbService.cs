namespace Company.Data.Services;
using Company.Data.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DbService : IDbService 
{
    private readonly CompanyContext _db;
	private readonly IMapper _mapper;
    public DbService(CompanyContext db, IMapper mapper)
	{
		_db = db;
		_mapper = mapper;
	}

    public async Task<List<TDto>> GetAsync<TEntity, TDto>()
        where IEntity : class
        where TDto : class
    {
        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }
}
