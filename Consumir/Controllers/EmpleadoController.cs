using Consumir.Method;
using Consumir.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Consumir.Controllers
{
    public class EmpleadoController : Controller
    {
        
        private readonly MethodsEmpleados methods;
        public EmpleadoController()
        {
            methods = new MethodsEmpleados();
            
        }
        public IActionResult Index()
        {
            
            return View(methods.Leer().Result);
        }

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Guardar(EmpleadoViewModelPost empleado)
        {
            methods.Guardar(empleado);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
           var e = methods.CargarDato(id).Result;
           return View(e);

        }

        [HttpPost]
        public async Task<IActionResult> Update(EmpleadoViewModel empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await methods.Update(empleado);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var e = methods.CargarDato(id).Result;
            return View(e);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int IdEmpleado)
        {
            if(IdEmpleado == null)
            {
                return BadRequest();
            }
            methods.Eliminar(IdEmpleado);
            return RedirectToAction("Index");
        }
    }
}
