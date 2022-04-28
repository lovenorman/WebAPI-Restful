using Microsoft.EntityFrameworkCore;

namespace WebAPI_Restful_.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;

        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            _context.Database.Migrate();
            SeedAds();
        }

        private void SeedAds()
        {
            if(!_context.Advertisements.Any(a => a.Title == "Iphone12"))
            {
                _context.Advertisements.Add(new Advertisement 
                { 
                    Title = "Iphone12", 
                    Author = "Lisa", 
                    CreateDate = "2019-01-01", 
                    Description = "En helt ny Iphone12 med kvitto." 
                });
            }

            if (!_context.Advertisements.Any(a => a.Title == "Husbil/Plåtis"))
            {
                _context.Advertisements.Add(new Advertisement
                {
                    Title = "Husbil/Plåtis",
                    Author = "Lina",
                    CreateDate = "2020-01-01",
                    Description = "Plåtis från 2009. Solceller finns."
                });
            }

            if (!_context.Advertisements.Any(a => a.Title == "BärbarDator"))
            {
                _context.Advertisements.Add(new Advertisement
                {
                    Title = "BärbarDator",
                    Author = "Lena",
                    CreateDate = "2022-01-01",
                    Description = "Begagnad bärbar dator, Lenovo."
                });
            }

            _context.SaveChanges();
        }
    }
}
