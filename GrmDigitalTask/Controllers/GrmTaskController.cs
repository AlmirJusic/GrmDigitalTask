using GrmDigitalTask.EF;
using GrmDigitalTask.EntityModels;
using GrmDigitalTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrmDigitalTask.Controllers
{
    public class GrmTaskController : Controller
    {
        private GrmTaskDbContext _context;
        public GrmTaskController(GrmTaskDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<GrmTaskPrikazVM> model = _context.GrmTask.Select(
                x => new GrmTaskPrikazVM
                {
                    ID = x.ID,
                    Name = x.Name,
                    Position = x.Position,
                    Score = x.Score
                }).OrderByDescending(x=>x.Score).ToList();

            var brojac = 0;
            List<GrmTask> grmTask = _context.GrmTask.OrderByDescending(x => x.Score).ToList();
            foreach (var item in grmTask.OrderByDescending(x => x.Score))
            {
                brojac++;
                item.Position = brojac;

                _context.SaveChanges();
            }

            return View(model);
        }
        public IActionResult Dodaj()
        {
            
            GrmTaskDodajVM model = new GrmTaskDodajVM
            {
                GrmTaskList1 = _context.GrmTask.OrderBy(x => x.Name).Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                }).ToList(),
                GrmTaskList2 = _context.GrmTask.OrderBy(x => x.Name).Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                }).ToList()
            };

            return View(model);
        }
        public IActionResult Snimi(GrmTaskDodajVM vm)
        {
            
            if(vm.ID1==vm.ID2)
            {
                ModelState.AddModelError("Drugi", "Morate odabrati razlicite iteme!");
            }
            if(vm.Prvi==vm.Drugi)
            {
                ModelState.AddModelError("Drugi", "Morate unijeti razlicite vrijednosti!");
            }
            
            
            if (!ModelState.IsValid)
            {
                vm.GrmTaskList1 = _context.GrmTask.OrderBy(x => x.Name).Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                }).ToList();
                vm.GrmTaskList2 = _context.GrmTask.OrderBy(x => x.Name).Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Name
                }).ToList();
                   
                return View("Dodaj", vm);
            }
            if (vm.Prvi > vm.Drugi)
            {
                GrmTask grmTask = _context.GrmTask.Find(vm.ID1);
                grmTask.Score++;
            }
            else
            {
                GrmTask grmTask = _context.GrmTask.Find(vm.ID2);
                grmTask.Score++;


            }
            


            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
