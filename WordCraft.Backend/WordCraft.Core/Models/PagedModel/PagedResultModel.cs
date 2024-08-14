namespace WordCraft.Core.Models.PagedModel
{
    public class PagedResultModel<T> : PagedResultBase
    {
        public IList<T> Results { get; set; }

        public PagedResultModel()
        {
            Results = [];
        }
    }
}
