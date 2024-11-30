using prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace prueba.Controllers
{
    public class EmpleadoController : ApiController
    {    
        private readonly ApplicationDbContext _context;
        public EmpleadoController() { 
          
            _context = new ApplicationDbContext();
        }

        //Lista de empleados
        public IEnumerable<Empleados_prueba> GetEmpleados()
        {
            return _context.Empleados.ToList();
        }

        //empleado por id
        public IHttpActionResult GetEmpleado( int id) {
            var empleado = _context.Empleados.Find(id);
            if (empleado == null)
             return NotFound();
            return Ok(empleado);

        }

        // crear empleado
        public IHttpActionResult CreateEmpleado( [FromBody] Empleados_prueba empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return CreatedAtRoute("DefaultApi", new {id = empleado.id}, empleado);
        }
        // actualizar empleado
        public IHttpActionResult UpdateEmpleado(int id, [FromBody] Empleados_prueba empleados) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var empleadoExiste = _context.Empleados.Find(id);
            if (empleadoExiste == null)
            {
                return NotFound();
            }

            empleadoExiste.nombre = empleados.nombre;
            empleadoExiste.apellido = empleados.apellido;
            empleadoExiste.direccion = empleados.direccion;
            empleadoExiste.dui = empleados.dui;
            empleadoExiste.telefono = empleados.telefono;
            _context.SaveChanges();
            return Ok(empleadoExiste);
        }

        //eliminar un empleado
        public IHttpActionResult DeleteEmpleado(int id) {
            var empleado = _context.Empleados.Find(id);
            if (empleado == null)
            { 
                return NotFound();
                
            }
            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
            return Ok(empleado);

        }
    }
}
