using System.Globalization;

namespace KairaCQRSMediator.DataAccess.Entities
{
    public class Category
    {
        public int CategoryId { get; set; } 

        public string CategoryName { get; set; }    

        public string ImageUrl { get; set; }

        public IList<Product> Products { get; set; } //bir kategorinin birden çok ürünü olabilir ama her bir ürünün tek bir kategoriis olur 

    }
}
