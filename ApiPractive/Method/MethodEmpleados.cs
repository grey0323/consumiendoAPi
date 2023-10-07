using ApiPractive.Dtos;
using ApiPractive.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractive.Method
{
    public class MethodEmpleados
    {
        private readonly ConsultorioContext _context;
        public MethodEmpleados()
        {
            _context = new ConsultorioContext();
        }

        public List<EmpleadoDto> Leer()
        {
            var empleadodto = new List<EmpleadoDto>();
            var empleados = _context.Empleados.ToList();
          
                foreach (var empleado in empleados)
                {
                    empleadodto.Add(new EmpleadoDto
                    {
                        Nombre = empleado.Nombre,
                        Apellido = empleado.Apellido,
                        Puesto = empleado.Puesto,
                        IdEmpleado = empleado.IdEmpleado,

                    });
                }

                return empleadodto;
            
        }

        public EmpleadoDto LeerPorID(int? id)
        {
            var EmpleadoDto = new EmpleadoDto();
            var Empleado = _context.Empleados.FirstOrDefault(x=> x.IdEmpleado == id);
            if (Empleado == null)
            {
                return EmpleadoDto;
            }
            else
            {
                EmpleadoDto.Nombre = Empleado.Nombre;
                EmpleadoDto.IdEmpleado = Empleado.IdEmpleado;
                EmpleadoDto.Apellido = Empleado.Apellido;
                EmpleadoDto.Puesto = Empleado.Puesto;
                return EmpleadoDto;
            }
           

            
        }

        public void Guardar(EmpleadoDtoPost empleado)
        {
            var Empleado = new Empleado() { Apellido = empleado.Apellido, Nombre = empleado.Nombre, Puesto = empleado.Puesto };
            _context.Empleados.Add(Empleado);
            _context.SaveChanges();
        }

        public string Actualizar(EmpleadoDto empleado)
        {
            var EmpleadoSr = _context.Empleados.FirstOrDefault(x=> x.IdEmpleado ==  empleado.IdEmpleado);
            if (EmpleadoSr == null)
            {
                return "Los Datos no coinciden";

            }
            EmpleadoSr.Apellido = empleado.Apellido;
            EmpleadoSr.Nombre = empleado.Nombre;
            EmpleadoSr.Puesto = empleado.Puesto;

            _context.Empleados.Update(EmpleadoSr);
            _context.SaveChanges();
            return "Se actualizo correctamente";


        }

        public bool Eliminar(int id)
        {
            var empleadoEliminar = _context.Empleados.FirstOrDefault(x=> x.IdEmpleado == id);
            if(empleadoEliminar == null)
            {
                return false;
            }

            _context.Empleados.Remove(empleadoEliminar);
            _context.SaveChanges();
            return true;
        }


    }
}
