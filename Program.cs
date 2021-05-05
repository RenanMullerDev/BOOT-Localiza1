using System;
using DIO.Disco;


namespace DIO.Disco
{
    class Program
    {
        static DiscoRepositorio repositorio = new DiscoRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarDiscos();
						break;
					case "2":
						InserirDisco();
						break;
					case "3":
						AtualizarDisco();
						break;
					case "4":
						ExcluirDisco();
						break;
					case "5":
						VisualizarDisco();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirDisco()
		{
			Console.Write("Digite o id do Disco: ");
			int indiceDisco = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceDisco);
		}

        private static void VisualizarDisco()
		{
			Console.Write("Digite o id do Disco: ");
			int indiceDisco = int.Parse(Console.ReadLine());

			var disco = repositorio.RetornaPorId(indiceDisco);

			Console.WriteLine(disco);
		}

        private static void AtualizarDisco()
		{
			Console.Write("Digite o id da disco: ");
			int indiceDisco = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Estilo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Estilo), i));
			}
			Console.Write("Digite o estilo entre as opções acima: ");
			int entradaEstilo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Disco: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Disco: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite as Faixas do Disco: ");
			string entradaFaixas = Console.ReadLine();

			Disco atualizaDisco = new Disco(id: indiceDisco,
										estilo: (Estilo)entradaEstilo,
										titulo: entradaTitulo,
										ano: entradaAno,
										faixas: entradaFaixas);

			repositorio.Atualiza(indiceDisco, atualizaDisco);
		}
        private static void ListarDiscos()
		{
			Console.WriteLine("Listar discos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum disco cadastrado.");
				return;
			}

			foreach (var disco in lista)
			{
                var excluido = disco.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", disco.retornaId(), disco.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirDisco()
		{
			Console.WriteLine("Inserir novo disco");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Estilo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Estilo), i));
			}
			Console.Write("Digite o estilo entre as opções acima: ");
			int entradaEstilo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do disco: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Disco: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite as Faixas do Disco: ");
			string entradaFaixas = Console.ReadLine();

			Disco novoDisco = new Disco(id: repositorio.ProximoId(),
										estilo: (Estilo)entradaEstilo,
										titulo: entradaTitulo,
										ano: entradaAno,
										faixas: entradaFaixas);

			repositorio.Insere(novoDisco);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Discos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar discos");
			Console.WriteLine("2- Inserir novo disco");
			Console.WriteLine("3- Atualizar disco");
			Console.WriteLine("4- Excluir disco");
			Console.WriteLine("5- Visualizar disco");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
