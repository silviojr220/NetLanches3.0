namespace NetLanches.Modelos.Interface
{
    class TelaInicio : Menu
    {
        public void MostrarTelaInicio()
        {
            int opcaoNumber = 0;

            while (opcaoNumber != 3)
            {
                MostrarLogo();
                Console.WriteLine("\n==- Bem vindo ao NetLanches! -==\n");

                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Fazer Pedido");
                Console.WriteLine("2 - Ver Cardápio");
                Console.WriteLine("3 - Sair");

                Console.Write("\nDigite a opção desejada: ");
                string opcao = Console.ReadLine()!;

                if (!int.TryParse(opcao, out opcaoNumber))
                {
                    Console.WriteLine("\nOpção inválida! Digite apenas números.");
                }
                else
                {
                    switch (opcaoNumber)
                    {
                        case 1:
                            Console.WriteLine("\nVocê selecionou: Fazer Pedido");
                            ExibirMenu();
                            break;

                        case 2:
                            Console.Clear();

                            MostrarLogo();
                            Console.WriteLine("\n==- Bem vindo ao NetLanches! -==\n");
                            ExibirCardapioSimples();
                            break;

                        case 3:
                            Console.WriteLine("\nSaindo do sistema...");
                            break;

                        default:
                            Console.WriteLine("\nOpção inválida!");
                            break;
                    }
                }

                if (opcaoNumber != 3)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}