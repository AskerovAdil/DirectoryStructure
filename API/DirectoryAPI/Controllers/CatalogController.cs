using AutoMapper;
using DataAccess.Entities;
using DirectoryAPI.Models;
using Domain.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogItemService _catalogService;
        private readonly IMapper _mapper;
        public CatalogController(ICatalogItemService catalogService, IMapper mapper)
        {
            _mapper = mapper;
            _catalogService = catalogService;
        }

        [HttpGet]
        public async Task<IEnumerable<CatalogItem>> GetAllAsync()
        {
            return await _catalogService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogItem>> GetByIdAsync(int id)
        {
            var catalogItem = await _catalogService.GetByIdAsync(id);
            return catalogItem == null ? NotFound() : catalogItem;
        }

        [HttpPost]
        public async Task<ActionResult<CatalogItem>> AddAsync([FromBody] CatalogItemDto catalogItem)
        {
            try
            {
                var catalog = _mapper.Map<CatalogItem>(catalogItem);
                await _catalogService.AddAsync(catalog);
                return Ok(catalogItem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CatalogItemDto catalogItemDto)
        {
            var catalog = _mapper.Map<CatalogItem>(catalogItemDto);
            catalog.Id = id;
            try
            {
                await _catalogService.UpdateAsync(catalog);
                return Ok(catalog);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _catalogService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
