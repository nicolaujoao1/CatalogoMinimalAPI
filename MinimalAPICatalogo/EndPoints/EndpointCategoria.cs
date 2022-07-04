using Microsoft.EntityFrameworkCore;
using MinimalAPICatalogo.Context;
using MinimalAPICatalogo.Models;

namespace MinimalAPICatalogo.EndPoints;

public static class EndpointCategoria
{
    public static void MapEndpointCategoria(this WebApplication app)
    {
        app.MapGet("api/categoria", async (AppDbContext db) =>
        {
            return await db.Categorias.ToListAsync();
        }).RequireAuthorization().WithName("Categoria-Ecriptada") ;
        app.MapGet("api/catoria/{id:int}", async (AppDbContext db, int id) => {
            // return db.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            return await db.Categorias.FindAsync(id) is Categoria categoria
            ? Results.Ok(categoria) : Results.NotFound();
        });
        app.MapPost("api/categoria", async (Categoria categoria, AppDbContext db) =>
        {
            db.Categorias.Add(categoria);
            await db.SaveChangesAsync();
            return Results.Created($"/categoria/{categoria.CategoriaId}", categoria);
        });
        app.MapPut("api/categoria/{id:int}", async (int id, Categoria categoria, AppDbContext db)
             =>
        {
            if (!(categoria.CategoriaId == id))
                return Results.BadRequest();
            var categoriaDB = await db.Categorias.FindAsync(id);
            if (categoriaDB is null)
                return Results.NotFound();
            categoriaDB.Nome = categoria.Nome;
            categoriaDB.Descricao = categoria.Descricao;
            await db.SaveChangesAsync();
            return Results.Ok(categoriaDB);
        });

    }
}
