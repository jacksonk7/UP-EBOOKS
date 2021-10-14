using System;

namespace UP.Ebooks
{
    class Program
    {
        static EbookRepositorio repositorio = new EbookRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarEbooks();
						break;
					case "2":
						InserirEbook();
						break;
					case "3":
						AtualizarEbook();
						break;
					case "4":
						ExcluirEbook();
						break;
					case "5":
						VisualizarEbook();
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

        private static void ExcluirEbook()
		{
			Console.Write("Digite o id do Ebook: ");
			int indiceEbook = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceEbook);
		}

        private static void VisualizarEbook()
		{
			Console.Write("Digite o id do Ebook: ");
			int indiceEbook = int.Parse(Console.ReadLine());

			var Ebook = repositorio.RetornaPorId(indiceEbook);

			Console.WriteLine(Ebook);
		}

        private static void AtualizarEbook()
		{
			Console.Write("Digite o id do Ebook: ");
			int indiceEbook = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Ebook: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Ebook: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Ebook: ");
			string entradaDescricao = Console.ReadLine();

			Ebook atualizaEbook = new Ebook(id: indiceEbook,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceEbook, atualizaEbook);
		} 
        private static void ListarEbooks()
		{
			Console.WriteLine("Listar Ebooks");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Ebook cadastrado.");
				return;
			}

			foreach (var Ebook in lista)
			{
                var excluido = Ebook.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Ebook.retornaId(), Ebook.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		} 

        private static void InserirEbook()
		{
			Console.WriteLine("Inserir novo Ebook");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Ebook: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Ebook: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Ebook: ");
			string entradaDescricao = Console.ReadLine();

			Ebook novaEbook = new Ebook(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaEbook);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("UP Ebooks a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Ebook");
			Console.WriteLine("2- Inserir novo Ebook");
			Console.WriteLine("3- Atualizar Ebook");
			Console.WriteLine("4- Excluir Ebook");
			Console.WriteLine("5- Visualizar Ebook");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
