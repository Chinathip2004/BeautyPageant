using Microsoft.AspNetCore.Mvc;

namespace Beauty.Models
{
    public class ElementDateMetadata
    {
    }
    [ModelMetadataType(typeof(ElementDateMetadata))]
    public partial class ElementDate
    {
        public ElementDate Create(CustomContext custom)
        {
            this.DateId = DateId;
            this.Value = Value;
            custom.Add(this);

            return this;
        }
    }
}
