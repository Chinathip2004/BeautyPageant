namespace Beauty.Models
{
    public partial class Date : FormComponent
    {
        public Date Create(CustomContext context, FormComponent formComponent)
        {
            Date da = new Date();
            FormComponent df = (FormComponent)da;
            df.Name = formComponent.Name;
            da.FormId = formComponent.FormId;
            context.Add(df);
            context.SaveChanges();
            foreach(var dd in ElementDates)
            {
                dd.DateId = df.Id;
                dd.Create(context);
            }
            this.Id = df.Id;
            return this;
        }
    }
}
