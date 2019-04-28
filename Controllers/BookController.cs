using addemo.Models;
using addemo.Repositories;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;
using System.Web.Mvc;

namespace addemo.Controllers
{
    public class BookController : GlassController
    {
        public ActionResult Landing()
        {
            var sitecoreService = new SitecoreService(Context.Database);
            string searchText = Request.QueryString["text"] ?? string.Empty;

            var bookrenderingparams = GetRenderingParameters<BookRenderingParameters>();

            var pageSize = RenderingContext.Current.Rendering.Parameters["Page Size"];

            SearchCriteria searchCriteria = new SearchCriteria
            {
                Language = Context.Language.Name,
                TemplateIds = new List<string> { Templates.Book.ID.ToString() },
                SearchText = !string.IsNullOrEmpty(searchText) ? searchText : string.Empty,
                PageSize = bookrenderingparams != null && bookrenderingparams.PageSize != 0 ? bookrenderingparams.PageSize : default(int?)
            };

            int totalResultCount;
            List<Book> books = new List<Book>();

            var results = SearchRepository.GetSearchResults(searchCriteria, out totalResultCount);
            if (results != null && results.Count > 0)
            {
                foreach (var resultItem in results)
                {
                    books.Add(sitecoreService.Cast<Book>(resultItem.GetItem()));
                }
            }

            

            return View("/Views/Book/BookLanding.cshtml", books);
        }

        public ActionResult Summary()
        {
            var model = GetContextItem<Book>();
            return View("/Views/Book/BookSummary.cshtml", model);
        }
    }
}