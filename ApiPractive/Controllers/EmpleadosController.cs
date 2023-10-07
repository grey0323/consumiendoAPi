using ApiPractive.Dtos;
using ApiPractive.Method;
using ApiPractive.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiPractive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly ConsultorioContext _context;
        private readonly MethodEmpleados method;
        public EmpleadosController()
        {
            method = new MethodEmpleados();
            _context = new ConsultorioContext();
        }
        // GET: api/<EmpleadosController>

        [HttpGet]
        public ActionResult<List<EmpleadoDto>> Get()
        {
            var EMpleado =  method.Leer();

            if(EMpleado.Count == 0)
            {
                return Problem(statusCode: 4040, detail: "No se encontro ningun empleado");
            }
            else
            {
                return EMpleado;
            }


        }

        // GET api/<EmpleadosController>/5
        [HttpGet("{id}")]
        public ActionResult<EmpleadoDto> GetById(int? id)
        {
            if (id == 0)
            {
                return Problem(statusCode: 404, detail: "Introduzca un valor valido");
            }
           
            var Resultado = method.LeerPorID(id);
            if (Resultado.IdEmpleado == 0)
            {
                return Problem(statusCode: 404, detail: "No se encontro el empleado");
            }
            else
            {
                return Ok(Resultado);
            }

            
            

           
        }

        // POST api/<EmpleadosController>
        [HttpPost]
        public ActionResult Post(EmpleadoDtoPost empleado)
        {
            //if(!ModelState.IsValid) { return Problem(statusCode: 500, detail: "Ah ocurrido un error, verifique los datos ingresados"); }
            method.Guardar(empleado);
            return Ok("Se Guardo correctamente");


        }

        // PUT api/<EmpleadosController>/5
        [HttpPut]
        public ActionResult Put(EmpleadoDto empleado)
        {
            var e = method.Actualizar(empleado);
            if(e == "Los Datos no coinciden")
            {
                return Problem( statusCode:400, detail: "Los Datos no coinciden");
            }
            return Ok(e);
        }

        // DELETE api/<EmpleadosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(id == 0) { return Problem(statusCode: 500, detail: "Ingrese un valor valido por favor"); }
            method.Eliminar(id);
            return Ok();
            
        }
    }
}
