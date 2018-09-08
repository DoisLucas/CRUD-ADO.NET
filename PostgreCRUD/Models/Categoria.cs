namespace PostgreCRUD
{
    class Categoria
    {
        public int Cod_categoria { get; set; }
        public string Desc_categoria { get; set; }

        public Categoria()
        {

        }

        public Categoria(int cod_categoria, string desc_categoria)
        {
            this.Cod_categoria = cod_categoria;
            this.Desc_categoria = desc_categoria;
        }

        public override string ToString()
        {
            return this.Cod_categoria + " - " + this.Desc_categoria;
        }
    }
}
