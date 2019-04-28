using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;

namespace addemo.Models
{
    public class Book : BaseItemModel
    {
        [SitecoreField(FieldId = Templates.Book.Fields.Title)]
        public virtual string Title { get; set; }
        [SitecoreField(FieldId = Templates.Book.Fields.Teaser)]
        public virtual string Teaser { get; set; }
        [SitecoreField(FieldId = Templates.Book.Fields.Description)]
        public virtual string Description { get; set; }
        [SitecoreField(FieldId = Templates.Book.Fields.CoverImage)]
        public virtual Image CoverImage { get; set; }
        [SitecoreField(FieldId = Templates.Book.Fields.ISBN)]
        public virtual string ISBN { get; set; }
        [SitecoreField(FieldId = Templates.Book.Fields.NumberOfPages)]
        public virtual int NumberOfPages { get; set; }
        [SitecoreField(FieldId = Templates.Book.Fields.Language)]
        public virtual string LanguageName { get; set; }
        [SitecoreField(FieldId = Templates.Book.Fields.PublishedDate)]
        public virtual DateTime PublishedDate { get; set; }
        [SitecoreField(FieldId = Templates.Book.Fields.Author)]
        public virtual string Author { get; set; }
        [SitecoreField(FieldId = Templates.Book.Fields.Type)]
        public virtual string Type { get; set; }

    }
}