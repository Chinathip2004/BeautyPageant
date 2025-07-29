using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace Beauty.Models
{
    public partial class Page : Container
    {

        //[Column("Id")]
        //public int? PageId { get; set; }

        public Page Create(CustomContext customcontext)
        {
            Page page = new Page();
            page.Name = "Page";
            Component Pc = (Component)page;
            Pc.Name = page.Name;
            customcontext.Add(Pc);
            customcontext.SaveChanges();
            this.Id = Pc.Id;


            foreach (Containing containing in this.Containings)
            {
                containing.ContainerId = Pc.Id;
                containing.Create(Pc, customcontext);

            }

            

            return this;
        }
    }
}
