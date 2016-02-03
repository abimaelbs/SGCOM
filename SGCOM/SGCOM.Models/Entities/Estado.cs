namespace SGCOM.Models.Entities
{
    public class Estado
    {        
        public int Id { get; set; }
        public string Nome { get; set; }

        public Estado()
        {

        }
        public override string ToString()
        {
            return this.Nome;
        }
    }
}
