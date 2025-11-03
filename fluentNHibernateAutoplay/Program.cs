using fluentNHibernateAutoplay.Entidades;
using fluentNHibernateAutoplay.infra;
using NHibernate;

internal class Program
{
    private static void Main(string[] args)
    {
        //Criação de dados ficticios
        Cliente cliente = new Cliente("Fulano", "Fulano@gmail.com", "senhasegura");
        Produto produto1 = new("Caderno", 10.5f);
        Produto produto2 = new("Caneta", 1.5f);
        Produto produto3 = new("Borracha", 0.5f);

        IList<Produto> produtos = [produto1, produto2, produto3];


        //Instancia a sessão do NHibernate
        ISession session = HibernateUtil.getSession();
        ITransaction transaction = session.BeginTransaction();

        //Método PUT (incluir o novo cliente no banco)
        session.Save(cliente);

        //Recupera um objeto do tipo informado, através do ID (No ex abaixo "1")
        Cliente cliente1 = session.Get<Cliente>(1);

        //Método UPDATE (Subindo as mudanças do cliente para o banco)
        cliente.Nome = "Ciclano";
        cliente.Email = "Ciclano@gmail.com";
        session.Update(cliente);
        transaction.Commit();

        //Método DELETE (Deleta o cliente que foi recuperado anteriormente no GET, através da chamada do ID)
        session.Delete(cliente1);
        transaction.Commit();

        //Criando um pedido, com a chave estrangeira de Cliente
        Pedido pedido = new(cliente, produtos);
        session.Save(pedido);

        // Define uma consulta ao banco do tipo Pedido
        // Exemplo: SELECT * FROM Pedido;
        IQueryable<Pedido> query = session.Query<Pedido>();

        // Modifica a consulta utilizando LINQ
        // Exemplo: SELECT * FROM Pedido WHERE Cliente.Nome = "Ciclano";
        query = query.Where(p => p.Cliente.Nome == "Ciclano");

        //Retorna a lista de itens que consultei com a query acima
        IList<Pedido> listaConsultada = query.ToList();

    }
}