using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace addemo.Custom_Code
{
    public class ItemOperation
    {
        public static bool CreateItem()
        {            
            using (new Sitecore.SecurityModel.SecurityDisabler())
            {
                Database masterDb = Sitecore.Configuration.Factory.GetDatabase("master");

                //Get Parent Node.
                Item parentItem = masterDb.Items["/sitecore/content/home"];

                //Now we need to get the template from which the item is created
                TemplateItem template = masterDb.GetTemplate("sample/sample item");

                //Now we can add the new item as a child to the parent
                Item item = parentItem.Add("New Sample Item", template);
                item.Editing.BeginEdit();
                item.Fields["text"].Value = "value";

                item.Editing.EndEdit();

            }
            return true;
        }
        public static bool UpdateItem()
        {
            Item item = Database.GetDatabase("master").GetItem("/sitecore/content/home/New Sample Item");

            item.Editing.BeginEdit();
            using (new EditContext(item))
            {
                item.Fields["title"].Value = "updated value";
            }
            item.Editing.EndEdit();
            return true;
        }

        public static bool DeleteItem()
        {
            Item item = Database.GetDatabase("master").GetItem("/sitecore/content/home/New Sample Item");
            item.Delete();
            return true;
        }

        //public static bool PublishItem(Item item)
        //{
        //    Database masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
        //    Database webDb = Sitecore.Configuration.Factory.GetDatabase("web");

        //    //We need to know the language to publish. Here we use the context language
        //    Language language = Sitecore.Context.Language;

        //    //We set the publish date to now
        //    DateTime publishTime = DateTime.Now;

        //    //Now we can create the publish options
        //    Sitecore.Publishing.PublishOptions options = new PublishOptions(masterDb, webDb, PublishMode.SingleItem, language, publishTime);

        //    //Activate the publishpipeline
        //    Sitecore.Publishing.Pipelines.PublishItem.PublishItemPipeline.Run(item.ID, options);

        //    return true;
        //}

    }
}