namespace Beauty.Models
{
    public partial class BirthDate : FormComponent
    {
        public BirthDate Create(CustomContext context, FormComponent formcomponent)
        {
            BirthDate bd = new BirthDate();
            FormComponent bf = (FormComponent)bd;
            bf.Name = formcomponent.Name;
            bd.FormId = formcomponent.FormId;
            context.Add(bf);
            context.SaveChanges();

            foreach(var bb in ElementBirthDates)
            {
                bb.BirthDateId = bf.Id;
                bb.Create(context);
            }
            
            this.Id = bf.Id;
            return this;
        }
    }
}
