using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Dao
{
    public class Dao
    {
        private readonly string stringConexao;
        private readonly string nomeTabela;
        private string query;

        private Interfaces.IEnviarDados<int, System.Collections.IEnumerable> Escritor;
        private ILerDados Leitor;
        private Interfaces.ITabela tabela;

        public Dao(string nomeTabela)
        {
            this.nomeTabela = nomeTabela.ToLower();

            stringConexao = "Server=localhost;Database=reclameAcesso;Uid=root;Pwd=;";

            tabela = new Factories.TabelaFactory().GetTabela(this.nomeTabela);
        }

        public int ComandoInserir(IEnumerable<string> dadosTabela, bool autoIncrement)
        {
            if (nomeTabela == "usuarios")
            {
                query = $"INSERT INTO {nomeTabela} ({String.Join(",", tabela.GetColunas())}) VALUES({String.Join(",", tabela.GetParametros())}); SELECT LAST_INSERT_ID()";
            }
            else
            {
                query = $"INSERT INTO {nomeTabela} ({String.Join(",", tabela.GetColunas())}) VALUES({String.Join(",", tabela.GetParametros())})";
            }

            Escritor = new EnviarDados(stringConexao, query, tabela.GetParametros());

            return Escritor.Inserir(dadosTabela, autoIncrement);
        }

        public IEnumerable<string> ComandoSelect()
        {
            query = $"SELECT * FROM {nomeTabela}";

            Leitor = new LerDados(tabela.GetColunas(), stringConexao, query);

            var resultado = new List<string>();
            var resultadoLeitor = Leitor.Ler();
            try
            {
                foreach (string linha in Leitor.Ler())
                {
                    foreach (var coluna in tabela.GetColunas())
                    {
                        resultado.Add($"{coluna}: {linha}");
                    }
                }
                return resultado;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                throw e;
            }
        }
    }
}
