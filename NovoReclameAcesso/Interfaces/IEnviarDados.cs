using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Interfaces
{
    public interface IEnviarDados<T, V>
    {
        T Inserir(V campos, bool auto_increment);
    }
}
