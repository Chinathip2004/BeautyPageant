namespace Beauty.Models
{
    public partial class FormComponent
    {
        public FormComponent Create(CustomContext customContext,Component component)
        {
            this.FormId = component.Id;
            
            if(this.Name == "SingleSelection")
            {
                SingleSelection single = new SingleSelection
                {
                    ElementSingleSelections = this.SingleSelection.ElementSingleSelections
                };
                this.SingleSelection.Create(customContext,this);
                this.Id = SingleSelection.Id;

            }
            if(this.Name == "TextField")
            {
                TextField textField = new TextField
                {
                    ElementTextFields = this.TextField.ElementTextFields
                };
                this.TextField.Create(customContext,this);
                this.Id = TextField.Id;
            }
            if(this.Name == "Date")
            {
                Date date = new Date
                {
                    ElementDates = this.Date.ElementDates
                };
                this.Date.Create(customContext, this);
                this.Id = Date.Id;
            }
            if(this.Name == "BirthDate")
            {
                BirthDate bd = new BirthDate
                {
                    ElementBirthDates = this.BirthDate.ElementBirthDates
                };
                this.BirthDate.Create(customContext,this);
                this.Id = BirthDate.Id;
            }

            if(this.Name == "ImageUpload")
            {
                ImageUpload im = new ImageUpload
                {
                    ElementImageUploads = this.ImageUpload.ElementImageUploads
                };
                this.ImageUpload.Create(customContext, this);
                this.Id = ImageUpload.Id;
            }

            if(this.Name == "ImageUploadWithImageContent")
            {
                ImageUploadWithImageContent wc = new ImageUploadWithImageContent
                {
                    ElementImageUploadWithImageContents = this.ImageUploadWithImageContent.ElementImageUploadWithImageContents
                };
                this.ImageUploadWithImageContent.Create(customContext, this);
                this.Id = ImageUploadWithImageContent.Id;
            }

            if(this.Name == "ButtonForm")
            {
                ButtonForm bm = new ButtonForm();
                FormComponent bff = (FormComponent)bm;
                bm.FormId = component.Id;
                bff.Name = this.Name;
                bm.Value = this.ButtonForm.Value;
                bm.Url = this.ButtonForm.Url;
                bm.IsUrl = this.ButtonForm.IsUrl;

                customContext.Add(bff);
                customContext.SaveChanges();


                
                this.Id = bff.Id;


            }

            
            return this;
        }
    }
}
