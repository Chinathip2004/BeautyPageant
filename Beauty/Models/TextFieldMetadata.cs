namespace Beauty.Models
{
    public partial class TextField : FormComponent
    {
        public TextField Create(CustomContext context, FormComponent formcomponent)
        {
            TextField tf = new TextField();
            FormComponent tc = (FormComponent)tf;
            tc.Name = formcomponent.Name;
            tf.FormId = formcomponent.FormId;
            context.Add(tf);
            context.SaveChanges();

            foreach(var etf in ElementTextFields)
            {
                etf.TextFieldId = tc.Id;
                etf.Create(context);
                
            }
            this.Id = tc.Id;
            return this;
        }
    }
}
