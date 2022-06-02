using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Dao
{
    public class PreencherModels<T> : Interfaces.IPreencherModels where T: new()
    {
        public PreencherModels()
        {

        }

        public object SeletorDados(int loopColunas, string valor)
        {
            if (typeof(T) == typeof(Models.Usuarios))
            {
                 
                Models.Usuarios usuario = new Models.Usuarios();

                switch (loopColunas)
                {
                    case 0:
                        usuario.IdUsuarios = Convert.ToInt32(valor);
                        break;
                    case 1:
                        usuario.Nome = valor;
                        break;
                    case 2:
                        usuario.Email = valor;
                        break;
                    default:
                        break;
                }

                return usuario;
            }
            else
            {
                return default(T);
            }
        }
    }
}
