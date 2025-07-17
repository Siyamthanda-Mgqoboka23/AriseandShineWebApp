using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



using System.Linq;
using AriseandShineWebApp.Models; // This is likely where your DbContext is


namespace AriseandShineWebApp.Models

{
   public class SermonsController : Controller
{
    private readonly ApplicationDbContext _context;

    public SermonsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var sermons = await _context.Sermons.OrderByDescending(s => s.Date).ToListAsync();
        return View(sermons);
    }
        // GET: Sermons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sermons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sermon sermon, IFormFile file)
        {
            if (ModelState.IsValid && file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "sermons");
                Directory.CreateDirectory(uploadsFolder); // Ensure folder exists

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                sermon.FilePath = "/sermons/" + fileName;

                _context.Add(sermon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(sermon);
        }
        public async Task<IActionResult> Index(string search)
        {
            ViewData["CurrentFilter"] = search;

            var sermons = from s in _context.Sermons select s;

            if (!string.IsNullOrEmpty(search))
            {
                sermons = sermons.Where(s => s.Title.Contains(search) || s.Description.Contains(search));
            }

            sermons = sermons.OrderByDescending(s => s.Date); // 📅 newest first

            return View(await sermons.ToListAsync());
        }


    }

}
