using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartphoneShop.Data;
using SmartphoneShop.Models;

namespace SmartphoneShop.Controllers
{
    public class SmartphonesController : Controller
    {
        private readonly ShopContext _context;

        public SmartphonesController(ShopContext context)
        {
            _context = context;
        }

        // GET: Smartphones
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ModelSortParm"] = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var smartphones = from b in _context.Smartphones
                            select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                smartphones = smartphones.Where(s => s.Model.Contains(searchString));
            }
            switch (sortOrder)
                {
                    case "model_desc":
                        smartphones = smartphones.OrderByDescending(b => b.Model);
                        break;
                    case "Price":
                        smartphones = smartphones.OrderBy(b => b.Price);
                        break;
                    case "price_desc":
                        smartphones = smartphones.OrderByDescending(b => b.Price);
                        break;
                    default:
                        smartphones = smartphones.OrderBy(b => b.Model);
                    break;
            }
            int pageSize = 2;
            return View(await PaginatedList<Smartphone>.CreateAsync(smartphones.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Smartphones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var smartphone = await _context.Smartphones
                .Include(s => s.Orders)
                .ThenInclude(e => e.Customer)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (smartphone == null)
            {
                return NotFound();
            }

            return View(smartphone);
        }

        // GET: Smartphones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Smartphones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Model,Manufacturer,Price")] Smartphone smartphone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(smartphone);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex*/)
            {

                ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists ");
            }
            return View(smartphone);
        }

        // GET: Smartphones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartphone = await _context.Smartphones.FindAsync(id);
            if (smartphone == null)
            {
                return NotFound();
            }
            return View(smartphone);
        }

        // POST: Smartphones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var studentToUpdate = await _context.Smartphones.FirstOrDefaultAsync(s => s.ID == id);
            if (await TryUpdateModelAsync<Smartphone>(studentToUpdate,"", s => s.Manufacturer, s => s.Model, s => s.Price))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " + "Try again, and if the problem persists");
                }
            }
            return View(studentToUpdate);
        }


        // GET: Smartphones/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smartphone = await _context.Smartphones
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (smartphone == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again";
            }

            return View(smartphone);
        }

        // POST: Smartphones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smartphone = await _context.Smartphones.FindAsync(id);
            if (smartphone == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Smartphones.Remove(smartphone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            catch (DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool SmartphoneExists(int id)
        {
            return _context.Smartphones.Any(e => e.ID == id);
        }
    }
}
