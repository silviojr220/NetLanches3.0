namespace NetLanches;

class Menu
{
    private List<ItemCardapio> cardapio = new();
    private List<PedidoItem> itensPedido = new();

    public Menu()
    {
        CriarCardapio();
    }

    private void CriarCardapio()
    {
        var coxinha = new ItemCardapio(1, "Coxinha", 3.50, "Temos com catupiry e frango");
        var kibe = new ItemCardapio(4, "Kibe", 3.00, "Kibe frito e assado");

        var pastel = new Lanches(2, "Pastel", 5.00, "Pastel frito na hora");
        pastel.Sabores.Add("Frango", 0);
        pastel.Sabores.Add("Carne", 0);
        pastel.Sabores.Add("Queijo", 1.00);
        pastel.Sabores.Add("Carne do Sol", 2.00);

        var empada = new Lanches(3, "Empada", 4.00, "Sabores variados");
        empada.Sabores.Add("Frango", 0);
        empada.Sabores.Add("Catupiry", 1.00);
        empada.Sabores.Add("Carne", 1.50);

        var refrigerante = new Bebidas(5, "Refrigerante", 4.00, "Coca, Guaraná ou Fanta");
        refrigerante.Tamanhos.Add("Pequeno", 0);
        refrigerante.Tamanhos.Add("Médio", 1.50);
        refrigerante.Tamanhos.Add("Grande", 3.00);

        cardapio.AddRange(new List<ItemCardapio>
        {
            coxinha,
            pastel,
            empada,
            kibe,
            refrigerante
        });
    }

    public void ExibirMenu()
    {


        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            MostrarLogo();

            Console.WriteLine("\nBem vindo ao NetLanches!");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===== CARDÁPIO =====\n");
            Console.ResetColor();

            foreach (var item in cardapio)
            {
                item.ExibirDetalhes();
                Console.WriteLine();
            }

            // Validação Item
            Console.Write("\nDigite o número do item desejado: ");
            if (!int.TryParse(Console.ReadLine(), out int resposta))
            {
                MostrarErro();
                continue;
            }

            var itemEscolhido = cardapio.FirstOrDefault(i => i.Id == resposta);
            if (itemEscolhido == null)
            {
                MostrarErro();
                continue;
            }

            if (itemEscolhido is Lanches lanche)
                lanche.EscolherSabor();

            if (itemEscolhido is Bebidas bebida)
                bebida.EscolherTamanho();

            // Validação Quantidade
            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
            {
                MostrarErro();
                continue;
            }

            var pedidoExistente = itensPedido.FirstOrDefault(p =>
                p.Item.Id == itemEscolhido.Id &&
                p.Item.ObterDescricao() == itemEscolhido.ObterDescricao()
            );

            if (pedidoExistente != null)
            {
                pedidoExistente.Quantidade += quantidade;
                Console.WriteLine($"\nAtualizado: {pedidoExistente.Quantidade}x {pedidoExistente.Descricao}");
                Console.WriteLine($"Subtotal: R$ {pedidoExistente.Subtotal:F2}");
            }
            else
            {
                var pedidoItem = new PedidoItem(itemEscolhido, quantidade);
                itensPedido.Add(pedidoItem);

                Console.WriteLine($"\nVocê adicionou {quantidade}x {pedidoItem.Descricao}");
                Console.WriteLine($"Subtotal: R$ {pedidoItem.Subtotal:F2}");

                // Continuar?
                bool respostaValida = false;
                while (!respostaValida)
                {
                    Console.Write("\nDeseja adicionar mais itens? (s/n): ");
                    string respostaContinuar = Console.ReadLine()!.Trim().ToLower();

                    if (respostaContinuar == "s")
                    {
                        respostaValida = true;
                    }
                    else if (respostaContinuar == "n")
                    {
                        continuar = false; // Encerra loop principal
                        respostaValida = true;

                    }
                    else
                    {
                        MostrarErro();
                    }

                }
            }

            MostrarResumo();
        }
    }

    private void MostrarErro()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nOpção inválida!");
        Console.ResetColor();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    private void MostrarResumo()
    {
        Console.Clear();
        MostrarLogo();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n===== RESUMO DO PEDIDO =====\n");
        Console.ResetColor();

        double total = 0;

        foreach (var pedido in itensPedido)
        {
            Console.WriteLine($"{pedido.Quantidade}x {pedido.Descricao} - R$ {pedido.Subtotal:F2}");
            total += pedido.Subtotal;
        }

        Console.WriteLine($"\nTotal a pagar: R$ {total:F2}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nObrigado pela preferência! =)");
        Console.ResetColor();
    }

    private void MostrarLogo()
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