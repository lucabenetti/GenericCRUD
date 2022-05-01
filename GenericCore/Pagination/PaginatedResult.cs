using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCore.Pagination
{
    public class PaginatedResult<TResult>
    {
        public IEnumerable<TResult> Itens { get; set; }
        public PaginatedInfo PaginatedInfo { get; set; }
    }
}
