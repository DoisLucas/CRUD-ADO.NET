using PostgreCRUD.DAOs;
using System;
using System.Collections.Generic;

namespace PostgreCRUD
{
    class Filme

    {
        public int Cod_filme { get; set; }
        public string Nome_filme { get; set; }
        public DateTime Data { get; set; }
        public Categoria Categoria { get; set; }
        public List<Diretor> Diretores { get; set; }

        public Filme()
        {
            this.Diretores = new List<Diretor>();
        }

        public Filme(int cod_filme, string nome_filme, DateTime data, Categoria c)
        {
            this.Cod_filme = cod_filme;
            this.Nome_filme = nome_filme;
            this.Data = data;
            this.Categoria = c;
            this.Diretores = new List<Diretor>();
        }

        public override string ToString()
        {
            return this.Cod_filme + " - " + this.Nome_filme + " - " + this.Data.ToString() + " - " + this.Categoria.Desc_categoria;
        }

        //Adição cruzada, adicionando diretor no filme e filme no diretor.
        public void AddDiretor(Diretor d)
        {
            this.Diretores.Add(d);
            d.filmes.Add(this);

            FilmeDiretorDAO fddao = new FilmeDiretorDAO();
            fddao.Add(this.Cod_filme, d.Cod_diretor);

        }

        public List<Diretor> GetDiretores()
        {
            FilmeDAO fdao = new FilmeDAO();
            return fdao.getDiretores(this.Cod_filme);
        }

    }
}
