using Microsoft.AspNetCore.Mvc;

namespace Beauty.Models
{
    public class EventMetadata
    {
    }
    [ModelMetadataType(typeof(EventMetadata))]
    public partial class Event
    {
        public Event Create(CustomContext customcontext)
        {
            foreach(EventCategorize ec in this.EventCategorizes)
            {

            }

            foreach(Dependent dependent in this.Dependents)
            {
                dependent.Create(customcontext);
            }
            customcontext.Add(this);
            return this;
        }
    }
}
