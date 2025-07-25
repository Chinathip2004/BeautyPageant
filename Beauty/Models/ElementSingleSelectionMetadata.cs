using Microsoft.AspNetCore.Mvc;

namespace Beauty.Models
{
    public class ElementSingleSelectionMetadata
    {
        
    }
    [ModelMetadataType(typeof(ElementSingleSelectionMetadata))]
    public partial class ElementSingleSelection
    {
        public ElementSingleSelection Create(CustomContext customContext)
        {
            this.SingleSelectionId = SingleSelectionId;
            this.Value = Value;
            customContext.Add(this);
            return this;
        }
    }
}
