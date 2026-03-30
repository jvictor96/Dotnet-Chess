using DotnetChess.Matches.core;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/matches")]
public class MatchesController : ControllerBase
{
    private readonly MatchService _service;

    public MatchesController(MatchService service) => _service = service;

    [HttpGet]
    public IActionResult GetAll([FromQuery] string player)
    {
        return Ok(_service.GetMatchesForPlayer(player));
    }

    [HttpPost("challenge")]
    public IActionResult Challenge(string player, string opponent, string movement)
    {
        var result = _service.ChallengePlayer(player, opponent, movement);
        return Ok(result);
    }

    [HttpPost("{match}/move")]
    public IActionResult MakeMovement(Guid match, string player, string movement)
    {
        var result = _service.MakeMove(match, player, movement);
        return Ok(result);
    }

    [HttpPost("{match}/resign")]
    public IActionResult Resign(Guid match, string player)
    {
        var result = _service.ResignMatch(match, player);
        return Ok(result);
    }
}