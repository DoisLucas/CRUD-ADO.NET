using System;

namespace PostgreCRUD
{
    class Filme

    {
        public int Cod_filme { get; set; }
        public string Nome_filme { get; set; }
        public DateTime Data { get; set; }
        public Categoria Categoria { get; set; }

        public Filme()
        {

        }

        public Filme(int cod_filme, string nome_filme, DateTime data, Categoria c)
        {
            this.Cod_filme = cod_filme;
            this.Nome_filme = nome_filme;
            this.Data = data;
            this.Categoria = c;
        }

    }
}
