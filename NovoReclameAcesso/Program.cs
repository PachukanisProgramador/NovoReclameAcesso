using MySql.Data.MySqlClient;
using NovoReclameAcesso.Factories;
using System;
using System.Collections;
using System.Collections.Generic;
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
            var dadosTabela = new List<string>();

            try
            {
                //Console.WriteLine("Insira o seu nome:");
                //dadosTabela.Add(Console.ReadLine());
                //Console.WriteLine("Insira o seu email:");
                //dadosTabela.Add(Console.ReadLine());

                Dao.Dao usuarioDao = new Dao.Dao("usuarios");

                //Console.WriteLine($"Id do usuário inserido: {usuarioDao.ComandoInserir(dadosTabela, true)}");

                Console.WriteLine("Tabela Usuarios");
                foreach (string linha in usuarioDao.ComandoSelect())
                {
                    Console.WriteLine(linha);
                }
                //Console.WriteLine(usuarioDao.ComandoSelect());

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
