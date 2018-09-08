namespace PostgreCRUD
{

    //Tabela associativa, relação entre Filme e Diretor N/N (Um filme pode ter varios diretores e um diretor pode dirigir varios filmes)
    class FilmeDiretor

    {
        public int Id { get; set; }
        public Filme Filme { get; set; }
        public Diretor Diretor { get; set; }

        public FilmeDiretor()
        {

        }

        public FilmeDiretor(int id, Filme filme, Diretor diretor)
        {
            this.Id = id;
            this.Filme = filme;
            this.Diretor = diretor;
        }

    }
}
