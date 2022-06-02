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
        private readonly MySql.Data.MySqlClient.MySqlConnection _conexao;
        private readonly MySql.Data.MySqlClient.MySqlCommand _comando;
        private MySql.Data.MySqlClient.MySqlDataReader _leitor;
        private List<string> _colunas;

        public LerDados(List<string> colunas, string stringConexao, string query)
        {
            _conexao = new MySql.Data.MySqlClient.MySqlConnection(stringConexao);
            _comando = new MySql.Data.MySqlClient.MySqlCommand(query, _conexao);
            _colunas = colunas;
        }

        public List<string> Ler()
        {
            List<string> resultado = new List<string>();

            _conexao.Open();

            try
            {
                using (_comando)
                {
                    _leitor = _comando.ExecuteReader();

                    while (_leitor.Read())
                    {
                        foreach (string coluna in _colunas)
                        {
                            resultado.Add(Convert.ToString(_leitor[$"{coluna}"].ToString()));
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
                _conexao.Close();
            }
        }
    }
}
