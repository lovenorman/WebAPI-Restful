using Microsoft.AspNetCore.Mvc;
using WebAPI_Restful_.Data;
using WebAPI_Restful_.DTO;

namespace WebAPI_Restful_.Controllers
{
    [Route("api/[controller]")] // /api/lag
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdvertisementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var ad = _context.Advertisements.FirstOrDefault(x => x.Id == id);
            if(ad == null) 
                return NotFound();

            _context.Advertisements.Remove(ad);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateAdvertisement advertisement)
        {
            var ad = _context.Advertisements.FirstOrDefault(x => x.Id == id);
            if (ad != null)
                return NotFound();

            ad.Title = advertisement.Title;
            ad.Author = advertisement.Author;
            ad.CreateDate = advertisement.CreateDate;
            ad.Description = advertisement.Description;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(CreateAdvertisement advertisement)
        {
            var ad = new Advertisement
            {
                Title = advertisement.Title,
                Author = advertisement.Author,
                CreateDate = advertisement.CreateDate,
                Description = advertisement.Description
            };

            _context.Advertisements.Add(ad);
            _context.SaveChanges();

            var adDTO = new AdvertisementDTO
            {
                Title = ad.Title,
                Author = ad.Author,
                CreateDate = ad.CreateDate,
                Description = ad.Description
            };

            return CreatedAtAction(nameof(GetOne), new { id = ad.Id }, adDTO);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.Advertisements.Select(a => new AdvertisementsDTO
            {
                Title = a.Title,
                CreateDate = a.CreateDate,
            }).ToList());
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var ad = _context.Advertisements.FirstOrDefault(x => x.Id == id);
            if (ad == null)
                return NotFound();

            var ret = new AdvertisementDTO
            {
                Title = ad.Title,
                Author = ad.Author,
                CreateDate = ad.CreateDate,
                Description = ad.Description
            };

            return Ok(ret);
        }
    }
}
