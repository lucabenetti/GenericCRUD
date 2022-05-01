using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCore.Pagination
{
    public class PaginatedInput
    {
        public int PageSize { get; set; }

        /// <summary>
        /// O número da pagina, iniciando em 0
        /// </summary>
        public int PageNumber { get; set; }
    }
}
