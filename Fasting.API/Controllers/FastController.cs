using AutoMapper;
using Fasting.API.Models.Domain;
using Fasting.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Fasting.API;

[ApiController]
[Route("api/[controller]")]
public class FastController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IFastingRepository _fastingRepository;
    private readonly ILogger<FastController> _logger;

    public FastController(
        IMapper mapper,
        IFastingRepository fastingRepository,
        ILogger<FastController> logger
    )
    {
        this._mapper = mapper;
        this._fastingRepository = fastingRepository;
        this._logger = logger;
    }

    private void LogInformation(string message)
    {
        _logger.LogInformation(message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFastAsync([FromBody] AddFastRequestDto addFastRequestDto)
    {
        if (addFastRequestDto == null)
        {
            return BadRequest();
        }

        var fastDomain = _mapper.Map<FastDomain>(addFastRequestDto);

        fastDomain = await _fastingRepository.CreateAsync(fastDomain);

        FastDto fastResponseDto = _mapper.Map<FastDto>(fastDomain);

        return CreatedAtAction(
            nameof(GetFastByIdAsync),
            new { id = fastResponseDto.Id },
            fastResponseDto
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFastByIdAsync(int id)
    {
        var fast = await _fastingRepository.GetByIdAsync(id);

        if (fast == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<FastDto>(fast));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var fasts = await _fastingRepository.GetAllAsync();

        if (fasts == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<List<FastDto>>(fasts));
    }

    // end fast
    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateFastAsync(int id)
    // {
    //     // if (updateFastRequestDto == null)
    //     // {
    //     //     return BadRequest();
    //     // }

    //     var fast = await fastingRepository.GetByIdAsync(id);

    //     if (fast == null)
    //     {
    //         return NotFound();
    //     }

    //     mapper.Map(updateFastRequestDto, fast);

    //     fast = await fastingRepository.UpdateAsync(id, fast);

    //     return Ok(mapper.Map<FastDto>(fast));
    // }
}
