using System;

namespace Etl_Avaliacao1.Models.Dimensional
{
    public class DmTempo
    {
        public int Id { get; private set; }
        public int Ano { get; private set; }
        public int Semestre { get; private set; }

        public DmTempo(int value)
        {
            var aux = value.ToString();
            
            this.Id = value;
            this.Ano = Convert.ToInt32(aux.Substring(0, 4));
            this.Semestre = Convert.ToInt32(aux.Substring(4, aux.Length-4));
        }
    }
}
