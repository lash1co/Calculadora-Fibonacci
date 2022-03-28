using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CalculatorWebAPI.DTO
{
    /// <Operation>
    /// Estructura de los datos que enviara el cliente para realizar la suma de los mismos
    /// </Operation>
    public class OperationDTO
    {
        [Required]
        public int num1 { get; set; }
        [Required]
        public int num2 { get; set; }
    }
}