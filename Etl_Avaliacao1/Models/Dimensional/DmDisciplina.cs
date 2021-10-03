namespace Etl_Avaliacao1.Models.Dimensional
{
    public class DmDisciplina
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public DmDisciplina(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}
