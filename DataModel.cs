
namespace Print_html_project
{
    public class DataModel
    {
        public string Name { get; set; } = string.Empty;
        public List<Items> Items { get; set; } = new List<Items>();
    }

    public class Items
    {
        public string Date { get; set; } = string.Empty ;
        public string Description {  get; set; } = string .Empty ;
        public string Price {  get; set; } = string .Empty ;    
    }
}
