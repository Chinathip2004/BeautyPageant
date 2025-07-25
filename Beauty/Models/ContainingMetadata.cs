using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Beauty.Models
{
    public partial class Containing
    {
        public Containing Create(Component component, CustomContext customContext)
        {
            
            Component component1 = this.Component;
            component1.Create(customContext);

            Containing i1 = new Containing();
            i1.ContainerId = component.Id;
            i1.ComponentId = component1.Id;
            customContext.Add(i1);
            customContext.SaveChanges();
            

            if (component1.Name == "Section")
            {
                foreach(Containing a in component1.Containings)
                {
                    a.Create(component1, customContext);
                }
            }

            if (component1.Name == "Form")
            {
                CopyForm copy = new CopyForm();
                copy.FormId = component1.Id;
                customContext.Add(copy);
                customContext.SaveChanges();
                foreach (FormComponent o in component1.Form.FormComponents)
                {
                    o.FormId = component1.Id;

                    o.Create(customContext, component1);
                    o.FormId = component1.Id;
                    CopyFormComponent cfc = new CopyFormComponent();
                    cfc.CopyFormId = copy.Id;
                    cfc.FormComponentId = o.Id;
                    cfc.Name = o.Name;
                    customContext.Add(cfc);
                    customContext.SaveChanges();

                }
            }
            

            return this;
        }

        public Containing GetById(BeautyDbContext dbContext, Component component)
        {
            component = dbContext.Components.Where(c => c.Id == this.ComponentId).FirstOrDefault();
            
            

            if(component.Name == "Section")
            {
                
            }
            if(component.Name == "Banner")
            {
               
            }

            return this;
        }
    }
    
}
