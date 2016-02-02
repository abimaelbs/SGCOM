namespace SGCOM.Models.Entities
{
    public class Estado
    {
        public Estado()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
