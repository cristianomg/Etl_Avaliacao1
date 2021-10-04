using Etl_Avaliacao1.Models.Operacional;
using System.Collections.Generic;
using System.Linq;

namespace Etl_Avaliacao1.Models.Dimensional
{
    public class FtReprovacao
    {
        public int IdTempo { get; private set; }
        public int IdCurso { get; private set; }
        public int IdDisciplina { get; private set; }
        public int IdDepartamento { get; private set; }
        public bool EhCotista { get; private set; }
        public int QtdTotalReprovados { get; private set; }
        public int QtdTotal { get; private set; }

        public FtReprovacao(int idTempo, int idCurso,
                            int idDisciplina, int idDepartamento,
                            bool ehCotista, List<Reprovacao> group)
        {
            this.IdTempo = idTempo;
            this.IdCurso = idCurso;
            this.IdDisciplina = idDisciplina;
            this.IdDepartamento = idDepartamento;
            this.EhCotista = ehCotista;

            this.QtdTotalReprovados = CalcularTotalAlunosReprovados(group);
            this.QtdTotal = CalcularTotalAlunos(group);
        }

        private int CalcularTotalAlunos(List<Reprovacao> data)
        {
            return data.Count();
        }
        private int CalcularTotalAlunosReprovados(List<Reprovacao> data)
        {
            return data.Count(x =>
            {
                var aprovadoPorNota = x.Nota >= 7;

                var aprovadoPorFalta = (x.Faltas / x.CargaHoraria) * 100 < 25;

                return !(aprovadoPorNota && aprovadoPorFalta);
            });
        }
    }
}
