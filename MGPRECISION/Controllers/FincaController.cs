using MGPRECISION.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MGPRECISION.Controllers
{
   
    public class FincaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public FincaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FincaController
        public async Task<ActionResult> Index()
        {
            try
            {
                var listaFicnas = await _context.Fincas.ToListAsync();
                return View(listaFicnas);
            }
            catch (Exception ex) { 
                _logger.LogError(ex, "Error al cargar la pagina");

                return View("Error");
            }
           
        }

        // GET: FincaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FincaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FincaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FincaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FincaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FincaController/Delete/5
        public async Task<ActionResult> Status(int id)
        {
            var datos = await _context.Fincas.FindAsync(id);
            if(datos == null)
            {
               return NotFound();
            }
            return View(datos);
        }

        // POST: FincaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmarStatus(int id)
        {
            try
            {

                var datos = await _context.Fincas.FindAsync();
                if (datos != null)
                {
                    datos.Estado = !datos.Estado;
                  await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", "la finca no se puede cambiar de estado" +
                    " por alguna razon interna" + ex.Message);
                return View("Error");
            }
        }
    }
}
