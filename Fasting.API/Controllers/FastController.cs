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

    // Create fast
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

        // Change this to createdAt
        return Ok(fastResponseDto);

        // return CreatedAtAction(nameof(GetFast), new { id = fastResponseDto.Id }, fastResponseDto);
    }

    // Code getAll

    // Code get by id
}
