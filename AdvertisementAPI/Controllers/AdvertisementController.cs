using AdvertisementAPI.Data;
using AdvertisementAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdvertisementController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Advertisements.Select(a => new AdvertisementDTO
            {
                Id = a.Id,
                Title = a.Title,
                NewsPaper = a.NewsPaper,
                Price = a.Price

            }).ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var ad = _context.Advertisements.FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            var adDto = new AdvertisementDTO
            {
                Title = ad.Title,
                NewsPaper = ad.NewsPaper,
                Price = ad.Price,
                Id = ad.Id
            };

            return Ok(adDto);
        }

        [HttpPost]
        public IActionResult Create(AdvertisementDTO advertisement)
        {
            var ad = new Advertisement
            {
                Title = advertisement.Title,
                NewsPaper = advertisement.NewsPaper,
                Price = advertisement.Price
            };

            _context.Advertisements.Add(ad);
            _context.SaveChanges();

            var adDto = new AdvertisementDTO
            {
                Title = ad.Title,
                NewsPaper = ad.NewsPaper,
                Id = ad.Id,
                Price = ad.Price
            };

            return CreatedAtAction(nameof(GetById), new {id = ad.Id}, adDto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, AdvertisementDTO advertisement)
        {
            var ad = _context.Advertisements.FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            ad.Title = advertisement.Title;
            ad.NewsPaper = advertisement.NewsPaper;
            ad.Price = advertisement.Price;

            _context.SaveChanges();
            
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var ad = _context.Advertisements.FirstOrDefault(a => a.Id == id);
            if (ad == null)
            {
                return NotFound();
            }

            _context.Remove(ad);
            _context.SaveChanges();

            return NoContent();

        }

    }
}
