using Microsoft.AspNetCore.Mvc;

namespace Beauty.Models
{
    public class CategoryMetadata
    {
    }
    [ModelMetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {
        public Category Create(CustomContext customContext, DtoCategory dto)
        {
            Name = dto.Name;
            customContext.Categories.Add(this);

            return this;
        }
    }
}
