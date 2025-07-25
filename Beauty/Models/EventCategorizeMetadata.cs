using Microsoft.AspNetCore.Mvc;

namespace Beauty.Models
{
    public class EventCategorizeMetadata
    {
    }
    [ModelMetadataType(typeof(EventCategorizeMetadata))]

    public partial class EventCategorize
    {
        public EventCategorize Create(CustomContext context)
        {

            this.CategoryId = CategoryId;
            context.Add(this);

            return this;
        }
    }
}
