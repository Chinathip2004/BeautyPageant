using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Security;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Beauty.Models
{
    public partial class Component
    {
        public Component Create(CustomContext customContext)
        {
            if (this.Name == "Section")
            {
                Section section = new Section();
                Component sc = (Component)section;
                sc.Name = this.Name;
                customContext.Add(sc);
                customContext.SaveChanges();
                this.Id = sc.Id;
            }
            else if (this.Name == "Banner")
            {
                Banner banner = new Banner();
                banner.Value = this.Banner.Value;
                banner.ButtonName = this.Banner.ButtonName;
                banner.UrlButton = this.Banner.UrlButton;
                banner.IsUrl = this.Banner.IsUrl;
                banner.FileId = this.Banner.FileId;
                Component bc = (Component)banner;
                bc.Name = this.Name;
                customContext.Add(bc);
                customContext.SaveChanges();
                this.Id = bc.Id;
            }
            else if (this.Name == "TextBox")
            {
                TextBox tb = new TextBox();
                tb.Value = this.TextBox.Value;
                Component tc = (Component)tb;
                tc.Name = this.Name;
                customContext.Add(tc);
                customContext.SaveChanges();
                this.Id = tc.Id;
            }
            else if (this.Name == "ImageWithCaption")
            {
                ImageWithCaption iw = new ImageWithCaption();
                iw.Value = this.ImageWithCaption.Value;
                iw.FileId = this.ImageWithCaption.FileId;
                Component ic = (Component)iw;
                ic.Name = this.Name;
                customContext.Add(ic);
                customContext.SaveChanges();
                this.Id = ic.Id;
            }
            else if (this.Name == "ImageDescription")
            {
                ImageDescription md = new ImageDescription();
                md.Value = this.ImageDescription.Value;
                md.FileId = this.ImageDescription.FileId;
                Component dc = (Component)md;
                dc.Name = this.Name;
                customContext.Add(dc);
                customContext.SaveChanges();
                this.Id = dc.Id;
            }
            else if (this.Name == "GridTwoColumn")
            {
                GridTwoColumn gt = new GridTwoColumn();
                gt.ValueLeft = this.GridTwoColumn.ValueLeft;
                gt.ValueRight = this.GridTwoColumn.ValueRight;
                gt.UrlLeft = this.GridTwoColumn.UrlLeft;
                gt.UrlRight = this.GridTwoColumn.UrlRight;
                gt.FileIdLeft = this.GridTwoColumn.FileIdLeft;
                gt.FileIdRight = this.GridTwoColumn.FileIdRight;
                Component gc = (Component)gt;
                gc.Name = this.Name;
                customContext.Add(gc);
                customContext.SaveChanges();
                this.Id = gc.Id;
            }
            else if (this.Name == "GridFourImage")
            {
                GridFourImage gf = new GridFourImage();
                gf.FileId1 = this.GridFourImage.FileId1;
                gf.FileId2 = this.GridFourImage.FileId2;
                gf.FileId3 = this.GridFourImage.FileId3;
                gf.FileId4 = this.GridFourImage.FileId4;
                Component gfc = (Component)gf;
                gfc.Name = this.Name;
                customContext.Add(gfc);
                customContext.SaveChanges();
                this.Id = gfc.Id;
            }
            else if (this.Name == "TableWithTopicAndDescription")
            {
                TableWithTopicAndDescription tbd = new TableWithTopicAndDescription();
                tbd.Value1 = this.TableWithTopicAndDescription.Value1;
                tbd.Value2 = this.TableWithTopicAndDescription.Value2;
                Component tbc = (Component)tbd;
                tbc.Name = this.Name;
                customContext.Add(tbc);
                customContext.SaveChanges();
                this.Id = tbc.Id;
            }
            else if (this.Name == "OneTopicImageCaptionButton")
            {
                OneTopicImageCaptionButton ob = new OneTopicImageCaptionButton();
                ob.Value1 = this.OneTopicImageCaptionButton.Value1;
                ob.Value2 = this.OneTopicImageCaptionButton.Value2;
                ob.ButtonName = this.OneTopicImageCaptionButton.ButtonName;
                ob.Url = this.OneTopicImageCaptionButton.Url;
                ob.IsUrl = this.OneTopicImageCaptionButton.IsUrl;
                ob.FileId = this.OneTopicImageCaptionButton.FileId;
                Component obc = (Component)ob;
                obc.Name = this.Name;
                customContext.Add(obc);
                customContext.SaveChanges();
                this.Id = obc.Id;
            }
            else if (this.Name == "TwoTableTopicImageCaptionButton")
            {
                TwoTableTopicImageCaptionButton ttb = new TwoTableTopicImageCaptionButton();
                ttb.Value1 = this.TwoTableTopicImageCaptionButton.Value1;
                ttb.ButtonName1 = this.TwoTableTopicImageCaptionButton.ButtonName1;
                ttb.Url1 = this.TwoTableTopicImageCaptionButton.Url1;
                ttb.IsUrl1 = this.TwoTableTopicImageCaptionButton.IsUrl1;
                ttb.Value2 = this.TwoTableTopicImageCaptionButton.Value2;
                ttb.ButtonName2 = this.TwoTableTopicImageCaptionButton.ButtonName2;
                ttb.Url2 = this.TwoTableTopicImageCaptionButton.Url2;
                ttb.IsUrl2 = this.TwoTableTopicImageCaptionButton.IsUrl2;
                ttb.FileId1 = this.TwoTableTopicImageCaptionButton.FileId1;
                ttb.FileId2 = this.TwoTableTopicImageCaptionButton.FileId2;
                Component tbc = (Component)ttb;
                tbc.Name = this.Name;
                customContext.Add(tbc);
                customContext.SaveChanges();
                this.Id = tbc.Id;
            }
            else if (this.Name == "Sale")
            {
                Sale s = new Sale();
                s.Value1 = this.Sale.Value1;
                s.Value2 = this.Sale.Value2;
                s.PromotionPrice = this.Sale.PromotionPrice;
                s.Normal = this.Sale.Normal;
                s.Date = this.Sale.Date;
                s.Value3 = this.Sale.Value3;
                s.ButtonName = this.Sale.ButtonName;
                s.IsUrl = this.Sale.IsUrl;
                s.Value4 = this.Sale.Value4;
                s.NameLeft = this.Sale.NameLeft;
                s.UrlLeft = this.Sale.UrlLeft;
                s.UrlRight = this.Sale.UrlRight;
                s.NameRight = this.Sale.NameRight;
                s.UrlButton = this.Sale.UrlButton;
                s.FileId1 = this.Sale.FileId1;
                s.FileId2 = this.Sale.FileId2;
                Component sc = (Component)s;
                sc.Name = this.Name;
                customContext.Add(sc);
                customContext.SaveChanges();
                this.Id = sc.Id;
            }
            else if (this.Name == "Button")
            {
                Button b = new Button();
                b.Value = this.Button.Value;
                b.Url = this.Button.Url;
                b.IsUrl = this.Button.IsUrl;
                Component btc = (Component)b;
                btc.Name = this.Name;
                customContext.Add(btc);
                customContext.SaveChanges();
                this.Id = btc.Id;
            }
            else if(this.Name == "About")
            {
                About a = new About();
                a.Value1 = this.About.Value1;
                a.Value2 = this.About.Value2;
                a.ValueLeft = this.About.ValueLeft;
                a.ValueRight = this.About.ValueRight;
                a.FileId1 = this.About.FileId1;
                a.FileIdLeft = this.About.FileIdLeft;
                a.FileIdRight = this.About.FileIdRight;
                Component ac = (Component)a;
                a.Name = this.Name;
                customContext.Add(ac);
                customContext.SaveChanges();
                this.Id = ac.Id;
            }
            else if (this.Name == "Form")
            {
                Form form = new Form();
                form.Value = this.Form.Value;
                form.ButtonName = this.Form.ButtonName;
                form.Url = this.Form.Url;
                form.FileIdPopup = this.Form.FileIdPopup;
                form.ValuePopup = this.Form.ValuePopup;
                Component fc = (Component)form;
                fc.Name = this.Name;
                customContext.Add(fc);
                customContext.SaveChanges();
                this.Id = fc.Id;
            }

            return this;
        }
    }
}
