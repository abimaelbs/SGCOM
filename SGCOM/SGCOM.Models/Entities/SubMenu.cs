namespace SGCOM.Models.Entities
{
    public class SubMenu
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string Titulo { get; set; }
        public string Link { get; set; }
        public int Ordem { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
