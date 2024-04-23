using AutoMapper;
using Fasting.API.Models.Domain;
using Fasting.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fasting.API;

[ApiController]
[Route("api/[controller]")]
public class FastController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IFastingRepository fastingRepository;

    public FastController(IMapper mapper, IFastingRepository fastingRepository)
    {
        this.mapper = mapper;
        this.fastingRepository = fastingRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFastAsync([FromBody] AddFastRequestDto addFastRequestDto)
    {
        if (addFastRequestDto == null)
        {
            return BadRequest();
        }

        var fastDomain = mapper.Map<FastDomain>(addFastRequestDto);

        fastDomain = await fastingRepository.CreateAsync(fastDomain);

        FastDto fastResponseDto = mapper.Map<FastDto>(fastDomain);

        return CreatedAtAction(
            nameof(GetFastByIdAsync),
            new { id = fastResponseDto.Id },
            fastResponseDto
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFastByIdAsync(int id)
    {
        var fast = await fastingRepository.GetByIdAsync(id);

        if (fast == null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<FastDto>(fast));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var fasts = await fastingRepository.GetAllAsync();

        if (fasts == null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<List<FastDto>>(fasts));
    }
}
