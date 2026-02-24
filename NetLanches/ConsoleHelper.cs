namespace NetLanches;

static class ConsoleHelper
{
    public static void MostrarErro(string mensagem = "Opção inválida!")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n{mensagem}");
        Console.ResetColor();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public static int LerInteiro(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);

            if (int.TryParse(Console.ReadLine(), out int valor))
                return valor;

            MostrarErro("Digite um número válido.");
            Console.Clear();
        }
    }

    public static int LerOpcaoLista<T>(List<T> lista, Func<T, string> exibicao)
    {
        while (true)
        {
            Console.Clear();

            MostrarLogo();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== Escolha uma opção: =====\n");
            Console.ResetColor();

            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {exibicao(lista[i])}");
            }

            Console.Write("\nDigite o número: ");

            if (int.TryParse(Console.ReadLine(), out int escolha) &&
                escolha >= 1 &&
                escolha <= lista.Count)
            {
                return escolha - 1;
            }

            MostrarErro();
        }
    }

    private static void MostrarLogo()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(@"███╗░░██╗███████╗████████╗██╗░░░░░░█████╗░███╗░░██╗░█████╗░██╗░░██╗███████╗░██████╗");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"████╗░██║██╔════╝╚══██╔══╝██║░░░░░██╔══██╗████╗░██║██╔══██╗██║░░██║██╔════╝██╔════╝");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"██╔██╗██║█████╗░░░░░██║░░░██║░░░░░███████║██╔██╗██║██║░░╚═╝███████║█████╗░░╚█████╗░");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(@"██║╚████║██╔══╝░░░░░██║░░░██║░░░░░██╔══██║██║╚████║██║░░██╗██╔══██║██╔══╝░░░╚═══██╗");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine(@"██║░╚███║███████╗░░░██║░░░███████╗██║░░██║██║░╚███║╚█████╔╝██║░░██║███████╗██████╔╝");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(@"╚═╝░░╚══╝╚══════╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝░╚════╝░╚═╝░░╚═╝╚══════╝╚═════╝░");
        Console.ResetColor();
    }
}