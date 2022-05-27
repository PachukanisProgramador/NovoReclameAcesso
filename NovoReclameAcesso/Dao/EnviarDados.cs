using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Dao
{
    internal class EnviarDados : Interfaces.IEnviarDados<int, System.Collections.IEnumerable> // Control
    {
        private MySql.Data.MySqlClient.MySqlTransaction transacao;
        private readonly MySql.Data.MySqlClient.MySqlConnection conexao;
        private readonly MySql.Data.MySqlClient.MySqlCommand comando;
        private readonly List<string> parametros;

        public EnviarDados(string stringConexao, string query, IEnumerable<string> parametros)
        {
            this.parametros = new List<string>(parametros);
            this.conexao = new MySql.Data.MySqlClient.MySqlConnection(stringConexao);
            this.comando = new MySql.Data.MySqlClient.MySqlCommand(query, conexao);
        }

        public int Inserir(System.Collections.IEnumerable camposInsercao, bool autoIncrement)
        {
            int contador = 0;

            if (autoIncrement == true)
            {
                contador = 1;
            }

            conexao.Open();

            transacao = conexao.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            comando.Transaction = transacao;

            try
            {
                using (comando)
                {
                    foreach (var valor in (List<string>)camposInsercao)
                    {
                        comando.Parameters.AddWithValue($"{parametros[contador]}", valor);
                        contador++;
                    }
                    int resultado = Convert.ToInt32(comando.ExecuteScalar());
                    transacao.Commit();

                    return resultado;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Erro no comando inserir.");
                throw e;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
