using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly ShopContext context;
        public AdressController(ShopContext shopContext)
        {
            this.context = shopContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdressDTO>>> Get()
        {
            return await context.Adresses
                .Select(x => AdressDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdressDTO>> GetAdressDTO(int id)
        {
            var adressItem = await context.Adresses.FindAsync(id);
            if (adressItem == null)
            {
                return NotFound();
            }
            return AdressDTO(adressItem);
        }

        private static AdressDTO AdressDTO(Adress adress) => new AdressDTO
        {
            Id = adress.Id,
            Street = adress.Street,
            City = adress.City,
            Country = adress.Country,
            HouseNumber = adress.HouseNumber,
            UserId = adress.UserId
        };
    }
}
