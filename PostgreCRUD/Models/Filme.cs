using System;

namespace PostgreCRUD
{
    class Filme

    {
        public int cod_filme { get; set; }
        public string nome_filme { get; set; }
        public DateTime data { get; set; }
        public Categoria categoria { get; set; } 

        public Filme()
        {

        }

        public Filme(int cod_filme, string nome_filme, DateTime data, Categoria c)
        {
            this.cod_filme = cod_filme;
            this.nome_filme = nome_filme;
            this.data = data;
            this.categoria = c;
        }
                
    }
}
