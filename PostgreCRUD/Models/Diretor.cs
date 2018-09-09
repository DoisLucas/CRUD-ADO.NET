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

    }
}
