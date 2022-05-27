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

        private List<string> Colunas { get; set; }
        private List<string> Parametros { get; set; }


        public Usuarios()
        {
            Parametros = new List<string>();
            Parametros.Add("''");
            Parametros.Add("@Nome");
            Parametros.Add("@Email");

            Colunas = new List<string>();
            Colunas.Add("IdUsuarios");
            Colunas.Add("Nome");
            Colunas.Add("Email");
        }

        public List<string> GetParametros()
        {
            return Parametros;
        }

        public List<string> GetColunas()
        {
            return Colunas;
        }
    }
}
