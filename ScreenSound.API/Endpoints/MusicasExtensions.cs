using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void AddEndPointsMusicas(this WebApplication app)
    {
        app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
        {
            return Results.Ok(dal.Listar());
        });

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequest musicaRequest) =>
        {
            var musica = new Musica(musicaRequest.nome)
            {
                Id = musicaRequest.ArtistaId,
                AnoLancamento = musicaRequest.AnoLancamento,
                Generos = musicaRequest.Generos is not null ? 
                GeneroRequestConverter(musicaRequest.Generos) : new List<Genero>()
            };
            dal.Adicionar(musica);
            return Results.Ok();
        });

        app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
        {
            var musicaAAtualizar = dal.RecuperarPor(m => m.Id.Equals(musica.Id));

            if (musicaAAtualizar is null)
            {
                return Results.NotFound();
            }
            musicaAAtualizar.Nome = musica.Nome;
            musicaAAtualizar.AnoLancamento = musica.AnoLancamento;
            musicaAAtualizar.Artista = musica.Artista;
            dal.Atualizar(musicaAAtualizar);
            return Results.Ok();
        });

        app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
        {
            var musica = dal.RecuperarPor(m => m.Id.Equals(id));
            if (musica is null)
            {
                return Results.NotFound();
            }
            dal.Deletar(musica);
            return Results.NoContent();
        });
    }

    private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos)
    {
        return generos.Select(a => RequestToEntity(a)).ToList();
    }

    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
    }
}
