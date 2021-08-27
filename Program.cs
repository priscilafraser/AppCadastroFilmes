using AppCadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastro
{
    class Program
    {
        static void Main(string[] args)
        {

            static FilmeRepositorio repositorio = new FilmeRepositorio();

            string opcaoUsuario = GetOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = GetOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }


        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                //var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo());   //, (excluido ? "*Excluído*" : "")
			}
		}


        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de de lançamento do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorio.ProximoId(),
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}





        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}















        public static string GetOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Os melhores filmes de ficção científica em um só lugar!");
            Console.WriteLine("Informe a opção desejada.");

            Console.WriteLine("1 - Listar filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;

        }



    }
}
