using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace addemo.Models
{
    [SitecoreType(TemplateId = Templates.BookRenderingParameters.TemplateId, AutoMap = true)]
    public class BookRenderingParameters: BaseItemModel
    {
        [SitecoreField(FieldId = Templates.BookRenderingParameters.Fields.PageSize)]
        public virtual int PageSize { get; set; }
        [SitecoreField(FieldId = Templates.BookRenderingParameters.Fields.BackgroundColor)]
        public virtual string BackgroundColor { get; set; }
    }
}