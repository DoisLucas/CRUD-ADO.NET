using ConsoleApp1;
using Npgsql;
using System;
using System.Collections.Generic;

namespace PostgreCRUD.DAOs
{
    class CategoriaDAO
    {

        BancoConnection bd = new BancoConnection();

        //Id

        public void Remove(int id)
        {
            try
            {
                bd.OpenConnection();

                String query = "DELETE FROM tab_categoria WHERE cod_categoria = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = id;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Categoria removida com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não existe essa categoria!");
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

        public void ShowAll()
        {
            try
            {
                bd.OpenConnection();

                String query = "SELECT * FROM tab_categoria";
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

        public void Update(int id, string new_desc_cateogoria)
        {
            try
            {
                bd.OpenConnection();

                String query = "UPDATE tab_categoria SET desc_categoria = :new_desc_categoria WHERE cod_categoria = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("new_desc_categoria", NpgsqlTypes.NpgsqlDbType.Varchar));
                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = new_desc_cateogoria;
                sql.Parameters[1].Value = id;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Categoria atualizada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não existe essa categoria!");
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

        //Objeto

        public void Add(Categoria c)
        {
            try
            {
                bd.OpenConnection();

                String query = "INSERT INTO tab_categoria VALUES (:cod_categoria, :desc_categoria)";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("cod_categoria", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Parameters.Add(new NpgsqlParameter("desc_categoria", NpgsqlTypes.NpgsqlDbType.Varchar));
                sql.Prepare();

                sql.Parameters[0].Value = c.Cod_categoria;
                sql.Parameters[1].Value = c.Desc_categoria;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Categoria adicionada com sucesso!");

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

        public Categoria getOne(int id)
        {

            try
            {
                bd.OpenConnection();

                String query = "SELECT * FROM tab_categoria WHERE cod_categoria = :id";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                sql.Prepare();

                sql.Parameters[0].Value = id;

                NpgsqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {

                    Categoria c = new Categoria();
                    c.Cod_categoria = dr.GetInt32(0);
                    c.Desc_categoria = dr.GetString(1);

                    return c;
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

        public List<Categoria> getAll()
        {

            List<Categoria> retorno = new List<Categoria>();

            try
            {
                bd.OpenConnection();

                String query = "SELECT * FROM tab_categoria";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);
                sql.Prepare();

                NpgsqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {

                    Categoria c = new Categoria();
                    c.Cod_categoria = dr.GetInt32(0);
                    c.Desc_categoria = dr.GetString(1);
                    retorno.Add(c);

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
