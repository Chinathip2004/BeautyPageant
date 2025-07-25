using Microsoft.AspNetCore.Mvc;

namespace Beauty.Models
{
    public class ElementImageUploadWithImageContentMetadata
    {
    }
    [ModelMetadataType(typeof(ElementImageUploadWithImageContentMetadata))]
    public partial class ElementImageUploadWithImageContent
    {
        public ElementImageUploadWithImageContent Create(CustomContext context)
        {
            this.ImageUploadWithImageContentId = ImageUploadWithImageContentId;
            this.Value = Value;
            this.FileId = FileId;
            context.Add(this);

            return this;
        }
    }
}
