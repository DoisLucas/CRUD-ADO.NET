using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreCRUD
{
    class Diretor

    {
        private int cod_diretor { get; set; }
        private string nome_diretor { get; set; }

        public Diretor()
        {

        }

        public Diretor(int cod_diretor, string nome_diretor)
        {
            this.cod_diretor = cod_diretor;
            this.nome_diretor = nome_diretor;
        }
                
    }
}
