using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace addemo.Computed_Fields
{
    public class HasPresentationComputedField : IComputedIndexField
    {
        public string FieldName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ReturnType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object ComputeFieldValue(IIndexable indexable)
        {
            throw new NotImplementedException();
        }
    }
}