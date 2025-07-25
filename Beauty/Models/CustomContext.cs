using Microsoft.EntityFrameworkCore;

namespace Beauty.Models
{
    public partial class CustomContext : BeautyDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>().UseTptMappingStrategy().ToTable("Component");
           
            modelBuilder.Entity<Banner>().ToTable("Banner");
            modelBuilder.Entity<TextBox>().ToTable("TextBox");
            modelBuilder.Entity<ImageWithCaption>().ToTable("ImageWithCaption");
            modelBuilder.Entity<GridTwoColumn>().ToTable("GridTwoColumn");
            modelBuilder.Entity<ImageDescription>().ToTable("ImageDescription");
            modelBuilder.Entity<GridFourImage>().ToTable("GridFourImage");
            modelBuilder.Entity<TableWithTopicAndDescription>().ToTable("TableWithTopicAndDescription");
            modelBuilder.Entity<OneTopicImageCaptionButton>().ToTable("OneTopicImageCaptionButton");
            modelBuilder.Entity<TwoTableTopicImageCaptionButton>().ToTable("TwoTableTopicImageCaptionButton");
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<Button>().ToTable("Button");
            modelBuilder.Entity<About>().ToTable("About");

            modelBuilder.Entity<Form>().ToTable("Form");
            modelBuilder.Entity<FormComponent>().UseTptMappingStrategy().ToTable("FormComponent");
            modelBuilder.Entity<SingleSelection>().ToTable("SingleSelection");
            modelBuilder.Entity<TextField>().ToTable("TextField");
            modelBuilder.Entity<Date>().ToTable("Date");
            modelBuilder.Entity<BirthDate>().ToTable("BirthDate");
            modelBuilder.Entity<ImageUpload>().ToTable("ImageUpload");
            modelBuilder.Entity<ImageUploadWithImageContent>().ToTable("ImageUploadWithImageContent");
            modelBuilder.Entity<ButtonForm>().ToTable("ButtonForm");
            modelBuilder.Entity<Container>().UseTptMappingStrategy().ToTable("Container");
            modelBuilder.Entity<Container>().Ignore(C => C.Page);
            modelBuilder.Entity<Container>().Ignore(C => C.Section);
            modelBuilder.Entity<Page>().ToTable("Page");
            modelBuilder.Entity<Section>().ToTable("Section");
            

            modelBuilder.Entity<Containing>(en =>
            {
                en.Ignore(C => C.Container);
                en.HasOne(d => d.Component).WithMany(p => p.Containings).HasConstraintName("FK_Containing_Component");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
