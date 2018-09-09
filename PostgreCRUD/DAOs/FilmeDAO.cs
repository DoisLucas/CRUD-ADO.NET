using ConsoleApp1;
using Npgsql;
using System;
using System.Collections.Generic;

namespace PostgreCRUD.DAOs
{
    class FilmeDAO
    {

        BancoConnection bd = new BancoConnection();

        //Remoção por id.
        public void Remove(int id)
        {
            try
            {
                bd.OpenConnection();

                String query = "DELETE FROM tab_filme WHERE cod_filme = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = id;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Filme removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não existe esse Filme!");
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                bd.CloseConnection();
            }

        }

        //Mostra todos os registro do banco diretamente, sem fazer cast para objeto.
        public void ShowAll()
        {
            try
            {
                bd.OpenConnection();

                String query = "SELECT * FROM tab_filme";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);
                sql.Prepare();

                NpgsqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {
                    //Listar todos os campos automatizado
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        Console.Write("{0} ", dr[i].ToString());
                    }

                    Console.Write("\n");
                }

            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                bd.CloseConnection();
            }

        }

        //Atualização passando como paramentro o ID e o novo atributo do Filme.
        public void Update(int id, string new_nome, DateTime new_data, Categoria new_categoria)
        {
            try
            {
                bd.OpenConnection();

                String query = "UPDATE tab_filme SET nome_filme = :new_nome and data_filme = :new_data and cod_categoria = :new_categoria WHERE cod_filme = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("new_nome", NpgsqlTypes.NpgsqlDbType.Varchar));
                sql.Parameters.Add(new NpgsqlParameter("new_data", NpgsqlTypes.NpgsqlDbType.Date));
                sql.Parameters.Add(new NpgsqlParameter("new_categoria", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = new_nome;
                sql.Parameters[1].Value = new_data;
                sql.Parameters[2].Value = new_categoria.Cod_categoria;
                sql.Parameters[3].Value = id;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Filme atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não existe esse filme!");
                }
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                bd.CloseConnection();
            }

        }

        //Insert no banco recebendo como parametro um Filme.
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

        //Método responsável por retornar um Filme com todos os seus diretores cujo ID seja igual o passado pelo parâmetro.
        public Filme getOne(int id)
        {

            try
            {
                bd.OpenConnection();

                String query = "SELECT * FROM tab_filme WHERE cod_filme = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = id;

                NpgsqlDataReader dr = sql.ExecuteReader();

                CategoriaDAO cdao = new CategoriaDAO();

                while (dr.Read())
                {

                    Filme f = new Filme();
                    f.Cod_filme = dr.GetInt32(0);
                    f.Nome_filme = dr.GetString(1);
                    f.Data = dr.GetDateTime(2);

                    //Como a classe filme tem um atributo do tipo Objeto Categoria,
                    //utilizo a instancia de CategoriaDAO pra pegar o objeto a partir do ID que o banco me retorna, com esse ID passo pro
                    //método getOne que retorna um Objeto do tipo Categoria.
                    f.Categoria = cdao.getOne(3);

                    return f;
                }

            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                bd.CloseConnection();
            }

            return null;
        }

        //Método responsável por retornar todos os filmes e seus diretores fazendo um cast para objeto, retornando uma lista com todos os filmes do banco. 
        public List<Filme> getAll()
        {

            List<Filme> retorno = new List<Filme>();

            try
            {
                bd.OpenConnection();

                String query = "SELECT * FROM tab_filme";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);
                sql.Prepare();

                NpgsqlDataReader dr = sql.ExecuteReader();

                CategoriaDAO cdao = new CategoriaDAO();

                while (dr.Read())
                {

                    Filme f = new Filme();
                    f.Cod_filme = dr.GetInt32(0);
                    f.Nome_filme = dr.GetString(1);
                    f.Data = dr.GetDateTime(2);

                    //Como a classe filme tem um atributo do tipo Objeto Categoria,
                    //utilizo a instancia de CategoriaDAO pra pegar o objeto a partir do ID que o banco me retorna, com esse ID passo pro
                    //método getOne que retorna um Objeto do tipo Categoria.
                    f.Categoria = cdao.getOne(3);

                    retorno.Add(f);
                }

            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                bd.CloseConnection();
            }

            return retorno;
        }


    }
}