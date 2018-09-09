using PostgreCRUD.DAOs;
using System.Collections.Generic;

namespace PostgreCRUD
{
    class Diretor

    {
        public int Cod_diretor { get; set; }
        public string Nome_diretor { get; set; }
        public List<Filme> filmes { get; set; }

        public Diretor()
        {
            this.filmes = new List<Filme>();
        }

        public Diretor(int cod_diretor, string nome_diretor)
        {
            this.Cod_diretor = cod_diretor;
            this.Nome_diretor = nome_diretor;
            this.filmes = new List<Filme>();
        }

        public override string ToString()
        {
            return this.Cod_diretor + " - " + this.Nome_diretor;
        }

        //Adição cruzada, adicionando diretor no filme e filme no diretor.
        public void AddFilme(Filme f)
        {
            this.filmes.Add(f);
            f.Diretores.Add(this);

            FilmeDiretorDAO fddao = new FilmeDiretorDAO();
            fddao.Add(f.Cod_filme, this.Cod_diretor);

        }

        public List<Filme> GetFilmes()
        {
            DiretorDAO ddao = new DiretorDAO();
            return ddao.getFilmes(this.Cod_diretor);
        }


    }
}
