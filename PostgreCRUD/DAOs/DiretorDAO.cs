using ConsoleApp1;
using Npgsql;
using System;
using System.Collections.Generic;

namespace PostgreCRUD.DAOs
{
    class DiretorDAO
    {

        BancoConnection bd = new BancoConnection();

        //Remoção por id.
        public void Remove(int id)
        {
            try
            {
                bd.OpenConnection();

                String query = "DELETE FROM tab_diretor WHERE cod_diretor = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = id;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Diretor removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não existe esse Diretor!");
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

                String query = "SELECT * FROM tab_diretor";
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

        //Atualização passando como paramentro o ID e o novo atributo do Diretor.
        public void Update(int id, string new_nome_diretor)
        {
            try
            {
                bd.OpenConnection();

                String query = "UPDATE tab_diretor SET nome_diretor = :new_nome_diretor WHERE cod_diretor = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("new_nome_diretor", NpgsqlTypes.NpgsqlDbType.Varchar));
                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = new_nome_diretor;
                sql.Parameters[1].Value = id;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Diretor atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não existe esse diretor!");
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

        //Insert no banco recebendo como parametro um Diretor.
        public void Add(Diretor d)
        {
            try
            {
                bd.OpenConnection();

                String query = "INSERT INTO tab_diretor VALUES (:cod_diretor, :nome_diretor)";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("cod_diretor", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Parameters.Add(new NpgsqlParameter("nome_diretor", NpgsqlTypes.NpgsqlDbType.Varchar));
                sql.Prepare();

                sql.Parameters[0].Value = d.Cod_diretor;
                sql.Parameters[1].Value = d.Nome_diretor;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Diretor adicionado com sucesso!");

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

        //Método responsável por retornar um Diretor cujo ID seja igual o passado pelo parâmetro.
        public Diretor getOne(int id)
        {

            try
            {
                bd.OpenConnection();

                String query = "SELECT * FROM tab_diretor WHERE cod_categoria = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = id;

                NpgsqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {

                    Diretor d = new Diretor();
                    d.Cod_diretor = dr.GetInt32(0);
                    d.Nome_diretor = dr.GetString(1);

                    return d;
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

        //Método responsável por retornar todos os diretores fazendo um cast para objeto, retornando uma lista com todos os diretores do banco. 
        public List<Diretor> getAll()
        {

            List<Diretor> retorno = new List<Diretor>();

            try
            {
                bd.OpenConnection();

                String query = "SELECT * FROM tab_diretor";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);
                sql.Prepare();

                NpgsqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {

                    Diretor d = new Diretor();
                    d.Cod_diretor = dr.GetInt32(0);
                    d.Nome_diretor = dr.GetString(1);
                    retorno.Add(d);

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
