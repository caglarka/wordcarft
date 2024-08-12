namespace WordCraft.Core.Models.PagedModel
{
    public class FilteringModel
    {
        public string ColoumName { get; set; }
        public object Value { get; set; }

        public FilteringModel()
        {
            ColoumName = "isActive";
            Value = "1";
        }
    }
}
