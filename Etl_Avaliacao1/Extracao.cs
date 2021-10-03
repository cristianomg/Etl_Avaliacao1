using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics;

namespace Etl_Avaliacao1
{
    public class Extracao
    {
        public DataTable Tempos { get; private set; } = new DataTable();
        public DataTable Cursos { get; private set; } = new DataTable();
        public DataTable Departamentos { get; private set; } = new DataTable();
        public DataTable Disciplinas { get; private set; } = new DataTable();
        public DataTable Reprovacoes { get; private set; } = new DataTable();

        public Extracao(OracleConnection connection)
        {
            ExtrairTempo(connection);
            ExtrairCursos(connection);
            ExtrairDepartamentos(connection);
            ExtrairDisciplinas(connection);
            ExtrairReprovacoes(connection);
        }
        private void ExtrairTempo(OracleConnection connection)
        {
            Console.WriteLine("Iniciando extração do Tempo");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();

            OracleCommand commandSQL = connection.CreateCommand();

            commandSQL.CommandText = @"SELECT DISTINCT SEMESTRE
                                       FROM MATRICULAS ";

            commandSQL.CommandType = CommandType.Text;

            OracleDataReader dr = commandSQL.ExecuteReader();

            Tempos.Load(dr);
            connection.Close();
            sw.Stop();

            Console.WriteLine($"Finalizando extração do Tempo" +
                              $" - Total extraido: {Tempos.Rows.Count}" +
                              $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");

        }
        private void ExtrairCursos(OracleConnection connection)
        {
            Console.WriteLine("Iniciando extração dos cursos");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();

            OracleCommand commandSQL = connection.CreateCommand();

            commandSQL.CommandText = @"SELECT DISTINCT COD_CURSO, 
                                                       NOM_CURSO
                                       FROM CURSOS ";

            commandSQL.CommandType = CommandType.Text;

            OracleDataReader dr = commandSQL.ExecuteReader();

            Cursos.Load(dr);
            connection.Close();
            sw.Stop();

            Console.WriteLine($"Finalizando extração dos cursos" +
                              $" - Total extraido: {Cursos.Rows.Count}" +
                              $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");

        }
        private void ExtrairDepartamentos(OracleConnection connection)
        {
            Console.WriteLine("Iniciando extração dos departamentos");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();

            OracleCommand commandSQL = connection.CreateCommand();

            commandSQL.CommandText = @" SELECT DISTINCT COD_DPTO, 
                                                        NOME_DPTO 
                                        FROM DEPARTAMENTOS ";

            commandSQL.CommandType = CommandType.Text;

            OracleDataReader dr = commandSQL.ExecuteReader();

            Departamentos.Load(dr);
            connection.Close();
            sw.Stop();

            Console.WriteLine($"Finalizando extração dos departamentos" +
                              $" - Total extraido: {Disciplinas.Rows.Count}" +
                              $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");

        }
        private void ExtrairDisciplinas(OracleConnection connection)
        {
            Console.WriteLine("Iniciando extração das disciplinas");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();

            OracleCommand commandSQL = connection.CreateCommand();

            commandSQL.CommandText = @"SELECT DISTINCT COD_DISC, 
                                                       NOME_DISC 
                                       FROM DISCIPLINAS";

            commandSQL.CommandType = CommandType.Text;

            OracleDataReader dr = commandSQL.ExecuteReader();

            Disciplinas.Load(dr);
            connection.Close();
            sw.Stop();

            Console.WriteLine($"Finalizando extração das disciplinas" +
                              $" - Total extraido: {Disciplinas.Rows.Count}" +
                              $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");

        }
        private void ExtrairReprovacoes(OracleConnection connection)
        {
            Console.WriteLine("Iniciando extração das disciplinas");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();

            OracleCommand commandSQL = connection.CreateCommand();

            commandSQL.CommandText = @"SELECT SEMESTRE,
                                              D2.COD_DISC,
                                              D.COD_DPTO,
                                              A2.COD_CURSO,
                                              a2.COTISTA,
                                              CARGA_HORARIA,
                                              NOTA,
                                              FALTAS
                                       FROM MATRICULAS
                                       JOIN ALUNOS A2 on MATRICULAS.MAT_ALU = A2.MAT_ALU
                                       JOIN CURSOS C2 on C2.COD_CURSO = A2.CO/D_CURSO
                                       JOIN DEPARTAMENTOS D on D.COD_DPTO = C2.COD_DPTO
                                       JOIN DISCIPLINAS D2 on D2.COD_DISC = MATRICULAS.COD_DISC
";

            commandSQL.CommandType = CommandType.Text;

            OracleDataReader dr = commandSQL.ExecuteReader();

            Disciplinas.Load(dr);
            connection.Close();
            sw.Stop();

            Console.WriteLine($"Finalizando extração das reprovações" +
                              $" - Total extraido: {Reprovacoes.Rows.Count}" +
                              $" - Tempo de extração: {sw.Elapsed.TotalSeconds} segundos.");

        }
    }
}
