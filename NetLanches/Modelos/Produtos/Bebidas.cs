using NetLanches.Modelos.Interface;

namespace NetLanches.Modelos.NovaPasta;

class Bebidas : ItemCardapio
{
    public Dictionary<string, double> Tamanhos { get; set; } = new();
    public Dictionary<string, double> SaborRefri { get; set; } = new();


    private string saborRefriSelecionado = "";
    private string tamanhoSelecionado = "";
    private double valorExtra = 0;

    public Bebidas(int id, string nome, double preco, string descricao)
        : base(id, nome, preco, descricao)
    {
    }
    public void EscolherSaborRefri()
    {
        if (SaborRefri.Count == 0) return;

        var lista = SaborRefri.ToList();

        int indice = ConsoleHelper.LerOpcaoLista(
            lista,
            item => item.Key
        );

        saborRefriSelecionado = lista[indice].Key;
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

    public override string ObterDescricao()
        => $"{Nome} - {saborRefriSelecionado} ({tamanhoSelecionado})";
}