using Oracle.ManagedDataAccess.Client;
using System;

namespace Etl_Avaliacao1
{
    class Program
    {
        static string _conexaoBancoOperacional = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = XE)));User ID=avl1;Password=avl1;";
        static string _conexaoBancoDimensional = "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = XE)));User ID=dw_avl1;Password=dw_avl1;";
        static void Main(string[] args)
        {
            using var conexaoOperacional = new OracleConnection(_conexaoBancoOperacional);
            using var conexaoDimensional = new OracleConnection(_conexaoBancoDimensional);

            var extracao = new Extracao(conexaoOperacional);

            var trasformacao = new Transformacao(extracao);

            var carga = new Carga(trasformacao, conexaoDimensional);

            Console.WriteLine("Finalizado o ETL");
        }
    }
}
