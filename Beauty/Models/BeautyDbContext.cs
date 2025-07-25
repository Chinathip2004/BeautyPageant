using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

public partial class BeautyDbContext : DbContext
{
    public BeautyDbContext()
    {
    }

    public BeautyDbContext(DbContextOptions<BeautyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<BirthDate> BirthDates { get; set; }

    public virtual DbSet<Button> Buttons { get; set; }

    public virtual DbSet<ButtonForm> ButtonForms { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<Container> Containers { get; set; }

    public virtual DbSet<Containing> Containings { get; set; }

    public virtual DbSet<CopyForm> CopyForms { get; set; }

    public virtual DbSet<CopyFormComponent> CopyFormComponents { get; set; }

    public virtual DbSet<Date> Dates { get; set; }

    public virtual DbSet<Dependent> Dependents { get; set; }

    public virtual DbSet<ElementBirthDate> ElementBirthDates { get; set; }

    public virtual DbSet<ElementDate> ElementDates { get; set; }

    public virtual DbSet<ElementImageUpload> ElementImageUploads { get; set; }

    public virtual DbSet<ElementImageUploadWithImageContent> ElementImageUploadWithImageContents { get; set; }

    public virtual DbSet<ElementSingleSelection> ElementSingleSelections { get; set; }

    public virtual DbSet<ElementTextField> ElementTextFields { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventCategorize> EventCategorizes { get; set; }

    public virtual DbSet<FileImg> FileImgs { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<FormComponent> FormComponents { get; set; }

    public virtual DbSet<GridFourImage> GridFourImages { get; set; }

    public virtual DbSet<GridTwoColumn> GridTwoColumns { get; set; }

    public virtual DbSet<ImageDescription> ImageDescriptions { get; set; }

    public virtual DbSet<ImageUpload> ImageUploads { get; set; }

    public virtual DbSet<ImageUploadWithImageContent> ImageUploadWithImageContents { get; set; }

    public virtual DbSet<ImageWithCaption> ImageWithCaptions { get; set; }

    public virtual DbSet<OneTopicImageCaptionButton> OneTopicImageCaptionButtons { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SingleSelection> SingleSelections { get; set; }

    public virtual DbSet<TableWithTopicAndDescription> TableWithTopicAndDescriptions { get; set; }

    public virtual DbSet<TextBox> TextBoxes { get; set; }

    public virtual DbSet<TextField> TextFields { get; set; }

    public virtual DbSet<TwoTableTopicImageCaptionButton> TwoTableTopicImageCaptionButtons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DTL002R; Initial Catalog=Beauty_db; Integrated Security=True; Pooling=False; Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FileId1Navigation).WithMany(p => p.AboutFileId1Navigations).HasConstraintName("FK_About_FileImg");

            entity.HasOne(d => d.FileIdLeftNavigation).WithMany(p => p.AboutFileIdLeftNavigations).HasConstraintName("FK_About_FileImg1");

            entity.HasOne(d => d.FileIdRightNavigation).WithMany(p => p.AboutFileIdRightNavigations).HasConstraintName("FK_About_FileImg2");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.About)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_About_Component");
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Banner)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Banner_Component");
        });

