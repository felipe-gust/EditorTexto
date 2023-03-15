using System;
using System.IO;

namespace EditorTexto
{
    public class Editor
    {

        public void Menu()
        {

            Console.Clear();

            try
            {
                Console.WriteLine("O que você deseja fazer?");
                Console.WriteLine("1 - Abrir arquivo");
                Console.WriteLine("2 - Criar novo arquivo");
                Console.WriteLine("0 - Sair");
                short option = short.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0: System.Environment.Exit(0); break;
                    case 1: Abrir(); break;
                    case 2: Editar(); break;
                    default: Menu(); break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Valor inválido, tente novamente.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ops, aconteceu algum erro.");
            }
            finally
            {
                Console.WriteLine("Digite qualquer tecla para continuar");
                Console.ReadKey();
                Menu();
            }
            
        }

        public void Abrir()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Qual caminho do arquivo?");
                string caminho = Console.ReadLine();

                using (var arquivo = new StreamReader(caminho))
                {
                    string texto = arquivo.ReadToEnd();
                    Console.WriteLine(texto);
                }

                Console.WriteLine("");
                Console.ReadLine();

                Menu();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\nAperte qualquer tecla para continuar.");
                Console.ReadKey();
                Abrir();
            }

        }

        public void Editar()
        {
            Console.Clear();

            Console.WriteLine("Digite seu texto abaixo. Ao finalizar, aperte ESC para sair. ");
            Console.WriteLine("-------------------------");
            string texto = "";

            do
            {
                texto += Console.ReadLine();
                texto += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(texto);
        }

        public void Salvar(string texto)
        {
            Console.Clear();

            try
            {
                Console.WriteLine("Qual caminho para salvar o arquivo?");
                var caminho = Console.ReadLine();

                using (var arquivo = new StreamWriter(caminho))
                {
                    arquivo.Write(texto);
                }

                Console.WriteLine($"Arquivo {caminho} salvo com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadLine();

                Menu();
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Caminho inválido!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Ops, aconteceu algum erro.");
            }
            finally
            {
                Console.WriteLine("\nDigite qualquer tecla para continuar");
                Console.ReadKey();
                Salvar(texto);
            }
            
        }
    }
}
