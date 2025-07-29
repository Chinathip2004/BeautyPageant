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

            EventCategorize ec = new EventCategorize();
            ec.CategoryId = this.CategoryId;
            context.Add(this);

            return this;
        }
    }
}
