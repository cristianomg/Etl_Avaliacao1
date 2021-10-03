using Etl_Avaliacao1.Models.Dimensional;
using Etl_Avaliacao1.Models.Operacional;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Etl_Avaliacao1
{
    public class Transformacao
    {
        public List<DmTempo> DmTempos { get; private set; } = new List<DmTempo>();
        public List<DmCurso> DmCursos { get; private set; } = new List<DmCurso>();
        public List<DmDepartamento> DmDepartamentos { get; private set; } = new List<DmDepartamento>();
        public List<DmDisciplina> DmDisciplinas { get; private set; } = new List<DmDisciplina>();
        public List<FtReprovacao> FtReprovacoes { get; private set; } = new List<FtReprovacao>();
        public Transformacao(Extracao extracao)
        {
            TransformarTempo(extracao.Tempos);
            TransformarCursos(extracao.Cursos);
            TransformarDepartamentos(extracao.Departamentos);
            TransformarDisciplinas(extracao.Disciplinas);
        }
        private void TransformarTempo(DataTable data)
        {
            Console.WriteLine("Iniciando transformação do tempo");
            var sw = new Stopwatch();
            sw.Start();
            foreach (DataRow d in data.Rows)
            {
                DmTempos.Add(new DmTempo((int)d[0]));
            }
            sw.Stop();

            Console.WriteLine($"Finalizando transformação do tempo" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        }
        private void TransformarCursos(DataTable data)
        {
            Console.WriteLine("Iniciando transformação dos cursos");
            var sw = new Stopwatch();
            sw.Start();
            foreach (DataRow d in data.Rows)
            {
                DmCursos.Add(new DmCurso((int)d[0], (string)d[1]));
            }
            sw.Stop();

            Console.WriteLine($"Finalizando transformação do tempo" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        }
        private void TransformarDepartamentos(DataTable data)
        {
            Console.WriteLine("Iniciando transformação dos departamentos");
            var sw = new Stopwatch();
            sw.Start();
            foreach (DataRow d in data.Rows)
            {
                DmDepartamentos.Add(new DmDepartamento((int)d[0], (string)d[1]));
            }
            sw.Stop();

            Console.WriteLine($"Finalizando transformação dos departamentos" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        }
        private void TransformarDisciplinas(DataTable data)
        {
            Console.WriteLine("Iniciando transformação das disciplinas");
            var sw = new Stopwatch();
            sw.Start();
            foreach (DataRow d in data.Rows)
            {
                DmDisciplinas.Add(new DmDisciplina((int)d[0], (string)d[1]));
            }
            sw.Stop();

            Console.WriteLine($"Finalizando transformação das disciplinas" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        }
        private void TransformarReprovacoes(DataTable data)
        {
            Console.WriteLine("Iniciando transformação das reprovações");
            var sw = new Stopwatch();
            sw.Start();
            var aux = new List<Reprovacao>();
            foreach (DataRow d in data.Rows)
            {
                aux.Add(new Reprovacao
                {
                    Semestre = (int) d[0],
                    IdDisciplina = (int) d[1],
                    IdDepartamento = (int) d[2],
                    IdCurso = (int) d[3],
                    Cotista = ((string) d[4]) == "S",
                    CargaHoraria = (long) d[5],
                    Nota = (int) d[6],
                    Faltas = (int) d[7]
                });
            }

            FtReprovacoes = aux.GroupBy(x => new
            {
                x.Semestre,
                x.IdCurso,
                x.IdDepartamento,
                x.IdDisciplina,
                x.Cotista
            })
            .Select(x => new FtReprovacao
            (
               x.Key.Semestre,
               x.Key.IdCurso,
               x.Key.IdDisciplina,
               x.Key.IdDepartamento,
               x.Key.Cotista,
               x.ToList()
            )).ToList();

            sw.Stop();

            Console.WriteLine($"Finalizando transformação das disciplinas" +
                              $" - Tempo de transformação: {sw.Elapsed.TotalSeconds} segundos.");
        }
    }
}
