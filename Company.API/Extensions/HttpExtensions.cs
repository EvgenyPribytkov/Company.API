using Company.Common.DTOs;
using Company.Data.Entities;
using Company.Data.Interfaces;

namespace Company.API.Extensions;

public static class HttpExtensions
{
    public async static Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db)
        where TEntity: class, IEntity
        where TDto : class
    {
        return Results.Ok(await db.GetAsync<TEntity, TDto>());
    }
    public async static Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db, int id)
    where TEntity : class, IEntity
    where TDto : class
    {
        var entity = await db.SingleAsync<TEntity, TDto>(o => o.Id == id);
        if (entity == null) return Results.BadRequest();
        return Results.Ok(entity);
    }
    public async static Task<IResult> HttpPostAsync<TEntity, TDto>(this IDbService db, TDto dto)
    where TEntity : class, IEntity
    where TDto : class
    {
        if (dto is null) return Results.BadRequest();
        var entity = await db.AddAsync<TEntity, TDto>(dto);
        if (await db.SaveChangesAsync())
        {
            var Uri = db.GetURI<TEntity>(entity);
            return Results.Created(Uri, entity);
        }
        return Results.BadRequest();
    }

    public async static Task<IResult> HttpPutAsync<TEntity, TDto>(this IDbService db, int id, TDto dto)
    where TEntity : class, IEntity
    where TDto : class
    {
        if (dto is null) return Results.BadRequest();
        if (!await db.AnyAsync<TEntity>(e => e.Id.Equals(id)))
            return Results.NotFound();

        db.Update<TEntity, TDto>(id, dto);

        if (await db.SaveChangesAsync())
            return Results.NoContent();

        return Results.BadRequest();
    }

    public async static Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id)
    where TEntity : class, IEntity
    {
        try
        {
        var success = await db.DeleteAsync<IEntity>(id);

        if (await db.SaveChangesAsync())
            return Results.NoContent();
        }
        catch (Exception)
        {
            throw;
        }

        return Results.BadRequest();
    }





    //public async Task<IResult> HttpDeleteAsync<TReferenceEntity>
    //{
    //    try
    //    {
    //        if (!_db.Delete<EmployeesJobTitle, EmployeesJobTitleDTO>)
    //            return Results.NotFound();
    //        if (await db.SaveChangesAsync()) return Results.NoContent();
    //    }
    //    catch (Exception)
    //    {
    //        return Results.BadRequest($"Couldn't delete the {typeof(EmployeesJobTitle).Name} entity.");
    //    }
    //    return Results.BadRequest($"Couldn't delete the {typeof(EmployeesJobTitle).Name} entity.");
    //}
    //public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db)
    //    where TEntity : class, IEntity
    //    where TDto : class
    //{
    //    var entities = await db.GetAsync<TEntity, TDto>;
    //    return Results.Ok(entities);
    //}
}
