using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers;

public class ClaimsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ClaimsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        IEnumerable<Claim> claims = _context.Claim;
        return View(claims);
    }
    
    public IActionResult FileUpload()
    {
        return View();
    }
    
    

    /// <summary>
    /// Copy the file to the server and call the Parse method to parse the file.
    /// </summary>
    /// <param name="file"> The file to parse. </param>
    /// <returns> The result of the parse. </returns>
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile? file)
    {
        // full path to file in temp location
        var filePath = Path.GetTempFileName();
        if (file is not { Length: > 0 }) return Content("Empty or Null File");
        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Parse the file and store the data in the database.
        await Parse(filePath);
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Parse the file and store the claims in the database.
    /// </summary>
    /// <param name="filePath">
    /// The full path to the file to parse.
    /// </param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Parse(string filePath)
    {
        var parser = new Parser(filePath);
        var claims = parser.Parse();
        foreach (var claim in claims)
        {
            _context.Claim.Add(claim);
        }
        await _context.SaveChangesAsync();
        return Ok();
    }
}

