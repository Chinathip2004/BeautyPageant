using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.AppConfig;

namespace Beauty.Models
{
    public class DependentMetadata
    {
    }
    [ModelMetadataType(typeof(DependentMetadata))]
    public partial class Dependent
    {
        [NotMapped]
        public Component com { get; set; }
        public Dependent Create(CustomContext customcontext)
        {
            
            if(com != null)
            {
                Page page = new Page
                {
                    Containings = com.Containings
                };
                page.Create(customcontext);
                this.PageId = page.Id;
            }
            customcontext.Add(this);
            return this;
        }
    }
}
