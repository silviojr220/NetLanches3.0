namespace NetLanches;

class Bebidas : ItemCardapio
{
    public Dictionary<string, double> Tamanhos { get; set; } = new();

    private string tamanhoSelecionado = "";
    private double valorExtra = 0;

    public Bebidas(int id, string nome, double preco, string descricao)
        : base(id, nome, preco, descricao)
    {
    }

    public void EscolherTamanho()
    {
        if (Tamanhos.Count == 0) return;

        var lista = Tamanhos.ToList();

        int indice = ConsoleHelper.LerOpcaoLista(
            lista,
            item => $"{item.Key} (+ R$ {item.Value:F2})"
        );

        tamanhoSelecionado = lista[indice].Key;
        valorExtra = lista[indice].Value;
    }

    public override double ObterPrecoFinal() => Preco + valorExtra;

    public override string ObterDescricao() => $"{Nome} ({tamanhoSelecionado})";
}