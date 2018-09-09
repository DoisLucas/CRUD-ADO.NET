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
            Categoria c = new Categoria(1, "Aventura");
            cdao.Add(c);

            DiretorDAO ddao = new DiretorDAO();
            Diretor d = new Diretor(1, "Pedro");
            ddao.Add(d);

            FilmeDAO fdao = new FilmeDAO();
            Filme f = new Filme(1, "Interstelar", Convert.ToDateTime("27/11/2007"), c);
            fdao.Add(f);
            //f.AddDiretor(d);


        }

    }
}
