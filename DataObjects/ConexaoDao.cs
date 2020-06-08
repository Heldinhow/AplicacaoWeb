using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public abstract class ConexaoDao : IDisposable
    {
        private static string strConexao = @"Server=tcp:helderdb.database.windows.net,1433;Initial Catalog=dbhelder;Persist Security Info=False;User ID=helroco;Password=gAXvW@Erur2K;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected SqlConnection Conexao
        {
            get
            {
                SqlConnection con = new SqlConnection(strConexao);
                con.Open();
                return con;
            }
        }       
        public void Dispose()
        {
            Conexao.Close();
            Conexao.Dispose();
        }
    }
}
