namespace Etl_Avaliacao1.Models.Dimensional
{
    public class DmDepartamento
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DmDepartamento(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}
