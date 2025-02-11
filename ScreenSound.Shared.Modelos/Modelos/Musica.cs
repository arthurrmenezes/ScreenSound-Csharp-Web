﻿using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Modelos;

public class Musica
{
    public virtual string Nome { get; set; }
    public virtual int Id { get; set; }
    public virtual int? AnoLancamento { get; set; }
    public virtual Artista? Artista { get; set; }
    public virtual ICollection<Genero> Generos { get; set; }

    public Musica(string nome)
    {
        Nome = nome;
    }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");

    }

    public override string ToString()
    {
        return @$"Id: {Id}
        Nome: {Nome}";
    }
}