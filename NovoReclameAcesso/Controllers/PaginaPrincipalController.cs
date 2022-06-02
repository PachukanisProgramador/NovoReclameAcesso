using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso.Controllers
{
    public class PaginaInicialController
    {
        private Dao.Dao<Models.Usuarios> usuarioDao;

        public PaginaInicialController()
        {
            usuarioDao = new Dao.Dao<Models.Usuarios>("usuarios");
        }

        public void MostrarTela()
        {
            //List<string> dados = new List<string>();

            //Console.WriteLine("Insira o nome");
            //dados.Add(Console.ReadLine());
            //Console.WriteLine("Insira o e-mail");
            //dados.Add(Console.ReadLine());

            //usuarioDao.ComandoInserir(dados, true);
            
            
            Models.Usuarios usuario = new Models.Usuarios();

            usuario = usuarioDao.ComandoSelectById(1);

            Console.WriteLine(usuario.IdUsuarios);
            Console.WriteLine(usuario.Nome);
            Console.WriteLine(usuario.Email);
        }


    }
}
