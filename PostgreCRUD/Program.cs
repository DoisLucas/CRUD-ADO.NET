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

            #region Categoria

            Categoria c1 = new Categoria(1, "Ação");
            Categoria c2 = new Categoria(2, "Comedia");
            Categoria c3 = new Categoria(3, "Romance");
            CategoriaDAO cdao = new CategoriaDAO();

            //Create
            cdao.Add(c1);
            cdao.Add(c2);
            cdao.Add(c3);

            Console.WriteLine(cdao.getOne(3).ToString());

            foreach (Categoria c in cdao.getAll())
            {
                Console.WriteLine(c.ToString());
            }

            //Read
            cdao.ShowAll();

            //Update
            cdao.Update(1, "Aventura");

            //Remove
            cdao.Remove(2);

            #endregion


            #region Diretor

            Diretor d1 = new Diretor(1, "Pedro");
            Diretor d2 = new Diretor(2, "Lucas");
            Diretor d3 = new Diretor(3, "Cabral");
            DiretorDAO ddao = new DiretorDAO();

            //Create
            ddao.Add(d1);
            ddao.Add(d2);
            ddao.Add(d3);

            //Read
            ddao.ShowAll();

            //Update
            ddao.Update(2, "Lucas Braga");

            //Remove
            ddao.Remove(3);

            #endregion

            #region File

            Filme f1 = new Filme(1, "Titanic", Convert.ToDateTime("27/11/2007"), c1);
            Filme f2 = new Filme(2, "Vingadores", Convert.ToDateTime("27/01/2012"), c2);
            FilmeDAO fdao = new FilmeDAO();

            //Create
            fdao.Add(f1);
            fdao.Add(f1);

            #endregion

        }

    }
}
