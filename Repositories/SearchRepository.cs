using addemo.Models;
using Sitecore;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace addemo.Repositories
{
    public static class SearchRepository
    {
        public static List<SearchResultItem> GetSearchResults(
            SearchCriteria searchCriteria, out int totalResultCount)
        {
            totalResultCount = 0;

            //var query = GetQueryableResults(searchCriteria);

            if (searchCriteria == null || string.IsNullOrEmpty(searchCriteria.Language))
            {
                Log.Error("Search Input is empty", Context.User);
                return null;
            }

            SitecoreIndexableItem rootItem = searchCriteria.RootItem ?? Context.Item;

            if (rootItem == null)
            {
                Log.Error("Could not determine a context item for the search", Context.User);
                return null;
            }

            using (var context = ContentSearchManager.GetIndex(rootItem).CreateSearchContext(SearchSecurityOptions.Default))
            {
                IQueryable<SearchResultItem> query = context.GetQueryable<SearchResultItem>().Where(f => f.Language == searchCriteria.Language);

                var locationFilter = PredicateBuilder.True<SearchResultItem>();
                if (searchCriteria.RootItem != null)
                {
                    locationFilter = locationFilter.And(t => t.Paths.Contains(searchCriteria.RootItem.ID));
                    query = query.Where(locationFilter);
                }

                var templateFilter = PredicateBuilder.True<SearchResultItem>();
                if (searchCriteria.TemplateIds != null && searchCriteria.TemplateIds.Count > 0)
                {
                    foreach (string templateId in searchCriteria.TemplateIds)
                    {
                        templateFilter = templateFilter.Or(t => t.TemplateId == ID.Parse(templateId));
                    }
                    query = query.Where(templateFilter);
                }

                var searchTextFilter = PredicateBuilder.True<SearchResultItem>();
                if (!string.IsNullOrEmpty(searchCriteria.SearchText))
                {
                    searchTextFilter = searchTextFilter.And(t => t.Content.Equals(searchCriteria.SearchText));
                    query = query.Where(searchTextFilter);
                }

                var refinementFilter = PredicateBuilder.True<SearchResultItem>();

                searchCriteria.Refinements = searchCriteria.Refinements != null && searchCriteria.Refinements.Count > 0 ?
                    searchCriteria.Refinements.Where(f => !string.IsNullOrEmpty(f.FieldName) && !string.IsNullOrEmpty(f.FieldValue)).ToList() : null;

                if (searchCriteria.Refinements != null && searchCriteria.Refinements.Count > 0)
                {
                    foreach (Refinement refinement in searchCriteria.Refinements)
                    {
                        string fieldName = refinement.FieldName.ToLowerInvariant();
                        string fieldValue = IdHelper.ProcessGUIDs(refinement.FieldValue);
                        refinementFilter = refinementFilter.And(t => t[fieldName].Equals(fieldValue));
                    }
                    query = query.Where(refinementFilter);
                }

                if (!string.IsNullOrEmpty(searchCriteria.SortFieldName))
                {
                    if (searchCriteria.SortAscending)
                        query = query.OrderBy(x => x[searchCriteria.SortFieldName]);
                    else
                        query = query.OrderByDescending(x => x[searchCriteria.SortFieldName]);
                }

                if (searchCriteria.PageSize.HasValue)
                {
                    searchCriteria.PageNumber = searchCriteria.PageNumber.HasValue ? searchCriteria.PageNumber.Value - 1 : 0;

                    query = query.Page(searchCriteria.PageNumber.Value, searchCriteria.PageSize.Value);
                }
                var results = query.GetResults();

                totalResultCount = results.TotalSearchResults;
                return results.Hits.Select(h => h.Document).ToList();
            }
        }

        public static IQueryable<SearchResultItem> GetQueryableResults(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null || string.IsNullOrEmpty(searchCriteria.Language))
            {
                Log.Error("Search Input is empty", Context.User);
                return null;
            }

            SitecoreIndexableItem rootItem = searchCriteria.RootItem ?? Context.Item;

            if (rootItem == null)
            {
                Log.Error("Could not determine a context item for the search", Context.User);
                return null;
            }

            using (var context = ContentSearchManager.GetIndex(rootItem).CreateSearchContext(SearchSecurityOptions.Default))
            {
                IQueryable<SearchResultItem> query = context.GetQueryable<SearchResultItem>().Where(f => f.Language == searchCriteria.Language);

                var locationFilter = PredicateBuilder.True<SearchResultItem>();
                if (searchCriteria.RootItem != null)
                {
                    locationFilter = locationFilter.And(t => t.Paths.Contains(searchCriteria.RootItem.ID));
                    query = query.Where(locationFilter);
                }

                var templateFilter = PredicateBuilder.True<SearchResultItem>();
                if (searchCriteria.TemplateIds != null && searchCriteria.TemplateIds.Count > 0)
                {
                    foreach (string templateId in searchCriteria.TemplateIds)
                    {
                        templateFilter = templateFilter.Or(t => t.TemplateId == ID.Parse(templateId));
                    }
                    query = query.Where(templateFilter);
                }

                var searchTextFilter = PredicateBuilder.True<SearchResultItem>();
                if (!string.IsNullOrEmpty(searchCriteria.SearchText))
                {
                    searchTextFilter = searchTextFilter.And(t => t.Content.Equals(searchCriteria.SearchText));
                    query = query.Where(searchTextFilter);
                }

                var refinementFilter = PredicateBuilder.True<SearchResultItem>();

                searchCriteria.Refinements = searchCriteria.Refinements != null && searchCriteria.Refinements.Count > 0 ?
                    searchCriteria.Refinements.Where(f => !string.IsNullOrEmpty(f.FieldName) && !string.IsNullOrEmpty(f.FieldValue)).ToList() : null;

                if (searchCriteria.Refinements != null && searchCriteria.Refinements.Count > 0)
                {
                    foreach (Refinement refinement in searchCriteria.Refinements)
                    {
                        string fieldName = refinement.FieldName.ToLowerInvariant();
                        string fieldValue = IdHelper.ProcessGUIDs(refinement.FieldValue);
                        refinementFilter = refinementFilter.And(t => t[fieldName].Equals(fieldValue));
                    }
                    query = query.Where(refinementFilter);
                }

                if (!string.IsNullOrEmpty(searchCriteria.SortFieldName))
                {
                    if (searchCriteria.SortAscending)
                        query = query.OrderBy(x => x[searchCriteria.SortFieldName]);
                    else
                        query = query.OrderByDescending(x => x[searchCriteria.SortFieldName]);
                }

                if (searchCriteria.PageSize.HasValue)
                {
                    searchCriteria.PageNumber = searchCriteria.PageNumber.HasValue ? searchCriteria.PageNumber.Value - 1 : 0;

                    query = query.Page(searchCriteria.PageNumber.Value, searchCriteria.PageSize.Value);
                }
                return query;
            }
        }
    }
}