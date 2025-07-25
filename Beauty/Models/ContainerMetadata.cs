using System.ComponentModel.DataAnnotations.Schema;

namespace Beauty.Models
{
    public partial class Container : Component
    {
        //[Column("ID")]
        //public int ContainerId { get; set; }

        [Column("Name")]
        public string? ContainerName { get; set; }
    }
    public partial class Page 
    {
        //[Column("ID")]
        //public int PageId { get; set; }
    }
    public partial class Section
    {
        //[Column("ID")]
        //public int SectionId { get; set; }
    }
}
