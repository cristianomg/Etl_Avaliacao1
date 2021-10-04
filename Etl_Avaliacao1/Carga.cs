using Etl_Avaliacao1.Models.Dimensional;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Etl_Avaliacao1
{
    public class Carga
    {
        public Carga(Transformacao transformacao, OracleConnection connection)
        {
            CarregarTempos(transformacao.DmTempos, connection);
            CarregarCursos(transformacao.DmCursos, connection);
            CarregarDepartamento(transformacao.DmDepartamentos, connection);
            CarregarDisciplinas(transformacao.DmDisciplinas, connection);
            CarregarReprovacoes(transformacao.FtReprovacoes, connection);

        }
        private void CarregarTempos(List<DmTempo> dm, OracleConnection connection)
        {
            Console.WriteLine("Iniciando carregamento dos Tempos");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();
            foreach (var item in dm)
            {
                OracleCommand commandSQL = connection.CreateCommand();
                try
                {

                    commandSQL.CommandText = $@"SELECT * FROM DM_TEMPO WHERE ID_TEMPO = {item.Id}";

                    commandSQL.CommandType = CommandType.Text;

                    OracleDataReader dr = commandSQL.ExecuteReader();

                    var data = new DataTable();
                    data.Load(dr);

                    var hasValue = data.Rows.Count > 0;

                    if (hasValue)
                    {
                        commandSQL.CommandText = $@"UPDATE DM_TEMPO 
                                                    SET ANO = {item.Ano},
                                                    SEMESTRE = {item.Semestre}
                                                    WHERE ID_TEMPO = {item.Id}";
                    }
                    else
                    {

                        commandSQL.CommandText = $@"INSERT INTO DM_TEMPO
                                                    (ID_TEMPO, SEMESTRE, ANO)
                                                    VALUES
                                                    ({item.Id}, {item.Semestre}, {item.Ano})";
                    }
                    commandSQL.CommandType = CommandType.Text;

                    commandSQL.ExecuteReader();
                }
                finally
                {
                    commandSQL.Clone();
                }

            }
            connection.Close();
            sw.Stop();
            Console.WriteLine($"Finalizando carregamento dos Tempos" +
                              $" - Tempo de carregamento: {sw.Elapsed.TotalSeconds}"); 
        }
        private void CarregarCursos(List<DmCurso> dm, OracleConnection connection)
        {
            Console.WriteLine("Iniciando carregamento dos cursos");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();
            foreach (var item in dm)
            {
                OracleCommand commandSQL = connection.CreateCommand();
                try
                {

                    commandSQL.CommandText = $@"SELECT * FROM DM_CURSO WHERE ID_CURSO = {item.Id}";

                    commandSQL.CommandType = CommandType.Text;

                    OracleDataReader dr = commandSQL.ExecuteReader();

                    var data = new DataTable();
                    data.Load(dr);

                    var hasValue = data.Rows.Count > 0;

                    if (hasValue)
                    {
                        commandSQL.CommandText = $@"UPDATE DM_CURSO 
                                                    SET NM_CURSO = '{item.Nome}'
                                                    WHERE ID_CURSO = {item.Id}";
                    }
                    else
                    {

                        commandSQL.CommandText = $@"INSERT INTO DM_CURSO
                                                    (ID_CURSO, NM_CURSO)
                                                    VALUES
                                                    ({item.Id}, '{item.Nome}')";
                    }
                    commandSQL.CommandType = CommandType.Text;

                    commandSQL.ExecuteReader();
                }
                finally
                {
                    commandSQL.Clone();
                }

            }
            connection.Close();
            sw.Stop();
            Console.WriteLine($"Finalizando carregamento dos cursos" +
                              $" - Tempo de carregamento: {sw.Elapsed.TotalSeconds}");
        }
        private void CarregarDepartamento(List<DmDepartamento> dm, OracleConnection connection)
        {
            Console.WriteLine("Iniciando carregamento dos departamentos");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();
            foreach (var item in dm)
            {
                OracleCommand commandSQL = connection.CreateCommand();
                try
                {

                    commandSQL.CommandText = $@"SELECT * FROM DM_DEPARTAMENTO WHERE ID_DEPARTAMENTO = {item.Id}";

                    commandSQL.CommandType = CommandType.Text;

                    OracleDataReader dr = commandSQL.ExecuteReader();

                    var data = new DataTable();
                    data.Load(dr);

                    var hasValue = data.Rows.Count > 0;

                    if (hasValue)
                    {
                        commandSQL.CommandText = $@"UPDATE DM_DEPARTAMENTO 
                                                    SET NM_DEPARTAMENTO = '{item.Nome}'
                                                    WHERE ID_DEPARTAMENTO = {item.Id}";
                    }
                    else
                    {

                        commandSQL.CommandText = $@"INSERT INTO DM_DEPARTAMENTO
                                                    (ID_DEPARTAMENTO, NM_DEPARTAMENTO)
                                                    VALUES
                                                    ({item.Id}, '{item.Nome}')";
                    }
                    commandSQL.CommandType = CommandType.Text;

                    commandSQL.ExecuteReader();
                }
                finally
                {
                    commandSQL.Clone();
                }

            }
            connection.Close();
            sw.Stop();
            Console.WriteLine($"Finalizando carregamento dos departamentos" +
                              $" - Tempo de carregamento: {sw.Elapsed.TotalSeconds}");
        }
        private void CarregarDisciplinas(List<DmDisciplina> dm, OracleConnection connection)
        {
            Console.WriteLine("Iniciando carregamento das disciplinas");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();
            foreach (var item in dm)
            {
                OracleCommand commandSQL = connection.CreateCommand();
                try
                {

                    commandSQL.CommandText = $@"SELECT * FROM DM_DISCIPLINA WHERE ID_DISCIPLINA = {item.Id}";

                    commandSQL.CommandType = CommandType.Text;

                    OracleDataReader dr = commandSQL.ExecuteReader();

                    var data = new DataTable();
                    data.Load(dr);

                    var hasValue = data.Rows.Count > 0;

                    if (hasValue)
                    {
                        commandSQL.CommandText = $@"UPDATE DM_DISCIPLINA 
                                                    SET NM_DISCIPLINA = '{item.Nome}'
                                                    WHERE ID_DISCIPLINA = {item.Id}";
                    }
                    else
                    {

                        commandSQL.CommandText = $@"INSERT INTO DM_DISCIPLINA
                                                    (ID_DISCIPLINA, NM_DISCIPLINA)
                                                    VALUES
                                                    ({item.Id}, '{item.Nome}')";
                    }
                    commandSQL.CommandType = CommandType.Text;

                    commandSQL.ExecuteReader();
                }
                finally
                {
                    commandSQL.Clone();
                }

            }
            connection.Close();
            sw.Stop();
            Console.WriteLine($"Finalizando carregamento das disciplinas" +
                              $" - Tempo de carregamento: {sw.Elapsed.TotalSeconds}");
        }
        private void CarregarReprovacoes(List<FtReprovacao> ft, OracleConnection connection)
        {
            Console.WriteLine("Iniciando carregamento das disciplinas");
            var sw = new Stopwatch();
            sw.Start();
            connection.Open();

            OracleCommand commandSQL = connection.CreateCommand();

            commandSQL.CommandText = $@"DELETE FROM FT_REPROVACAO";

            commandSQL.CommandType = CommandType.Text;

            commandSQL.ExecuteReader();

            foreach (var item in ft)
            {
                var ehCotista = item.EhCotista ? 1 : 0;
                commandSQL.CommandText = $@"INSERT INTO FT_REPROVACAO 
                                            (ID_TEMPO, ID_CURSO, ID_DEPARTAMENTO, ID_DISCIPLINA, EH_COTISTA, QTD_REPROVACAO, QTD_ALUNOS)
                                            VALUES
                                            ({item.IdTempo}, {item.IdCurso}, {item.IdDepartamento}, {item.IdDisciplina}, {ehCotista}, {item.QtdTotalReprovados}, {item.QtdTotal})";
                commandSQL.CommandType = CommandType.Text;

                commandSQL.ExecuteReader();
 
            }
            commandSQL.Clone();

            connection.Close();
            sw.Stop();
            Console.WriteLine($"Finalizando carregamento das disciplinas" +
                              $" - Tempo de carregamento: {sw.Elapsed.TotalSeconds}");
        }
    }
}
