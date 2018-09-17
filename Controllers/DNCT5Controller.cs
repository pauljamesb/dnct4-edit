using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNCT5.Data;
using Microsoft.AspNetCore.Mvc;

namespace DNCT5.Controllers
{
    public class DNCT5Controller : Controller
    {

        private readonly ApplicationDbContext _db;

        public DNCT5Controller(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Items.ToList());
        }

        // GET Edit Action Method
        public async Task<IActionResult> Edit(int? id)
        {
          if(id == null)
          {
              return NotFound();
          }
          var item = await _db.items.FindAsync(id);
          if(item == null)
          {
            return NotFound();
          }
          return View(item);
        }

        // POST Edit Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Item item)
        {
          if(id!=item.Id)
          {
            return NotFound();
          }
          if(ModelState.IsValid)
          {
            _db.Update(item);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
          }
          return View(item);
        }

    }
}
