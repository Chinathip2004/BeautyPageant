using Beauty.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client.Kerberos;
using Newtonsoft.Json;

namespace Beauty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly CustomContext _context;

        public ComponentController(CustomContext context)
        {
            _context = context;
        }
        //[HttpGet]
        [HttpPost]
        public ActionResult Create([FromBody] string Hello)
        {

            Event ev = JsonConvert.DeserializeObject<Event>(Hello);

            ev.Create(_context);
            _context.SaveChanges();


            return Ok();
        }

        [HttpGet("GetById")]
        public ActionResult GetById(int? id)
        {
            var ev = _context.Events.Where(w => w.Id == id).First();
            ev.Dependents = _context.Dependents.Where(d => d.EventId == id).ToList();
            ev.EventCategorizes = _context.EventCategorizes.Where(d => d.EventId == id).ToList();

            foreach(var d in ev.EventCategorizes)
            {
                d.Category = _context.Categories.Where(c => c.Id == d.CategoryId).FirstOrDefault();
            }

            foreach (var e in ev.Dependents)
            {

                e.Page = _context.Pages.Where(c => c.Id == e.PageId).FirstOrDefault();
                e.Page.Containings = _context.Containings.Where(c => c.ContainerId == e.PageId).ToList();
                foreach (var c in e.Page.Containings)
                {

                    c.Component = _context.Components.Where(a => a.Id == c.ComponentId).FirstOrDefault();

                    if (c.Component.Name == "Section")
                    {
                        LoadComponent(c.Component);
                    }
                    if (c.Component.Name == "Banner")
                    {
                        Banner banner = _context.Banners.Include(b => b.File).FirstOrDefault();
                        if (banner.File != null)
                        {
                            string filename = Path.GetFileName(banner.File.FileName);
                            banner.File.FilePath = $"https://localhost:5049/uploads/{filename}";
                        }
                    }
                    if (c.Component.Name == "ImageWithCaption")
                    {
                        ImageWithCaption ic = _context.ImageWithCaptions.Include(i => i.File).Where(p => p.Id == c.ComponentId).FirstOrDefault();
                        if (ic.File != null)
                        {
                            string filename = Path.GetFileName(ic.File.FileName);
                            ic.File.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                    }
                    if (c.Component.Name == "ImageDescription")
                    {
                        ImageDescription idt = _context.ImageDescriptions.Include(i => i.File).Where(a => a.Id == c.ComponentId).FirstOrDefault();
                        if (idt.File != null)
                        {
                            string filename = Path.GetFileName(idt.File.FileName);
                            idt.File.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                    }
                    if (c.Component.Name == "GridTwoColumn")
                    {
                        GridTwoColumn gt = _context.GridTwoColumns.Include(g => g.FileIdLeftNavigation)
                            .Include(gc => gc.FileIdRightNavigation)
                            .Where(a => a.Id == c.ComponentId).FirstOrDefault();
                        if (gt.FileIdLeftNavigation != null)
                        {
                            string filename = Path.GetFileName(gt.FileIdLeftNavigation.FileName);
                            gt.FileIdLeftNavigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                        if (c.Component.GridTwoColumn.FileIdRightNavigation != null)
                        {
                            string filename = Path.GetFileName(c.Component.GridTwoColumn.FileIdRightNavigation.FileName);
                            c.Component.GridTwoColumn.FileIdRightNavigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                    }
                    if (c.Component.Name == "GridFourImage")
                    {
                        GridFourImage gridFourImage = _context.GridFourImages.Include(g => g.FileId1Navigation).Include(g2 => g2.FileId2Navigation).Include(g3 => g3.FileId3Navigation).Include(g4 => g4.FileId4Navigation)
                            .Where(gf => gf.Id == c.ComponentId).FirstOrDefault();
                        if (gridFourImage.FileId1Navigation != null)
                        {
                            string filename = Path.GetFileName(gridFourImage.FileId1Navigation.FileName);
                            gridFourImage.FileId1Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                        if (gridFourImage.FileId2Navigation != null)
                        {
                            string filename = Path.GetFileName(gridFourImage.FileId2Navigation.FileName);
                            gridFourImage.FileId2Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                        if (gridFourImage.FileId3Navigation != null)
                        {
                            string filename = Path.GetFileName(gridFourImage.FileId3Navigation.FileName);
                            gridFourImage.FileId3Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                        if (gridFourImage.FileId4Navigation != null)
                        {
                            string filename = Path.GetFileName(gridFourImage.FileId4Navigation.FileName);
                            gridFourImage.FileId4Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                    }
                    if (c.Component.Name == "OneTopicImageCaptionButton")
                    {
                        OneTopicImageCaptionButton ob = _context.OneTopicImageCaptionButtons.Include(o => o.File).Where(a => a.Id == c.ComponentId).FirstOrDefault();
                        if (ob.File != null)
                        {
                            string filename = Path.GetFileName(ob.File.FileName);
                            ob.File.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                    }
                    if (c.Component.Name == "TwoTableTopicImageCaptionButton")
                    {
                        TwoTableTopicImageCaptionButton ttb = _context.TwoTableTopicImageCaptionButtons.Include(t => t.FileId1Navigation)
                            .Include(tt => tt.FileId2Navigation)
                            .Where(a => a.Id == c.ComponentId).FirstOrDefault();
                        if (ttb.FileId1Navigation != null)
                        {
                            string filename = Path.GetFileName(ttb.FileId1Navigation.FileName);
                            ttb.FileId1Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                        if (ttb.FileId2Navigation != null)
                        {
                            string filename = Path.GetFileName(ttb.FileId2Navigation.FileName);
                            ttb.FileId2Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                    }
                    if (c.Component.Name == "Sale")
                    {
                        Sale sale = _context.Sales.Include(s => s.FileId1Navigation).Include(ss => ss.FileId2Navigation).Where(a => a.Id == c.ComponentId).FirstOrDefault();
                        if (sale.FileId1Navigation != null)
                        {
                            string filename = Path.GetFileName(sale.FileId1Navigation.FileName);
                            sale.FileId1Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                        if (sale.FileId2Navigation != null)
                        {
                            string filename = Path.GetFileName(sale.FileId2Navigation.FileName);
                            sale.FileId2Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                    }
                    if (c.Component.Name == "About")
                    {
                        About about = _context.Abouts.Include(a => a.FileId1Navigation)
                            .Include(a1 => a1.FileIdLeftNavigation)
                            .Include(a2 => a2.FileIdRightNavigation)
                            .Where(ab => ab.Id == c.ComponentId).FirstOrDefault();
                        if (about.FileId1Navigation != null)
                        {
                            string filename = Path.GetFileName(about.FileId1Navigation.FileName);
                            about.FileId1Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                        if (about.FileIdLeftNavigation != null)
                        {
                            string filename = Path.GetFileName(about.FileIdLeftNavigation.FileName);
                            about.FileIdLeftNavigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                        if (about.FileIdRightNavigation != null)
                        {
                            string filename = Path.GetFileName(about.FileIdRightNavigation.FileName);
                            about.FileIdRightNavigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                        }
                    }

                    else if (c.Component.Name == "Form")
                    {
                        c.Component.Form.FormComponents = _context.FormComponents.Where(f => f.Form.Id == c.Component.Id).ToList();

                        foreach (var fc in c.Component.Form.FormComponents)
                        {
                            if (fc.Name == "SingleSelection")
                            {
                                fc.SingleSelection.ElementSingleSelections = _context.ElementSingleSelections.Where(e => e.SingleSelectionId == fc.Id).ToList();
                            }
                             if (fc.Name == "TextField")
                            {
                                fc.TextField.ElementTextFields = _context.ElementTextFields.Where(t => t.TextFieldId == fc.Id).ToList();
                            }
                             if (fc.Name == "Date")
                            {
                                fc.Date.ElementDates = _context.ElementDates.Where(d => d.DateId == fc.Id).ToList();
                            }
                             if (fc.Name == "BirthDate")
                            {
                                fc.BirthDate.ElementBirthDates = _context.ElementBirthDates.Where(bd => bd.BirthDateId == fc.Id).ToList();
                            }
                             if (fc.Name == "ImageUpload")
                            {
                                fc.ImageUpload.ElementImageUploads = _context.ElementImageUploads.Where(im => im.ImageUploadId == fc.Id).ToList();
                            }
                             if (fc.Name == "ImageUploadWithImageContent")
                            {
                                fc.ImageUploadWithImageContent.ElementImageUploadWithImageContents = _context.ElementImageUploadWithImageContents.Include(d => d.File).Where(ic => ic.ImageUploadWithImageContentId == fc.Id).ToList();
                                foreach (var d in fc.ImageUploadWithImageContent.ElementImageUploadWithImageContents)
                                {
                                    
                                    if (d.File != null)
                                    {
                                        string filename = Path.GetFileName(d.File.FileName);
                                        d.File.FilePath = $"https://localhost:7281/uploads/{filename}";
                                    }
                                }
                            }
                            c.Component.Form.CopyForms = _context.CopyForms.Where(cf => cf.FormId == c.ComponentId).ToList();

                            foreach (var p in c.Component.Form.CopyForms)
                            {
                                p.CopyFormComponents = _context.CopyFormComponents.Where(cfc => cfc.CopyFormId == p.Id).ToList();
                            }

                        }
                    }
                }



            }
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var json = JsonConvert.SerializeObject(ev, settings);

            return Ok(json);
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var ev = _context.Events.Where(e => e.IsFavorite == false)
                .Include(a => a.Dependents.Where(a => a.PageId != null)).ToList();
            return Ok(ev);
        }



        [HttpDelete]
        public IActionResult Delete(int? id)
        {


            return Ok();
        }


        private void LoadComponent(Component component)
        {
            if (component.Name == "Section")
            {
                Section section = _context.Sections.Where(s => s.Id == component.Id).FirstOrDefault();

                if (section != null)
                {
                    section.Containings = _context.Containings.Where(r => r.ContainerId == component.Id).ToList();

                    foreach (var w in section.Containings)
                    {
                        w.Component = _context.Components.Where(c => c.Id == w.ComponentId).FirstOrDefault();

                        if (w.Component.Name == "Section")
                        {
                            LoadComponent(w.Component);
                        }
                        if (w.Component.Name == "Banner")
                        {
                            Banner banner = _context.Banners.Include(b => b.File).Where(a => a.Id == w.ComponentId).FirstOrDefault();
                            if (banner.File != null)
                            {
                                string filename = Path.GetFileName(banner.File.FileName);
                                banner.File.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                        }
                        if(w.Component.Name == "ImageWithCaption")
                        {
                            ImageWithCaption ic = _context.ImageWithCaptions.Include(i => i.File).Where(p => p.Id == w.ComponentId).FirstOrDefault();
                            if(ic.File != null)
                            {
                                string filename = Path.GetFileName(ic.File.FileName);
                                ic.File.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                        }
                        if(w.Component.Name == "ImageDescription")
                        {
                            ImageDescription idt = _context.ImageDescriptions.Include(i => i.File).Where(a => a.Id == w.ComponentId).FirstOrDefault();
                            if (idt.File != null)
                            {
                                string filename = Path.GetFileName(idt.File.FileName);
                                idt.File.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                        }
                        if(w.Component.Name == "GridTwoColumn")
                        {
                            GridTwoColumn gt = _context.GridTwoColumns.Include(g => g.FileIdLeftNavigation)
                                .Include(gc => gc.FileIdRightNavigation)
                                .Where(a => a.Id == w.ComponentId).FirstOrDefault();
                            if (gt.FileIdLeftNavigation != null)
                            {
                                string filename = Path.GetFileName(gt.FileIdLeftNavigation.FileName);
                                gt.FileIdLeftNavigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                            if (w.Component.GridTwoColumn.FileIdRightNavigation != null)
                            {
                                string filename = Path.GetFileName(w.Component.GridTwoColumn.FileIdRightNavigation.FileName);
                                w.Component.GridTwoColumn.FileIdRightNavigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                        }
                        if (w.Component.Name == "GridFourImage")
                        {
                            GridFourImage gridFourImage = _context.GridFourImages.Include(g => g.FileId1Navigation).Include(g2 => g2.FileId2Navigation).Include(g3 => g3.FileId3Navigation).Include(g4 => g4.FileId4Navigation)
                                .Where(gf => gf.Id == w.ComponentId).FirstOrDefault();
                            if (gridFourImage.FileId1Navigation != null)
                            {
                                string filename = Path.GetFileName(gridFourImage.FileId1Navigation.FileName);
                                gridFourImage.FileId1Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                            if (gridFourImage.FileId2Navigation != null)
                            {
                                string filename = Path.GetFileName(gridFourImage.FileId2Navigation.FileName);
                                gridFourImage.FileId2Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                            if (gridFourImage.FileId3Navigation != null)
                            {
                                string filename = Path.GetFileName(gridFourImage.FileId3Navigation.FileName);
                                gridFourImage.FileId3Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                            if (gridFourImage.FileId4Navigation != null)
                            {
                                string filename = Path.GetFileName(gridFourImage.FileId4Navigation.FileName);
                                gridFourImage.FileId4Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                        }
                        if(w.Component.Name == "OneTopicImageCaptionButton")
                        {
                            OneTopicImageCaptionButton ob = _context.OneTopicImageCaptionButtons.Include(o => o.File).Where(a => a.Id == w.ComponentId).FirstOrDefault();
                            if(ob.File != null)
                            {
                                string filename = Path.GetFileName(ob.File.FileName);
                                ob.File.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                        }
                        if(w.Component.Name == "TwoTableTopicImageCaptionButton")
                        {
                            TwoTableTopicImageCaptionButton ttb = _context.TwoTableTopicImageCaptionButtons.Include(t => t.FileId1Navigation)
                                .Include(tt => tt.FileId2Navigation)
                                .Where(a => a.Id == w.ComponentId).FirstOrDefault();
                            if(ttb.FileId1Navigation != null)
                            {
                                string filename = Path.GetFileName(ttb.FileId1Navigation.FileName);
                                ttb.FileId1Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                            if(ttb.FileId2Navigation != null)
                            {
                                string filename = Path.GetFileName(ttb.FileId2Navigation.FileName);
                                ttb.FileId2Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                        }
                        if(w.Component.Name == "Sale")
                        {
                            Sale sale = _context.Sales.Include(s => s.FileId1Navigation).Include(ss => ss.FileId2Navigation).Where(a => a.Id == w.ComponentId).FirstOrDefault();
                            if(sale.FileId1Navigation != null)
                            {
                                string filename = Path.GetFileName(sale.FileId1Navigation.FileName);
                                sale.FileId1Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                            if (sale.FileId2Navigation != null)
                            {
                                string filename = Path.GetFileName(sale.FileId2Navigation.FileName);
                                sale.FileId2Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                        }
                        if(w.Component.Name == "About")
                        {
                            About about = _context.Abouts.Include(a => a.FileId1Navigation)
                                .Include(a1 => a1.FileIdLeftNavigation)
                                .Include(a2 => a2.FileIdRightNavigation)
                                .Where(ab => ab.Id == w.ComponentId).FirstOrDefault();
                            if(about.FileId1Navigation != null)
                            {
                                string filename = Path.GetFileName(about.FileId1Navigation.FileName);
                                about.FileId1Navigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                            if (about.FileIdLeftNavigation != null)
                            {
                                string filename = Path.GetFileName(about.FileIdLeftNavigation.FileName);
                                about.FileIdLeftNavigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                            if (about.FileIdRightNavigation != null)
                            {
                                string filename = Path.GetFileName(about.FileIdRightNavigation.FileName);
                                about.FileIdRightNavigation.FilePath = $"https://localhost:7281/uploads/{filename}";
                            }
                        }
                        if (w.Component.Name == "Form")
                        {
                            w.Component.Form.FormComponents = _context.FormComponents.Where(f => f.Form.Id == component.Id).ToList();

                            foreach (var gf in w.Component.Form.FormComponents)
                            {
                                if (gf.Name == "SingleSelection")
                                {
                                    gf.SingleSelection.ElementSingleSelections = _context.ElementSingleSelections.Where(e => e.Id == gf.Id).ToList();
                                }
                                if (gf.Name == "TextField")
                                {
                                    gf.TextField.ElementTextFields = _context.ElementTextFields.Where(t => t.Id == gf.Id).ToList();

                                }
                                 if (gf.Name == "Date")
                                {
                                    gf.Date.ElementDates = _context.ElementDates.Where(d => d.Id == gf.Id).ToList();
                                }
                                 if (gf.Name == "BirthDate")
                                {
                                    gf.BirthDate.ElementBirthDates = _context.ElementBirthDates.Where(bd => bd.Id == gf.Id).ToList();
                                }
                                 if (gf.Name == "ImageUpload")
                                {
                                    gf.ImageUpload.ElementImageUploads = _context.ElementImageUploads.Where(im => im.Id == gf.Id).ToList();
                                }
                                if (gf.Name == "ImageUploadWithImageContent")
                                {
                                    gf.ImageUploadWithImageContent.ElementImageUploadWithImageContents = _context.ElementImageUploadWithImageContents.Where(ic => ic.Id == gf.Id).ToList();
                                    foreach(var d in gf.ImageUploadWithImageContent.ElementImageUploadWithImageContents)
                                    {
                                        ElementImageUploadWithImageContent ei = _context.ElementImageUploadWithImageContents.Include(i => i.File).Where(a => a.ImageUploadWithImageContentId == gf.ImageUploadWithImageContent.Id).FirstOrDefault();
                                        if(ei.File != null)
                                        {
                                            string filename = Path.GetFileName(ei.File.FileName);
                                            ei.File.FilePath = $"https://localhost:7281/uploads/{filename}";
                                        }
                                    }
                                }
                                w.Component.Form.CopyForms = _context.CopyForms.Where(f => f.FormId == w.ComponentId).ToList();

                                foreach (var cc in w.Component.Form.CopyForms)
                                {
                                    cc.CopyFormComponents = _context.CopyFormComponents.Where(cf => cf.CopyFormId == gf.Id).ToList();
                                }
                            }
                        }
                    }
                }
            }
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var json = JsonConvert.SerializeObject(component, settings);
        }
    }
}
