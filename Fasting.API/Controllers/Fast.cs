using Microsoft.AspNetCore.Mvc;

namespace Fasting.API;

public class Fast : ControllerBase
{
    public IActionResult HelloWorld()
    {
        return Ok("Hello, World!");
    }

    // Create fast
    [HttpPost]
    public async Task<IActionResult> StartFastAsync()
    {
        return Ok("Fast started");
    }
}
