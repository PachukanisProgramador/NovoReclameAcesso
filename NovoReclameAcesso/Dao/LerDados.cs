using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Dao
{
    public interface ILerDados
    {
        List<string> Ler();
    }

    internal class LerDados : ILerDados
    {
        private readonly MySql.Data.MySqlClient.MySqlConnection conexao;
        private readonly MySql.Data.MySqlClient.MySqlCommand comando;
        private MySql.Data.MySqlClient.MySqlDataReader leitor;
        private List<string> colunas;

        public LerDados(List<string> colunas, string stringConexao, string query)
        {
            this.conexao = new MySql.Data.MySqlClient.MySqlConnection(stringConexao);
            this.comando = new MySql.Data.MySqlClient.MySqlCommand(query, conexao);
            this.colunas = colunas;
        }

        public List<string> Ler()
        {
            List<string> resultado = new List<string>();

            conexao.Open();

            try
            {
                using (comando)
                {
                    leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        foreach (string coluna in colunas)
                        {
                            resultado.Add(Convert.ToString(leitor[$"{coluna}"].ToString()));
                        }
                    }

                }
                return resultado;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                Console.WriteLine("Erro no comando Ler.");
                throw e;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
