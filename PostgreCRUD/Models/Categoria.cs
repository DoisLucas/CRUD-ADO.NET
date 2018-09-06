namespace PostgreCRUD
{
    class Categoria
    {
        public int cod_categoria { get; set; }
        public string desc_categoria { get; set; }

        public Categoria()
        {

        }

        public Categoria(string desc_categoria)
        {
            this.cod_categoria = cod_categoria;
            this.desc_categoria = desc_categoria;
        }
                
    }
}
