using Microsoft.EntityFrameworkCore;
using WordCraft.Core.Models.PagedModel;
using WordCraft.Data.Utilities.Mapper;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace WordCraft.Data.Utilities.Helper
{
    public static class PagedHelper
    {
        public static async Task<PagedResultModel<T>> GetPaged<T>(this IQueryable<T> query, int page, int pageSize)
        {
            var result = new PagedResultModel<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.CountAsync().Result
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }

        public static async Task<PagedResultModel<T>> GetPaged<T>(this IQueryable<T> query,
            int page,
            int pageSize,
            Expression<Func<T, object>> orderBy,
            bool ascending = true)
        {
            var result = new PagedResultModel<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.CountAsync().Result
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;

            if (ascending)
                result.Results = await query.OrderBy(orderBy).Skip(skip).Take(pageSize).ToListAsync();
            else
                result.Results = await query.OrderByDescending(orderBy).Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }

        public static async Task<PagedResultModel<T>> GetPaged<T>(this IQueryable<T> query,
            int page,
            int pageSize,
            bool ascending,
            string orderByProperty = "id")
        {
            var result = new PagedResultModel<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = 0
            };

            if (query is null)
                return result;

            int skip = (page - 1) * pageSize;

            var orderByExpression =
                ModelPropertyMapper<T>.MapStringToProperty(orderByProperty.Length == 0 ? "id" : orderByProperty);

            if (ascending)
                result.Results = await query.OrderBy(orderByExpression).Skip(skip).Take(pageSize).ToListAsync();
            else
                result.Results = await query.OrderByDescending(orderByExpression).Skip(skip).Take(pageSize).ToListAsync();

            result.RowCount = (int)Math.Ceiling((double)query.CountAsync().Result);

            return result;
        }

        public static async Task<PagedResultModel<T>> GetPagedWithQuery<T>(this IQueryable<T> query,
            List<FilteringModel> predicate, int page, int pageSize, List<SortingModel> orderBys,
            List<Expression<Func<T, object>>> orderByDesc)
        {
            predicate.Add(new FilteringModel());
            foreach (var filterItem in predicate)
            {
                query = query.Where($"{filterItem!.ColoumName!}.ToString().Contains(\"{filterItem.Value}\")");
            }

            foreach (var orderBy in orderBys)
            {
                if (orderBy.IsAscending)
                {
                    query = query.OrderBy(orderBy.SortingField);
                }
            }

            foreach (var item in orderByDesc)
            {
                query = query.OrderByDescending(item);
            }


            var result = new PagedResultModel<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.CountAsync().Result
            };

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;

            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }

        public static void SetBaseData<T, E>(PagedResultModel<T> source, PagedResultModel<E> target)
        {
            target.CurrentPage = source.CurrentPage;
            target.PageSize = source.PageSize;
            target.RowCount = source.RowCount;
            target.PageCount = source.PageCount;
        }
    }
}
