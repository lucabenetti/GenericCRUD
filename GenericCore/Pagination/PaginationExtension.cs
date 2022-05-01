using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericCore.Pagination
{
    public static class PaginationExtension
    {
        public static async Task<PaginatedResult<TResultItem>> PaginateAsync<TResultItem>(
            this IQueryable<TResultItem> query,
            PaginatedInput input,
            CancellationToken cancellationToken = new())
        {
            var pageNumber = input.PageNumber < 0 ? 0 : input.PageNumber;
            var pageSize = input.PageSize < 1 ? 10 : input.PageSize;

            var totalElements = await query.CountAsync(cancellationToken);

            var startIndex = pageNumber * pageSize;

            var itens = await query
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            var result = new PaginatedResult<TResultItem>
            {
                Itens = itens,
                PaginatedInfo = new PaginatedInfo
                {
                    PageNumber = pageNumber,
                    PageSize = itens.Count,
                    TotalElements = totalElements
                }
            };

            return result;
        }
    }
}
