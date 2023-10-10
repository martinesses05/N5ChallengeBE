
namespace N5.Permissions.Core.DTOs.Common
{
    public  class PagedListResponse<T>
    {
        public int Count { get; set; }
        public IList<T> List { get; set; }
    }
}
