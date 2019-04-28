using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace addemo.Models
{
    public class CallToAction : BaseItemModel
    {
        [SitecoreField(FieldId = Templates.CallToAction.Fields.Name)]
        public virtual string Title { get; set; }
        [SitecoreField(FieldId = Templates.CallToAction.Fields.Description)]
        public virtual string Description { get; set; }
        [SitecoreField(FieldId = Templates.CallToAction.Fields.BackgroundImage)]
        public virtual Image BackgroundImage { get; set; }
        [SitecoreField(FieldId = Templates.CallToAction.Fields.CallToActionLink)]
        public virtual Link CallToActionLink { get; set; }
    }
}