using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Dao
{
    public class Dao<T> where T : new()
    {
        private readonly string _stringConexao;
        private readonly string _nomeTabela;
        private string _query;

        private Interfaces.IEnviarDados<int, System.Collections.IEnumerable> _escritor;
        private ILerDados _leitor;
        private Interfaces.ITabela _tabela;
        private Interfaces.IPreencherModels _adicionar;

        public Dao(string nomeTabela)
        {
            _nomeTabela = nomeTabela.ToLower();

            _stringConexao = "Server=localhost;Database=reclameAcesso;Uid=root;Pwd=;";

            _tabela = new Factories.TabelaFactory().GetTabela(this._nomeTabela);

            _adicionar = new PreencherModels<T>();
        }

        public int ComandoInserir(IEnumerable<string> dadosTabela, bool autoIncrement)
        {
            if (_nomeTabela == "usuarios")
            {
                _query = $"INSERT INTO {_nomeTabela} ({String.Join(",", _tabela.GetColunas())}) VALUES({String.Join(",", _tabela.GetParametros())}); " +
                    $"SELECT LAST_INSERT_ID()";
            }
            else
            {
                _query = $"INSERT INTO {_nomeTabela} ({String.Join(",", _tabela.GetColunas())}) VALUES({String.Join(",", _tabela.GetParametros())})";
            }

            _escritor = new EnviarDados(_stringConexao, _query, _tabela.GetParametros());

            return _escritor.Inserir(dadosTabela, autoIncrement);
        }

        public List<T> ComandoSelect()
        {
            _query = $"SELECT * FROM {_nomeTabela}";

            _leitor = new LerDados(_tabela.GetColunas(), _stringConexao, _query);

            List<T> listaTabela = new List<T>();
            int loopColunas = 0;

            try
            {
                foreach (var valor in _leitor.Ler())
                {
                    object novaTabela = new Object();

                    if (loopColunas >= _tabela.GetColunas().Count)
                    {
                        loopColunas -= _tabela.GetColunas().Count; // Retorna a Zero
                    }

                    novaTabela = _adicionar.SeletorDados(loopColunas, valor);

                    loopColunas++;

                    if (loopColunas == _tabela.GetColunas().Count - 1)
                    {
                        listaTabela.Add((T)novaTabela);
                    }
                }

                return listaTabela;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                throw e;
            }
        }

        public List<T> ComandoSelectWhere(string parametro, string campo)
        {
            _query = $"SELECT * FROM {_nomeTabela} WHERE {parametro} = '{campo}'";

            _leitor = new LerDados(_tabela.GetColunas(), _stringConexao, _query);

            List<T> listaTabela = new List<T>();
            int loopColunas = 0;

            try
            {
                foreach (var valor in _leitor.Ler())
                {
                    object novaTabela = new Object();

                    if (loopColunas >= _tabela.GetColunas().Count)
                    {
                        loopColunas -= _tabela.GetColunas().Count; // Retorna a Zero
                    }

                    novaTabela = _adicionar.SeletorDados(loopColunas, valor);

                    loopColunas++;

                    if (loopColunas == _tabela.GetColunas().Count - 1)
                    {
                        listaTabela.Add((T)novaTabela);
                    }
                }

                return listaTabela;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                throw e;
            }
        }

        public T ComandoSelectById(int id)
        {
            _query = $"SELECT * FROM {_nomeTabela} WHERE {_tabela.GetColunas()[0]} = '{id}'";

            _leitor = new LerDados(_tabela.GetColunas(), _stringConexao, _query);

            int loopColunas = 0;

            T novaTabela = new T();

            try
            {
                foreach (var valor in _leitor.Ler())
                {

                    if (loopColunas >= _tabela.GetColunas().Count)
                    {
                        loopColunas -= _tabela.GetColunas().Count; // Retorna a Zero
                    }

                    novaTabela = (T)_adicionar.SeletorDados(loopColunas, valor);

                    loopColunas++;
                }

                return (T)novaTabela;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                throw e;
            }
        }
    }
}
