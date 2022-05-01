namespace GenericCore.Pagination
{
    public class PaginatedInfo
    {
        public int TotalElements { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages => PageSize == 0
            ? 0
            : (int)Math.Ceiling(TotalElements / (double)PageSize);

        public int FirstPage => 0;

        public int LastPage => TotalPages == 0 ? 0 : TotalPages - 1;

        public bool HasPreviousPage => PageNumber >= 1;

        public bool HasNextPage => PageNumber < LastPage;

        public int PreviousPage => !HasPreviousPage ? FirstPage : PageNumber - 1;

        public int NextPage => !HasNextPage ? LastPage : PageNumber + 1;
    }
}
