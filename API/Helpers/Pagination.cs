namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageNum, int pageSize, IReadOnlyList<T> data)
        {
            PageNum = pageNum;
            PageSize = pageSize;
            Data = data;
        }

        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}