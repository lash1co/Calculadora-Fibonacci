using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculatorWebAPI.DTO
{
    /// <Operation>
    /// Estructura de los datos que enviara el cliente para realizar la suma de los mismos
    /// </Operation>
    public class OperationDTO
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
    }
}