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

    public static async Task<IResult> HttpAddAsyncReference<TReferenceEntity, TDto>(this IDbService db, TDto dto) 
        where TReferenceEntity : class, IReferenceEntity 
        where TDto : class
    {
        try
        {
            var entity = await db.HttpAddAsync<TReferenceEntity, TDto>(dto);
            if (await db.SaveChangesAsync()) return Results.NoContent();
        }
        catch (Exception ex)
        {
            return Results.BadRequest($"Couldn't add the {typeof(TReferenceEntity).Name} entity.\n{ex}.");
        }
            return Results.BadRequest($"Couldn't add the {typeof(TReferenceEntity).Name} entity.");
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
        var success = await db.DeleteAsync<TEntity>(id);

        if (await db.SaveChangesAsync())
            return Results.NoContent();
        }
        catch (Exception)
        {
            throw;
        }

        return Results.BadRequest();
    }

    public async static Task<IResult> HttpDeleteAsync<TReferenceEntity, TDto>(this IDbService db, TDto dto)
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class
    {
        try
        {
            var success = db.Delete<TReferenceEntity, TDto>(dto);

            if (await db.SaveChangesAsync())
                return Results.NoContent();
        }
        catch (Exception)
        {
            throw;
        }

        return Results.BadRequest();
    }
}
