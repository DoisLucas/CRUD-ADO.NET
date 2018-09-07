using PostgreCRUD;
using PostgreCRUD.DAOs;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            BancoConnection bd = new BancoConnection();
            bd.OpenConnection();

            CategoriaDAO cdao = new CategoriaDAO();
            Categoria c1 = new Categoria(1, "Ação");
            Categoria c2 = new Categoria(2, "Comedia");
            Categoria c3 = new Categoria(3, "Romance");

            //Create
            cdao.Add(c1);
            cdao.Add(c2);
            cdao.Add(c3);

            //Read
            cdao.ShowAll();

            //Update
            cdao.Update(1, "Aventura");

            //Remove
            cdao.Remove(2);
                       
        }

    }
}