        modelBuilder.Entity<BirthDate>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.BirthDate)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BirthDate_FormComponent");
        });

        modelBuilder.Entity<Button>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Button)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Button_Component");
        });

        modelBuilder.Entity<ButtonForm>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ButtonForm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ButtonForm_FormComponent");
        });

        modelBuilder.Entity<Container>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Container)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Container_Component");
        });

        modelBuilder.Entity<Containing>(entity =>
        {
            entity.HasOne(d => d.Component).WithMany(p => p.Containings).HasConstraintName("FK_Containing_Component");

            entity.HasOne(d => d.Container).WithMany(p => p.Containings).HasConstraintName("FK_Containing_Container");
        });

        modelBuilder.Entity<CopyForm>(entity =>
        {
            entity.HasOne(d => d.Form).WithMany(p => p.CopyForms).HasConstraintName("FK_CopyForm_Form");
        });

        modelBuilder.Entity<CopyFormComponent>(entity =>
        {
            entity.HasOne(d => d.CopyForm).WithMany(p => p.CopyFormComponents).HasConstraintName("FK_CopyFormComponent_CopyForm");

            entity.HasOne(d => d.FormComponent).WithMany(p => p.CopyFormComponents).HasConstraintName("FK_CopyFormComponent_FormComponent");
        });

        modelBuilder.Entity<Date>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Date)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Date_FormComponent");
        });

        modelBuilder.Entity<Dependent>(entity =>
        {
            entity.HasOne(d => d.Event).WithMany(p => p.Dependents).HasConstraintName("FK_Dependent_Event");

            entity.HasOne(d => d.Page).WithMany(p => p.Dependents).HasConstraintName("FK_Dependent_Page");
        });

        modelBuilder.Entity<ElementBirthDate>(entity =>
        {
            entity.HasOne(d => d.BirthDate).WithMany(p => p.ElementBirthDates).HasConstraintName("FK_ElementBirthDate_BirthDate");
        });

        modelBuilder.Entity<ElementDate>(entity =>
        {
            entity.HasOne(d => d.Date).WithMany(p => p.ElementDates).HasConstraintName("FK_ElementDate_Date");
        });

        modelBuilder.Entity<ElementImageUpload>(entity =>
        {
            entity.HasOne(d => d.ImageUpload).WithMany(p => p.ElementImageUploads).HasConstraintName("FK_ElementImageUpload_ImageUpload");
        });

        modelBuilder.Entity<ElementImageUploadWithImageContent>(entity =>
        {
            entity.HasOne(d => d.File).WithMany(p => p.ElementImageUploadWithImageContents).HasConstraintName("FK_ElementImageUploadWithImageContent_FileImg");

            entity.HasOne(d => d.ImageUploadWithImageContent).WithMany(p => p.ElementImageUploadWithImageContents).HasConstraintName("FK_ElementImageUploadWithImageContent_ImageUploadWithImageContent1");
        });

        modelBuilder.Entity<ElementSingleSelection>(entity =>
        {
            entity.HasOne(d => d.SingleSelection).WithMany(p => p.ElementSingleSelections).HasConstraintName("FK_ElementSingleSelection_SingleSelection");
        });

        modelBuilder.Entity<ElementTextField>(entity =>
        {
            entity.HasOne(d => d.TextField).WithMany(p => p.ElementTextFields).HasConstraintName("FK_ElementTextField_TextField");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasOne(d => d.File).WithMany(p => p.Events).HasConstraintName("FK_Event_FileImg");
        });

        modelBuilder.Entity<EventCategorize>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.EventCategorizes).HasConstraintName("FK_EventCategorize_Category");

            entity.HasOne(d => d.Event).WithMany(p => p.EventCategorizes).HasConstraintName("FK_EventCategorize_Event");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Form)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Form_Component");
        });

        modelBuilder.Entity<FormComponent>(entity =>
        {
            entity.HasOne(d => d.Form).WithMany(p => p.FormComponents).HasConstraintName("FK_FormComponent_Form");
        });

        modelBuilder.Entity<GridFourImage>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FileId1Navigation).WithMany(p => p.GridFourImageFileId1Navigations).HasConstraintName("FK_GridFourImage_FileImg");

            entity.HasOne(d => d.FileId2Navigation).WithMany(p => p.GridFourImageFileId2Navigations).HasConstraintName("FK_GridFourImage_FileImg1");

            entity.HasOne(d => d.FileId3Navigation).WithMany(p => p.GridFourImageFileId3Navigations).HasConstraintName("FK_GridFourImage_FileImg2");

            entity.HasOne(d => d.FileId4Navigation).WithMany(p => p.GridFourImageFileId4Navigations).HasConstraintName("FK_GridFourImage_FileImg3");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.GridFourImage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GridFourImage_Component");
        });

        modelBuilder.Entity<GridTwoColumn>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FileIdLeftNavigation).WithMany(p => p.GridTwoColumnFileIdLeftNavigations).HasConstraintName("FK_GridTwoColumn_FileImg");

            entity.HasOne(d => d.FileIdRightNavigation).WithMany(p => p.GridTwoColumnFileIdRightNavigations).HasConstraintName("FK_GridTwoColumn_FileImg1");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.GridTwoColumn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GridTwoColumn_Component");
        });

        modelBuilder.Entity<ImageDescription>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.File).WithMany(p => p.ImageDescriptions).HasConstraintName("FK_ImageDescription_FileImg");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ImageDescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImageDescription_Component");
        });

        modelBuilder.Entity<ImageUpload>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ImageUpload)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImageUpload_FormComponent");
        });

        modelBuilder.Entity<ImageUploadWithImageContent>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ImageUploadWithImageContent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImageUploadWithImageContent_FormComponent");
        });

        modelBuilder.Entity<ImageWithCaption>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.File).WithMany(p => p.ImageWithCaptions).HasConstraintName("FK_ImageWithCaption_FileImg");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ImageWithCaption)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ImageWithCaption_Component");
        });

        modelBuilder.Entity<OneTopicImageCaptionButton>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.File).WithMany(p => p.OneTopicImageCaptionButtons).HasConstraintName("FK_OneTopicImageCaptionButton_FileImg");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.OneTopicImageCaptionButton)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OneTopicImageCaptionButton_Component");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Page)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Page_Container");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasOne(d => d.CopyFormComponent).WithMany(p => p.Results).HasConstraintName("FK_Result_CopyFormComponent");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FileId1Navigation).WithMany(p => p.SaleFileId1Navigations).HasConstraintName("FK_Sale_FileImg");

            entity.HasOne(d => d.FileId2Navigation).WithMany(p => p.SaleFileId2Navigations).HasConstraintName("FK_Sale_FileImg1");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Sale)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_Component");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Section)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_Container");
        });

        modelBuilder.Entity<SingleSelection>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.SingleSelection)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SingleSelection_FormComponent");
        });

        modelBuilder.Entity<TableWithTopicAndDescription>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TableWithTopicAndDescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TableWithTopicAndDescription_Component");
        });

        modelBuilder.Entity<TextBox>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TextBox)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextBox_Component");
        });

        modelBuilder.Entity<TextField>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TextField)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TextField_FormComponent");
        });

        modelBuilder.Entity<TwoTableTopicImageCaptionButton>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.FileId1Navigation).WithMany(p => p.TwoTableTopicImageCaptionButtonFileId1Navigations).HasConstraintName("FK_TwoTableTopicImageCaptionButton_FileImg");

            entity.HasOne(d => d.FileId2Navigation).WithMany(p => p.TwoTableTopicImageCaptionButtonFileId2Navigations).HasConstraintName("FK_TwoTableTopicImageCaptionButton_FileImg1");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TwoTableTopicImageCaptionButton)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TwoTableTopicImageCaptionButton_Component");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
