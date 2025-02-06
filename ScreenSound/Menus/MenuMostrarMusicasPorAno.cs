using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuMostrarMusicasPorAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibir músicas por ano de lançamento");
        Console.Write("Digite o ano de lançamento das músicas que deseja mostrar: ");
        string anoLancamento = Console.ReadLine()!;

        var musicaDAL = new DAL<Musica>(new ScreenSoundContext());
        var listaAnoLancamento = musicaDAL.ListarPor(m => m.AnoLancamento.Equals(Convert.ToInt32(anoLancamento)));

        if (listaAnoLancamento.Any())
        {
            Console.WriteLine($"\nMúsicas do ano {anoLancamento}:");
            foreach (var musica in listaAnoLancamento)
            {
                musica.ExibirFichaTecnica();
            }
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\nNenhuma música foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
