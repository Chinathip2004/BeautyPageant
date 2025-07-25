using Microsoft.AspNetCore.Mvc;

namespace Beauty.Models
{
    public class ElementImageUploadMetadata
    {
    }
    [ModelMetadataType(typeof(ElementImageUploadMetadata))]
    public partial class ElementImageUpload
    {
        public ElementImageUpload Create(CustomContext context)
        {
            this.ImageUploadId = ImageUploadId;
            this.Value = Value;
            context.Add(this);

            return this;
        }
    }
}
