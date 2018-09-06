using PostgreCRUD;
using PostgreCRUD.DAOs;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            BancoConnection bd = new BancoConnection();
            bd.OpenConnection();

            CategoriaDAO cdao = new CategoriaDAO();
            Categoria c1 = new Categoria("Ação");
            Categoria c2 = new Categoria("Comedia");
            Categoria c3 = new Categoria("Romance");
            cdao.add_categoria(c1);
            cdao.add_categoria(c2);
            cdao.add_categoria(c3);
        }

    }
}
