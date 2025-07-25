using Microsoft.AspNetCore.Mvc;
using PhotographyOfMovingObjects;

namespace Project.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigurationController : ControllerBase
{
    /// <summary>
    /// Returns the configured "Fall Delay".
    /// </summary>
    [HttpGet("Delay")]
    [ProducesResponseType<int>(StatusCodes.Status200OK, "text/plain")]
    public IActionResult GetFallDelayMs()
    {
        return Ok(Photography.FallDelay.Milliseconds);
    }
    
    /// <summary>
    /// Sets the "Fall Delay"
    /// </summary>
    /// <param name="delayMs">Milliseconds</param>
    [HttpPatch("Delay/{delayMs}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult SetFallDelayMs(int delayMs)
    {
        Photography.SetFallDelay(TimeSpan.FromMilliseconds(delayMs));
        return Ok();
    }
    
    /// <summary>
    /// Returns the configured "Camera Delay".
    /// </summary>
    [HttpGet("Camera/Delay")]
    [ProducesResponseType<int>(StatusCodes.Status200OK, "text/plain")]
    public IActionResult GetCameraDelayMs()
    {
        return Ok(Photography.DelayCamera.Milliseconds);
    }
    
    /// <summary>
    /// Sets the "Camera Delay"
    /// </summary>
    /// <param name="delayMs">Milliseconds</param>
    [HttpPatch("Camera/Delay/{delayMs}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult SetCameraDelayMs(int delayMs)
    {
        Photography.SetCameraDelay(TimeSpan.FromMilliseconds(delayMs));
        return Ok();
    }
    
    /// <summary>
    /// Returns the configured "Flash Delay".
    /// </summary>
    [HttpGet("Flash/Delay")]
    [ProducesResponseType<int>(StatusCodes.Status200OK, "text/plain")]
    public IActionResult GetFlashDelayMs()
    {
        return Ok(Photography.DelayFlash.Milliseconds);
    }
    
    /// <summary>
    /// Sets the "Camera Delay"
    /// </summary>
    /// <param name="delayMs">Milliseconds</param>
    [HttpPatch("Flash/Delay/{delayMs}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult SetFlashDelayMs(int delayMs)
    {
        Photography.SetFlashDelay(TimeSpan.FromMilliseconds(delayMs));
        return Ok();
    }

    /// <summary>
    /// Returns the GPIO Pin-Number of the Flash
    /// </summary>
    [HttpGet("Flash/PinNumber")]
    [ProducesResponseType<int>(StatusCodes.Status200OK, "text/plain")]
    public IActionResult GetFlashGpioPin()
    {
        return Ok(Flash.PinNumber);
    }

    /// <summary>
    /// Sets the GPIO Pin-Number of the Flash
    /// </summary>
    /// <param name="pinNumber"></param>
    [HttpPatch("Flash/PinNumber/{pinNumber}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult SetFlashGpioPin(int pinNumber)
    {
        Flash.SetFlashPin(pinNumber);
        return Ok();
    }

    /// <summary>
    /// Returns the GPIO Pin-Number of the Trigger
    /// </summary>
    [HttpGet("Trigger/PinNumber")]
    [ProducesResponseType<int>(StatusCodes.Status200OK, "text/plain")]
    public IActionResult GetTriggerGpioPin()
    {
        return Ok(Trigger.PinNumber);
    }
    
    /// <summary>
    /// Sets the GPIO Pin-Number of the Trigger
    /// </summary>
    /// <param name="pinNumber"></param>
    [HttpPatch("Trigger/PinNumber/{pinNumber}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult SetTriggerGpioPin(int pinNumber)
    {
        Trigger.SetTriggerPin(pinNumber);
        return Ok();
    }

    /// <summary>
    /// Sets whether to re-arm the system after every picture
    /// </summary>
    /// <param name="toggle">true to rearm</param>
    [HttpPatch("ArmedAfterEveryPicture/{toggle}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ArmedAfterEveryPicture(bool toggle)
    {
        Photography.ArmedAfterEveryPicture = toggle;
        return Ok();
    }

    /// <summary>
    /// Gets whether system is rearmed after every picture
    /// </summary>
    [HttpGet("ArmedAfterEveryPicture")]
    [ProducesResponseType<bool>(StatusCodes.Status200OK, "text/plain")]
    public IActionResult GetArmedAfterEveryPicture()
    {
        return Ok(Photography.ArmedAfterEveryPicture);
    }
}