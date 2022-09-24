global using Microsoft.AspNetCore.Mvc;

namespace SuperHero.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly SuperHeroContext _context;
    public SuperHeroController(SuperHeroContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        return Ok(await _context.SuperHeroes.ToListAsync()); 
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);

        if(hero == null)
            return BadRequest("Hero not found!");

        return Ok(hero); 
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        await _context.SuperHeroes.AddAsync(hero);
        await _context.SaveChangesAsync();
        
        return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request, int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);

        if(hero == null)
            return BadRequest("Hero not found");

        hero.Name = request.Name;
        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Place = request.Place;

        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if(hero == null)
            return BadRequest("Hero not found");

        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();

        return Ok(await _context.SuperHeroes.ToListAsync());
    }

}
