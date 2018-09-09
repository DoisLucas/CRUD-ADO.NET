using ConsoleApp1;
using Npgsql;
using System;
using System.Collections.Generic;

namespace PostgreCRUD.DAOs
{
    class FilmeDiretorDAO
    {

        BancoConnection bd = new BancoConnection();

        //Adição na tabela associativa, recebendo o ID do filme e do diretor respectivamente.
        public void Add(int id_filme, int id_diretor)
        {
            try
            {
                bd.OpenConnection();

                String query = "INSERT INTO tab_filme_diretor VALUES (:cod_filme, :cod_diretor)";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("cod_filme", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Parameters.Add(new NpgsqlParameter("cod_diretor", NpgsqlTypes.NpgsqlDbType.Integer));

                sql.Prepare();

                sql.Parameters[0].Value = id_filme;
                sql.Parameters[1].Value = id_diretor;

                int linhasAfetadas = sql.ExecuteNonQuery();

            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                bd.CloseConnection();
            }

        }

        //Remove todas relaçoes de um diretor a qualquer filme.
        public void removerPorDiretor(int id_diretor)
        {
            try
            {
                String query = "DELETE FROM tab_filme_diretor WHERE cod_diretor = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = id_diretor;
                int linhasAfetadas = sql.ExecuteNonQuery();

            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
            }
        }

        //Remove todas relaçoes de um filme a qualquer diretor.
        public void removerPorFilme(int id_filme)
        {
            try
            {
                String query = "DELETE FROM tab_filme_diretor WHERE cod_filme = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = id_filme;
                int linhasAfetadas = sql.ExecuteNonQuery();

            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
            }
        }

    }
}