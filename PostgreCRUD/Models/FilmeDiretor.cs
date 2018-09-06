namespace PostgreCRUD
{

    //Tabela associativa, relação entre Filme e Diretor N/N (Um filme pode ter varios diretores e um diretor pode dirigir varios filmes)
    class FilmeDiretor

    {
        public int id { get; set; }
        public Filme filme { get; set; }
        public Diretor diretor { get; set; }

        public FilmeDiretor()
        {

        }

        public FilmeDiretor(int id, Filme filme, Diretor diretor)
        {
            this.id = id;
            this.filme = filme;
            this.diretor = diretor;
        }
                
    }
}
