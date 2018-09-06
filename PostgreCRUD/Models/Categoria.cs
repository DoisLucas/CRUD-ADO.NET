using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreCRUD
{
    class Categoria
    {
        private int cod_categoria { get; set; }
        private string desc_categoria { get; set; }

        public Categoria()
        {

        }

        public Categoria(int cod_categoria, string desc_categoria)
        {
            this.cod_categoria = cod_categoria;
            this.desc_categoria = desc_categoria;
        }
                
    }
}
