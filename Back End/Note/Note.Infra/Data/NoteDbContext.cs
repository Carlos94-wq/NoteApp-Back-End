using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.Infra.Data
{
    public class NoteDbContext
    {
        private readonly string _Cofiguration;
        public NoteDbContext( IConfiguration configuration)
        {
            this._Cofiguration = configuration.GetConnectionString("DBNOTE");
        }

        public async Task<SqlDataReader> ExecuteReader(string sentencia, SqlParameter[] Parametro = null)
        {

            SqlConnection Con = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try //Clausupa tray para detener cualquier error
            {
                Con.ConnectionString = _Cofiguration;
                await Con.OpenAsync();

                comando.Connection = Con;
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = sentencia;

                if (Parametro != null)
                {
                    comando.Parameters.AddRange(Parametro.ToArray());
                }

                SqlDataReader Dr = await comando.ExecuteReaderAsync(CommandBehavior.CloseConnection);

                return Dr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> ExecuteNonQuery(string sentencia, SqlParameter[] Parametro = null)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

            try
            {
                con.ConnectionString = _Cofiguration;
                await con.OpenAsync();

                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sentencia;

                if (Parametro != null)
                {
                    cmd.Parameters.AddRange(Parametro.ToArray());
                }

                return await cmd.ExecuteNonQueryAsync();
            }
            catch (SqlException e)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
