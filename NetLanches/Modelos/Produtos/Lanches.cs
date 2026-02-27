using NetLanches.Modelos.Interface;

namespace NetLanches.Modelos.NovaPasta;

class Lanches : ItemCardapio
{
    public Dictionary<string, double> Sabores { get; set; } = new();
    public Dictionary<string, double> Ingredientes { get; set; } = new();

    private string ingredienteSelecionado = "";
    private string saborSelecionado = "";

    private double valorExtraSabor = 0;
    private double valorExtraIngrediente = 0;

    public Lanches(int id, string nome, double preco, string descricao)
        : base(id, nome, preco, descricao)
    {
    }

    public void EscolherIngredientes()
    {
        if (Ingredientes.Count == 0) return;

        var lista = Ingredientes.ToList();

        int indice = ConsoleHelper.LerOpcaoLista(
            lista,
            item => $"{item.Key} (+ R$ {item.Value:F2})",
            "Escolha o ingrediente adicional"
        );

        ingredienteSelecionado = lista[indice].Key;
        valorExtraIngrediente = lista[indice].Value;
    }

    public void EscolherSabor()
    {
        if (Sabores.Count == 0) return;

        var lista = Sabores.ToList();

        int indice = ConsoleHelper.LerOpcaoLista(
            lista,
            item => $"{item.Key} (+ R$ {item.Value:F2})",
            "Escolha o sabor"
        );

        saborSelecionado = lista[indice].Key;
        valorExtraSabor = lista[indice].Value;
    }

    public override double ObterPrecoFinal()
        => Preco + valorExtraSabor + valorExtraIngrediente;

    public override string ObterDescricao()
    {
        string descricao = $"{Nome} ({saborSelecionado})";

        if (!string.IsNullOrEmpty(ingredienteSelecionado))
            descricao += $" + {ingredienteSelecionado}";

        return descricao;
    }
}