using Sitecore.Buckets.Extensions;
using Sitecore.Buckets.Managers;
using Sitecore.IO;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace addemo.Custom_Code
{
    public class CustomLinkProvider : LinkProvider
    {
        public override string GetItemUrl(Sitecore.Data.Items.Item item, 
            UrlOptions options)
        {
            if (BucketManager.IsItemContainedWithinBucket(item))
            {
                var bucketItem = item.GetParentBucketItemOrParent();
                if (bucketItem != null && bucketItem.IsABucket())
                {
                    var bucketUrl = base.GetItemUrl(bucketItem, options);

                    return FileUtil.MakePath(bucketUrl, item.Name.Replace(" ", "-"));
                }
            }

            return base.GetItemUrl(item, options);
        }
    }
}