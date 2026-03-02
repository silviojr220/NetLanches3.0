using NetLanches.Modelos.Interface;

public class PedidoItem
{
    public ItemCardapio Item { get; set; }
    public int Quantidade { get; set; }
    public double PrecoUnitario { get; set; }
    public string Descricao { get; set; }

    public PedidoItem(ItemCardapio item, int quantidade)
    {
        Item = item;
        Quantidade = quantidade;
        PrecoUnitario = item.ObterPrecoFinal();
        Descricao = item.ObterDescricao();
    }

    public double Subtotal => PrecoUnitario * Quantidade;
}