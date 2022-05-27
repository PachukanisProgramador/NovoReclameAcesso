using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Interfaces
{
    public interface ITabela
    {
        List<string> GetParametros();
        List<string> GetColunas();
    }
}
