using AppCadastro;
using AppCadastro.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCadastro
{
    class Program
    {
        static FilmeRepositorio repositorio = new FilmeRepositorio();

        static void Main(string[] args)
        {

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


        public static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}



			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();

                Console.WriteLine($"#ID {filme.RetornarId()}: -  {filme.RetornarTitulo()}, {(excluido ? "(*Excluído*)" : "")}");
            }
		}

        public static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

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

            repositorio.Inserir(novoFilme);
        }


        private static void AtualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            
            Console.Write("Digite o Título do filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de lançamento do filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaSerie = new Filme(id: indiceFilme,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualizar(indiceFilme, atualizaSerie);
        }


        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceFilme);
        }


        private static void VisualizarFilme()
        {
            Console.Write("Digite o id do filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorio.RetornarPorId(indiceFilme);

            Console.WriteLine(filme);
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
