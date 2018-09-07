namespace PostgreCRUD
{
    class Diretor

    {
        public int Cod_diretor { get; set; }
        public string Nome_diretor { get; set; }

        public Diretor()
        {

        }

        public Diretor(int cod_diretor, string nome_diretor)
        {
            this.Cod_diretor = cod_diretor;
            this.Nome_diretor = nome_diretor;
        }
                
    }
}
