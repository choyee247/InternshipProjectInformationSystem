using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Models;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using ProjectManagementSystem.Data;

public class InternComsController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public InternComsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    // GET: InternComs
    public async Task<IActionResult> Index()
    {
        return View(await _context.InternComs.ToListAsync());
    }

    // GET: InternComs/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var internCom = await _context.InternComs.FirstOrDefaultAsync(m => m.Id == id);
        if (internCom == null) return NotFound();

        return View(internCom);
    }

    // GET: InternComs/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: InternComs/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(InternComViewModel model)
    {
        if (ModelState.IsValid)
        {
            string uniqueFileName = await SaveImage(model.ImageFile);

            var internCom = new InternCom
            {
                Name = model.Name,
                Industry = model.Industry,
                Description = model.Description,
                Website = model.Website,
                Image = "/Companies/" + uniqueFileName,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                OffersInternships = model.OffersInternships
            };

            _context.Add(internCom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    // GET: InternComs/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var internCom = await _context.InternComs.FindAsync(id);
        if (internCom == null) return NotFound();

        var model = new InternComViewModel
        {
            Id = internCom.Id,
            Name = internCom.Name,
            Industry = internCom.Industry,
            Description = internCom.Description,
            Website = internCom.Website,
            ExistingImage = internCom.Image,
            Address = internCom.Address,
            City = internCom.City,
            Country = internCom.Country,
            Email = internCom.Email,
            PhoneNumber = internCom.PhoneNumber,
            OffersInternships = internCom.OffersInternships
        };

        return View(model);
    }

    // POST: InternComs/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, InternComViewModel model)
    {
        if (id != model.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                var internCom = await _context.InternComs.FindAsync(id);
                if (internCom == null) return NotFound();

                internCom.Name = model.Name;
                internCom.Industry = model.Industry;
                internCom.Description = model.Description;
                internCom.Website = model.Website;
                internCom.Address = model.Address;
                internCom.City = model.City;
                internCom.Country = model.Country;
                internCom.Email = model.Email;
                internCom.PhoneNumber = model.PhoneNumber;
                internCom.OffersInternships = model.OffersInternships;

                if (model.ImageFile != null)
                {
                    if (!string.IsNullOrEmpty(internCom.Image))
                    {
                        var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, internCom.Image.TrimStart('/'));
                        if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
                    }
                    internCom.Image = "/Companies/" + await SaveImage(model.ImageFile);
                }

                _context.Update(internCom);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.InternComs.Any(e => e.Id == model.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    // GET: InternComs/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var internCom = await _context.InternComs.FirstOrDefaultAsync(m => m.Id == id);
        if (internCom == null) return NotFound();

        return View(internCom);
    }

    // POST: InternComs/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var internCom = await _context.InternComs.FindAsync(id);
        if (internCom != null)
        {
            if (!string.IsNullOrEmpty(internCom.Image))
            {
                var oldPath = Path.Combine(_webHostEnvironment.WebRootPath, internCom.Image.TrimStart('/'));
                if (System.IO.File.Exists(oldPath)) System.IO.File.Delete(oldPath);
            }

            _context.InternComs.Remove(internCom);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private async Task<string> SaveImage(IFormFile? imageFile)
    {
        if (imageFile == null) return "";

        string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Companies");
        Directory.CreateDirectory(uploadFolder); // Ensure folder exists

        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
        string filePath = Path.Combine(uploadFolder, uniqueFileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(fileStream);
        }

        return uniqueFileName;
    }
}
