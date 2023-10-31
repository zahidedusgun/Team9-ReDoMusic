using ReDoMusic.Domain.Entities;

namespace ReDoMusic.MVC.Models
{
    public class AddInstrumentModel
    {
        public List<Category> Categories { get; set; }
        public List<Brand> Brands { get; set; }

    }
}
