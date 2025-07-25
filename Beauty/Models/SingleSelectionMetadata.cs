namespace Beauty.Models
{
    public partial class SingleSelection : FormComponent
    {
        public SingleSelection Create(CustomContext customcontext,FormComponent formComponent)
        {
            SingleSelection ss = new SingleSelection();
            FormComponent ssc = (FormComponent)ss;
            ssc.Name = formComponent.Name;
            ss.FormId = formComponent.FormId;
            
            customcontext.Add(ssc);
            customcontext.SaveChanges();
            foreach(var kk in ElementSingleSelections)
            {
                kk.SingleSelectionId = ssc.Id;
                kk.Create(customcontext);
            }

            this.Id = ssc.Id;
            return this;
        }
    }
}
