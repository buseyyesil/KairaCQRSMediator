using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KairaCQRSMediator.DataAccess.Entities
{
    public class Collection
    {
        public int CollectionId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }    

        
    }
}
