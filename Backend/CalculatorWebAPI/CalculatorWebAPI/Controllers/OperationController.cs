using CalculatorWebAPI.BL;
using CalculatorWebAPI.Models;
using CalculatorWebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace CalculatorWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OperationController : ApiController
    {
        geeksBankEntities1 db = new geeksBankEntities1();
        OperationBL modulo = new OperationBL();

        // GET api/<controller>
        public List<operation> Get()
        {
            var datos = db.operation.ToList();
            return datos;
        }

        // GET api/<controller>/5
        public operation Get(int id)
        {
            var registro = db.operation.Where(x => x.id == id).FirstOrDefault();
            return registro;
        }

        // POST api/<controller>
        public RespuestaDTO Post(OperationDTO operation)
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
                var estaEnFibo = modulo.existeEnFibonacci(suma);

                //Se guarda en la base de datos
                db.operation.Add(operation1);
                db.SaveChanges();
            
            //Se envia la respuesta con la estructura de datos establecida
            RespuestaDTO response = new RespuestaDTO();
            response.suma = suma;
            response.estaEnFibo = estaEnFibo;
            return response;
            }
            else
            {
                //No ingresa ningun valor y devuelve 0 en la suma y false para la serie de Fibonacci
                RespuestaDTO response = new RespuestaDTO();
                response.suma = 0;
                response.estaEnFibo = false;
                return response;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}