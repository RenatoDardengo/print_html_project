
namespace Print_html_project
{
    public class DataModel
    {
        public string Name { get; set; } = string.Empty;
        public string Decorator { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int IdBudget {  get; set; }
        public double TotalBudget { get; set; }
        public List<Items> Items { get; set; } = new List<Items>();
    }

    public class Items
    {
        public DateTime Date { get; set; } 
        public string Description {  get; set; } = string .Empty ;
        public double Price {  get; set; }     
    }
}
