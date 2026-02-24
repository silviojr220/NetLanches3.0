namespace NetLanches;

class ItemCardapio
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public string Descricao { get; set; }

    public ItemCardapio(int id, string nome, double preco, string descricao)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Descricao = descricao;
    }

    public virtual double ObterPrecoFinal()
    {
        return Preco;
    }

    public virtual string ObterDescricao()
    {
        return Nome;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"{Id} - {Nome} | R$ {Preco:F2}");
        Console.WriteLine(Descricao);
    }
}