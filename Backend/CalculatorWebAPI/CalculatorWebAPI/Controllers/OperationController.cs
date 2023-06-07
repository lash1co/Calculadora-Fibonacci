using CalculatorWebAPI.BL;
using CalculatorWebAPI.Models;
using CalculatorWebAPI.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CalculatorWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OperationController : ApiController
    {

        private readonly geeksBankEntities1 _context;
        private readonly IOperation _operation;

        public OperationController(IOperation operation, geeksBankEntities1 context)
        {
            _operation = operation;
            _context = context;
        }

        // GET api/<controller>
        public List<operation> Get()
        {
            var datos = _context.operation.ToList();
            return datos;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var registro = _context.operation.Where(x => x.id == id).FirstOrDefault();
            if(registro == null )
                return NotFound();
            return Ok(registro);
        }

        // POST api/<controller>
        public IHttpActionResult Post(OperationDTO operation)
        {
            if (ModelState.IsValid)
            {
                //Se realiza la suma de los dos números
                var suma = operation.num1 + operation.num2;

                //Se crea un nuevo objeto para guardar en la base de datos
                operation operation1 = new operation();
                operation1.num1 = operation.num1;
                operation1.num2 = operation.num2;
                operation1.result = suma;

                //Se verifica si se encuentra el valor dentro de la serie de Fibonacci
                var estaEnFibo = _operation.ExisteEnFibonacci(suma);
                operation1.isInFibonacci = estaEnFibo;
                //Se guarda en la base de datos
                _context.operation.Add(operation1);
                _context.SaveChanges();
            
                //Se envia la respuesta con la estructura de datos establecida
                RespuestaDTO response = new RespuestaDTO();
                response.suma = suma;
                response.estaEnFibo = estaEnFibo;
                return Ok(response);
            }
            else
            {
                return BadRequest("Parametros invalidos para la operación");
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, OperationDTO updatedOperation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Los parametros son incorrectos");
            }
            var operation = _context.operation.FirstOrDefault(x => x.id == id);
            if(operation == null) 
                return NotFound();
            operation.num1 = updatedOperation.num1;
            operation.num2 = updatedOperation.num2;
            var suma = operation.num1 + operation.num2;
            operation.result = suma;
            var estaEnFibo = _operation.ExisteEnFibonacci(suma);
            operation.isInFibonacci= estaEnFibo;
            _context.SaveChanges();
            //Se envia la respuesta con la estructura de datos establecida
            RespuestaDTO response = new RespuestaDTO();
            response.suma = suma;
            response.estaEnFibo = estaEnFibo;
            return Ok(response);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var operation = _context.operation.Find(id); 
            if (operation != null)
            {
                _context.operation.Remove(operation);
                _context.SaveChanges();
                return Ok(operation);
            }
            else 
            { 
                return NotFound(); 
            }  
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);    
        }
    }
}