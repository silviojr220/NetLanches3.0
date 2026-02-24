namespace NetLanches;

class Lanches : ItemCardapio
{
    public Dictionary<string, double> Sabores { get; set; } = new();

    private string saborSelecionado = "";
    private double valorExtra = 0;

    public Lanches(int id, string nome, double preco, string descricao)
        : base(id, nome, preco, descricao)
    {
    }

    public void EscolherSabor()
    {
        
        if (Sabores.Count == 0) return;

        var lista = Sabores.ToList();

        int indice = ConsoleHelper.LerOpcaoLista(
            lista,
            item => $"{item.Key} (+ R$ {item.Value:F2})"
        );

        saborSelecionado = lista[indice].Key;
        valorExtra = lista[indice].Value;
    }

    public override double ObterPrecoFinal() => Preco + valorExtra;

    public override string ObterDescricao() => $"{Nome} ({saborSelecionado})";
}