using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagementSystem.Data;
using ProjectManagementSystem.Models;

namespace ProjectManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            var nrcTypes = _context.NRCTypes.ToList();
            var townships = _context.NRCTownships.ToList();
            var regionCodes = townships.Select(t => t.RegionCode_M).Distinct().ToList();

            var departments = _context.StudentDepartments.OrderBy(d => d.DepartmentName).ToList();

            var viewModel = new NRCFormViewModel
            {
                Student = new Student(),
                NRCTypeList = nrcTypes,
                RegionCodeMList = regionCodes,
                TownshipList = townships,
                DepartmentList = departments 
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NRCFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Student.CreatedDate = DateTime.Now;
                model.Student.IsDeleted = false;

                _context.Add(model.Student);
                await _context.SaveChangesAsync();

                // Changed from RedirectToAction(nameof(Index))
                return RedirectToAction("Dashboard", "Student");
            }

            model.NRCTypeList = _context.NRCTypes.ToList();
            model.RegionCodeMList = _context.NRCTownships.Select(t => t.RegionCode_M).Distinct().ToList();
            model.TownshipList = _context.NRCTownships.ToList();
            model.DepartmentList = _context.StudentDepartments.OrderBy(d => d.DepartmentName).ToList(); // reload departments

            return View(model);
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet] 
        public JsonResult GetTownshipsByRegion(string regionCode)
        {
            if (string.IsNullOrEmpty(regionCode))
            {
                return Json(new List<object>());
            }
            var townships = _context.NRCTownships
                .Where(t => t.RegionCode_M == regionCode)
                .Select(t => new {
                    nRC_pkId = t.NRC_pkId,
                    townshipCode_M = t.TownshipCode_M,
                    townshipCode_E = t.TownshipCode_E,
                    townshipName = t.TownshipName
                })
                .OrderBy(t => t.townshipCode_M)
                .ToList();

            return Json(townships);
        }

    }
}
