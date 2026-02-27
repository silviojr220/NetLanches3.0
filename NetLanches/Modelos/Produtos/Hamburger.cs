using NetLanches.Modelos;
using NetLanches.Modelos.Interface;

class Hamburger : ItemCardapio
{
    public Dictionary<string, double> Tamanhos { get; set; } = new();
    public Dictionary<string, double> Tipos { get; set; } = new();
    public Dictionary<string, double> IngredientesExtras { get; set; } = new();
    public List<string> IngredientesPadrao { get; set; } = new();

    private string tamanhoSelecionado = "";
    private string tipoSelecionado = "";

    private List<string> adicionaisSelecionados = new();
    private List<string> removidosSelecionados = new();

    private double valorExtra = 0;

    public Hamburger(int id, string nome, double preco, string descricao)
        : base(id, nome, preco, descricao)
    {
    }

    public void EscolherTamanho()
    {
        if (Tamanhos.Count == 0) return;

        var lista = Tamanhos.ToList();

        int indice = ConsoleHelper.LerOpcaoLista(
            lista,
            item => $"{item.Key} (+ R$ {item.Value:F2})",
            "Escolha o tamanho"
        );

        tamanhoSelecionado = lista[indice].Key;
        valorExtra += lista[indice].Value;
    }

    public void EscolherTipo()
    {
        if (Tipos.Count == 0) return;

        var lista = Tipos.ToList();

        int indice = ConsoleHelper.LerOpcaoLista(
            lista,
            item => $"{item.Key} (+ R$ {item.Value:F2})",
            "Escolha o tipo"
        );

        tipoSelecionado = lista[indice].Key;
        valorExtra += lista[indice].Value;
    }

    public void AdicionarIngrediente()
    {
        if (IngredientesExtras.Count == 0) return;

        var lista = IngredientesExtras.ToList();

        int indice = ConsoleHelper.LerOpcaoLista(
            lista,
            item => $"{item.Key} (+ R$ {item.Value:F2})",
            "Adicionar ingrediente"
        );

        adicionaisSelecionados.Add(lista[indice].Key);
        valorExtra += lista[indice].Value;
    }

    public void RemoverIngrediente()
    {
        if (IngredientesPadrao.Count == 0) return;

        int indice = ConsoleHelper.LerOpcaoLista(
            IngredientesPadrao,
            item => item,
            "Remover ingrediente"
        );

        removidosSelecionados.Add(IngredientesPadrao[indice]);
    }

    public override double ObterPrecoFinal()
        => Preco + valorExtra;

    public override string ObterDescricao()
    {
        string descricao = $"{Nome} {tipoSelecionado} ({tamanhoSelecionado})";

        if (adicionaisSelecionados.Any())
            descricao += $" + {string.Join(", ", adicionaisSelecionados)}";

        if (removidosSelecionados.Any())
            descricao += $" - Sem {string.Join(", ", removidosSelecionados)}";

        return descricao;
    }
}