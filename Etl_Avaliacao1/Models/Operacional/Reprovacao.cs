using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl_Avaliacao1.Models.Operacional
{
    public class Reprovacao
    {
        public int Semestre { get; set; }
        public int IdDepartamento { get; set; }
        public int IdDisciplina { get; set; }
        public int IdCurso { get; set; }
        public bool Cotista { get; set; }
        public long CargaHoraria { get; set; }
        public int Nota { get; set; }
        public int Faltas { get; set; }
    }
}
