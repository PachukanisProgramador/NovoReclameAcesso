using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Factories
{
    public class TabelaFactory
    {

        public Interfaces.ITabela GetTabela(string nomeTabela)
        {
            switch (nomeTabela.ToLower())
            {
                case "usuarios":

                    return new Models.Usuarios();

                default:
                    return null;
            }
        }
    }
}
