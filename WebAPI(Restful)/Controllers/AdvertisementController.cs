using AutoMapper;
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
        private readonly IMapper _mapper;

        public AdvertisementController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            
            if (ad == null)
                return NotFound();

            _mapper.Map<AdvertisementDTO>(ad);
            
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(CreateAdvertisement advertisement)
        {
            var ad = _mapper.Map<Advertisement>(advertisement);

            _context.Advertisements.Add(ad);
            _context.SaveChanges();

            var adDTO = _mapper.Map<AdvertisementDTO>(ad);
            
            return CreatedAtAction(nameof(GetOne), new { id = ad.Id }, adDTO);
        }

        [HttpGet]//Är default
        public IActionResult Index()
        {
            return Ok(_context.Advertisements.Select(a => _mapper.Map<AdvertisementDTO>(a)));
            
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var ad = _context.Advertisements.FirstOrDefault(x => x.Id == id);
            if (ad == null)
                return NotFound();

            return Ok(_mapper.Map<AdvertisementDTO>(ad));
            
        }
    }
}
