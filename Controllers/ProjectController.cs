using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ProjectManagementSystem.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Project
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 3;

            var projects = _context.Projects
                .Include(p => p.ProjectType)
                .Include(p => p.Language)
                .Include(p => p.Framework)
                .Include(p => p.Company)
                .OrderByDescending(p => p.ProjectSubmittedDate);

            var pagedProjects = await projects.ToPagedListAsync(page, pageSize);
            return View(pagedProjects);
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var project = await _context.Projects
                .Include(p => p.ProjectType)
                .Include(p => p.Language)
                .Include(p => p.Framework)
                .Include(p => p.Company)
                .FirstOrDefaultAsync(m => m.Project_pkId == id);

            if (project == null)
                return NotFound();

            return View(project);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            LoadDropdownData();
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (!ModelState.IsValid)
            {
                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            LoadDropdownData(project);
            return View(project);
        }
        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return NotFound();

            // Load dropdowns
            ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectType_pkId", "TypeName", project.ProjectType_pkId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Language_pkId", "LanguageName", project.Language_pkId);
            ViewData["FrameworkId"] = new SelectList(_context.Frameworks, "Framework_pkId", "FrameworkName", project.Framework_pkId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Company_pkId", "CompanyName", project.Company_pkId);

            return View(project);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project)
        {
            if (id != project.Project_pkId)
                return NotFound();

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Projects.Any(e => e.Project_pkId == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Re-populate dropdowns on failed save
            ViewData["ProjectTypeId"] = new SelectList(_context.ProjectTypes, "ProjectType_pkId", "TypeName", project.ProjectType_pkId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Language_pkId", "LanguageName", project.Language_pkId);
            ViewData["FrameworkId"] = new SelectList(_context.Frameworks, "Framework_pkId", "FrameworkName", project.Framework_pkId);
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Company_pkId", "CompanyName", project.Company_pkId);

            return View(project);
        }

        // AJAX: Get frameworks for selected language
        [HttpGet]
        public JsonResult GetFrameworksByLanguage(int languageId)
        {
            var frameworks = _context.Frameworks
                .Where(f => f.Language_pkId == languageId)
                .OrderBy(f => f.FrameworkName)
                .Select(f => new
                {
                    framework_pkId = f.Framework_pkId,
                    frameworkName = f.FrameworkName
                })
                .ToList();

            return Json(frameworks);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Load dropdown data for all foreign key fields
        private void LoadDropdownData(Project? selectedProject = null)
        {
            ViewData["ProjectTypes"] = new SelectList(
                _context.ProjectTypes.OrderBy(p => p.TypeName),
                "ProjectType_pkId", "TypeName",
                selectedProject?.ProjectType_pkId);

            ViewData["Languages"] = new SelectList(
                _context.Languages.OrderBy(l => l.LanguageName),
                "Language_pkId", "LanguageName",
                selectedProject?.Language_pkId);

            ViewData["Frameworks"] = new SelectList(
                _context.Frameworks.OrderBy(f => f.FrameworkName),
                "Framework_pkId", "FrameworkName",
                selectedProject?.Framework_pkId);

            ViewData["Companies"] = new SelectList(
                _context.Companies.OrderBy(c => c.CompanyName),
                "Company_pkId", "CompanyName",
                selectedProject?.Company_pkId);
        }
    }
}
