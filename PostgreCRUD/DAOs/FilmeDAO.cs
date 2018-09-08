using ConsoleApp1;
using Npgsql;
using System;

namespace PostgreCRUD.DAOs
{
    class FilmeDAO
    {
        BancoConnection bd = new BancoConnection();

        public void Add(Filme f)
        {
            try
            {
                bd.OpenConnection();

                String query = "INSERT INTO tab_filme VALUES (:cod_filme, :nome_filme, :data_filme, :cod_categoria)";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("cod_filme", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Parameters.Add(new NpgsqlParameter("nome_filme", NpgsqlTypes.NpgsqlDbType.Varchar));
                sql.Parameters.Add(new NpgsqlParameter("data_filme", NpgsqlTypes.NpgsqlDbType.Date));
                sql.Parameters.Add(new NpgsqlParameter("cod_categoria", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = f.Cod_filme;
                sql.Parameters[1].Value = f.Nome_filme;
                sql.Parameters[2].Value = f.Data;
                sql.Parameters[3].Value = f.Categoria.Cod_categoria;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Filme adicionado com sucesso!");

                }

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
    }
}
