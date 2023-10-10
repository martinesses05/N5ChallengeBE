namespace N5.Permissions.Core.DTOs.Filters
{
    public class FilterBase
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? FreeText { get; set; } 
    }
}
