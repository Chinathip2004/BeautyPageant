using Microsoft.AspNetCore.Mvc;

namespace Beauty.Models
{
    public class ElementBirthDateMetadata
    {
    }
    [ModelMetadataType(typeof(ElementBirthDateMetadata))]
    public partial class ElementBirthDate
    {
        public ElementBirthDate Create (CustomContext customContext)
        {
            this.BirthDateId = BirthDateId;
            customContext.Add(this);

            return this;
        }
    }
}
