using Cherry.Application.Common.Structures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cherry.Application.Common.Helpers
{
    public static class Pagination
    {
        public static async Task<PagedData<TResult>> ToPagedDataAsync<TSource, TResult, TKey>(this IQueryable<TSource> source, int pageNumber, int pageSize,
            Expression<Func<TSource, TResult>> selector, Expression<Func<TSource, TKey>> keySelector, bool? hasDescOrderType = true) where TSource : class
        {
            var skipCount = (pageNumber - 1) * pageSize;
            var result = new PagedData<TResult>
            {
                TotalItemsCount = source.Count()
            };
            result.TotalPagesCount = result.TotalItemsCount % pageSize == 0 ? result.TotalItemsCount / pageSize : (result.TotalItemsCount / pageSize) + 1;
            result.PageNumber = pageNumber;
            result.PageSize = pageSize;

            var data = source.AsNoTracking();
            data = hasDescOrderType.Value ? data.OrderByDescending(keySelector) : data.OrderBy(keySelector);

            result.Items = await data.Skip(skipCount)
                .Take(pageSize)
                .Select(selector)
                .ToArrayAsync();

            return result;
        }
    }
}
