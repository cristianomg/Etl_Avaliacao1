namespace Etl_Avaliacao1.Models.Dimensional
{
    public class DmCurso
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public DmCurso(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}
