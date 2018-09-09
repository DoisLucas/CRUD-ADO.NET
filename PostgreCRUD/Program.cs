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
            Diretor d1 = new Diretor(2, "Lucas");
            ddao.Add(d1);

            FilmeDAO fdao = new FilmeDAO();
            Filme f = new Filme(1, "Interstelar", Convert.ToDateTime("27/11/2007"), c);
            Filme f1 = new Filme(2, "Vingadores", Convert.ToDateTime("27/11/2017"), c);
            fdao.Add(f);
            fdao.Add(f1);

            f.AddDiretor(d);
            f.AddDiretor(d1);

            d.AddFilme(f1);

            //Mostrando filme do diretor D
            Console.WriteLine("\nFilmes do diretor " + d.Nome_diretor);
            foreach (Filme filme in d.filmes)
            {
                Console.WriteLine(filme.ToString());
            }

            //Mostrando filme do diretor D1
            Console.WriteLine("\nFilmes do diretor " + d1.Nome_diretor);
            foreach (Filme filme in d1.filmes)
            {
                Console.WriteLine(filme.ToString());
            }

            //Mostrando diretores do filme F
            Console.WriteLine("\nDiretores do filme " + f.Nome_filme);
            foreach (Diretor diretor in f.Diretores)
            {
                Console.WriteLine(diretor.ToString());
            }

            //Mostrando diretores do filme F
            Console.WriteLine("\nDiretores do filme " + f1.Nome_filme);
            foreach (Diretor diretor in f1.Diretores)
            {
                Console.WriteLine(diretor.ToString());
            }

            //getOne, Remove, Update, ShowAll...
            
        }

    }
}
