namespace Core.EndPointsParams
{
    public class GetProductsParams
    {
        private const int MaxPageSize = 50;
        private int _pageSize = 6;

  
        public string SortedBy { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public int PageNum { get; set; } = 1;
        public int PageSize { get => _pageSize; set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;}

        public string Search { get; set; }

    }
}