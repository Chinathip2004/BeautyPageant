using Microsoft.AspNetCore.Mvc;

namespace Beauty.Models
{
    public class ElementTextFieldMetadata
    {
    }
    [ModelMetadataType(typeof(ElementTextFieldMetadata))]

    public partial class ElementTextField
    {
        public ElementTextField Create (CustomContext custom)
        {
            this.TextFieldId = TextFieldId;
            this.Value = Value;
            custom.Add(this);

            return this;
        }
    }
}
