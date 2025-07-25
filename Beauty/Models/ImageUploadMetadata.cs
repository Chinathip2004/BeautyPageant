namespace Beauty.Models
{
    public partial class ImageUpload : FormComponent
    {
        public ImageUpload Create(CustomContext custom, FormComponent formcomponent)
        {
            ImageUpload im = new ImageUpload();
            FormComponent uf = (FormComponent)im;
            uf.Name = formcomponent.Name;
            im.FormId = formcomponent.FormId;
            custom.Add(uf);
            custom.SaveChanges();

            foreach(var ic in ElementImageUploads)
            {
                ic.ImageUploadId = uf.Id;
                ic.Create(custom);
            }
            this.Id = uf.Id;
            return this;
        }
    }
}
