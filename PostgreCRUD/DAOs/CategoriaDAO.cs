using ConsoleApp1;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreCRUD.DAOs
{
    class CategoriaDAO
    {

        BancoConnection bd = new BancoConnection();

        public void add_categoria(Categoria c)
        {
            bd.OpenConnection();
          
            try
            {
                String query = "INSERT INTO tab_categoria VALUES (DEFAULT, :desc_categoria)";
                Npgsql.NpgsqlCommand sql = new Npgsql.NpgsqlCommand(query, bd.getConnection);

                sql.Parameters.Add(new NpgsqlParameter("desc_categoria", NpgsqlTypes.NpgsqlDbType.Varchar));
                sql.Prepare();

                sql.Parameters[0].Value = c.desc_categoria;
                int linhasAfetadas = sql.ExecuteNonQuery();

                if (Convert.ToBoolean(linhasAfetadas))
                {
                    Console.WriteLine("Categoria adicionada com sucesso!");

                }
                

            }catch(NpgsqlException ex)
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
