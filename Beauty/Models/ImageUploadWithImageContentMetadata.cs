namespace Beauty.Models
{
    public partial class ImageUploadWithImageContent : FormComponent
    {
        public ImageUploadWithImageContent Create(CustomContext custom,FormComponent formComponent)
        {
            ImageUploadWithImageContent iwc = new ImageUploadWithImageContent();
            FormComponent ifc = (FormComponent)iwc;
            ifc.Name = formComponent.Name;
            iwc.FormId = formComponent.FormId;
            custom.Add(ifc);
            custom.SaveChanges();

            foreach(var www in ElementImageUploadWithImageContents)
            {
                www.ImageUploadWithImageContentId = ifc.Id;
                www.Create(custom);
            }
            this.Id = ifc.Id;
            return this;
        }
    }
}
