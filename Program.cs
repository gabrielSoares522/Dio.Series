using System;
using Dio.Series.Classes;
using Dio.Series.Enum;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            do {
                string opcao = opcaoUsuario();

                switch(opcao){
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "x":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Argumento invalido!");
                        break;
                }
                if (opcao == "x") {
                    break;
                }
            }while(true);
        }

        private static void ListarSeries(){
            Console.WriteLine("LISTAR SÉRIE");

            var lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Não existem séries cadastradas!");
            }
            else{
                foreach(var item in lista){
                    if(!item.Excluido){
                        Console.WriteLine("{0} - {1}",item.retornaId(),item.retornaTitulo());
                    }
                }
            }
            Console.ReadKey();
        }

        private static void InserirSerie(){
            Console.WriteLine("INSERIR SÉRIE");

            int id = repositorio.ProximoId();

            ListarGeneros();
            Console.Write("Genero: ");
            int genero = int.Parse(Console.ReadLine());

            Console.Write("Titulo: ");
            string titulo = Console.ReadLine();

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());

            var novaSerie = new Serie(id,(Genero)genero,titulo,descricao,ano);
            repositorio.Inserir(novaSerie);
        }

        private static void ListarGeneros(){
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero),i));
            }
        }
        private static void AtualizarSerie(){
            Console.WriteLine("ATUALIZAR SÉRIE");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(id);

            if(serie == null){
                Console.WriteLine("Esta série não existe!");
            }else{
                ListarGeneros();
                Console.Write("Genero: ");
                int genero = int.Parse(Console.ReadLine());

                Console.Write("Titulo: ");
                string titulo = Console.ReadLine();

                Console.Write("Descrição: ");
                string descricao = Console.ReadLine();

                Console.Write("Ano: ");
                int ano = int.Parse(Console.ReadLine());

                serie = new Serie(id,(Genero)genero,titulo,descricao,ano);
                repositorio.Atualiza(id,serie);
                
                Console.WriteLine("Série {0} atualizada com sucesso!",id);
            }
            Console.ReadKey();
        }

        private static void ExcluirSerie(){
            Console.WriteLine("EXCLUIR SÉRIE");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            if(repositorio.Excluir(id)){
                Console.WriteLine("Série excluida com sucesso!");
            }else{
                Console.WriteLine("Esta série não existe!");
            }
            Console.ReadKey();
        }

        private static void VisualizarSerie(){
            Console.WriteLine("VISUALIZAR SÉRIE");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            
            var serie = repositorio.RetornaPorId(id);

            if(serie == null){
                Console.WriteLine("Esta série não existe!");
            }else{
                Console.WriteLine("Titulo: {0}",serie.retornaTitulo());
                Console.WriteLine("Gênero: {0}", Enum.GetName(typeof(Genero),serie.Genero));
                Console.WriteLine("Descrição: {0}",serie.Descricao);
                Console.WriteLine("Ano: {0}",serie.Ano);
            }
            Console.ReadKey();
        }

        private static string opcaoUsuario(){
            Console.Clear();
            Console.WriteLine("SERVIÇO DE STREAMING");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("x - Sair");
            
            Console.WriteLine();
            Console.Write("Digite a opção: ");

            string opcao = Console.ReadLine().ToLower();
            Console.Clear();
            return opcao;
        }
    }
}
