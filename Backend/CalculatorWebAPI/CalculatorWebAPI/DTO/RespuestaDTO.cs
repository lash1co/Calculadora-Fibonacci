using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorWebAPI.DTO
{
    /// <Respuesta>
    ///  Es la estructura de datos de la respuesta, la cual se envía de vuelta cuando el usuario hace una suma,
    ///  teniendo como datos el resultado de la suma, y el valor si se encuentra o no en la serie de Fibonacci
    /// </Respuesta>
    public class RespuestaDTO
    {
        public int suma { get; set; }
        public bool estaEnFibo { get; set; }
    }
}