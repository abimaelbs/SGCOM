namespace SGCOM.Models.Entities
{
    public class GrauParentesco
    {
        public int Id { get; set; }

        public string DescricaoParentesco { get; set; }

        public GrauParentesco()
        {

        }

        public override string ToString()
        {
            return this.DescricaoParentesco;
        }
    }
}
