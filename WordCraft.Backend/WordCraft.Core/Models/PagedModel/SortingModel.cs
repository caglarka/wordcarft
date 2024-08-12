namespace WordCraft.Core.Models.PagedModel
{
    public class SortingModel
    {
        public string SortingField { get; set; }
        public bool IsAscending { get; set; }

        public SortingModel()
        {
            SortingField = "createDate";
            IsAscending = false;
        }
    }
}
