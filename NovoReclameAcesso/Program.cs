using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoReclameAcesso
{
    // 1. Pegar um dado de alguma fonte (Banco de Dados ou usuário);
    // 2. Manipular essa dado de alguma maneira (?);
    // 3. Escrever esse dado em alguma saída(Inserir no Banco de dados ou mostrar em tela);

    public class Program
    {
        static void Main(string[] args)
        {
            Controllers.PaginaInicialController metodo;
            try
            {
                metodo = new Controllers.PaginaInicialController();

                metodo.MostrarTela();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
