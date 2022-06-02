using NovoReclameAcesso.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Models
{
    public class Usuarios : Interfaces.ITabela
    {
        public int IdUsuarios { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        private List<string> _Colunas { get; set; }
        private List<string> _Parametros { get; set; }


        public Usuarios()
        {
            _Parametros = new List<string>();
            _Parametros.Add("''");
            _Parametros.Add("@Nome");
            _Parametros.Add("@Email");

            _Colunas = new List<string>();
            _Colunas.Add("IdUsuarios");
            _Colunas.Add("Nome");
            _Colunas.Add("Email");
        }

        public List<string> GetParametros()
        {
            return _Parametros;
        }

        public List<string> GetColunas()
        {
            return _Colunas;
        }
    }
}
