using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace addemo.Models
{
    public class HeroBanner : BaseItemModel
    {
        [SitecoreField(FieldId = Templates.HeroBanner.Fields.TopTitle)]
        public virtual string TopTitle { get; set; }
        [SitecoreField(FieldId = Templates.HeroBanner.Fields.Title)]
        public virtual string Title { get; set; }
        [SitecoreField(FieldId = Templates.HeroBanner.Fields.SubTitle)]
        public virtual string SubTitle { get; set; }
        [SitecoreField(FieldId = Templates.HeroBanner.Fields.BackgroundImage)]
        public virtual Image BackgroundImage { get; set; }
        [SitecoreField(FieldId = Templates.HeroBanner.Fields.CallToActionLink)]
        public virtual Link CallToActionLink { get; set; }
    }
}