using System.ComponentModel.DataAnnotations;

namespace CalculatorWebAPI.DTO
{
    /// <Operation>
    /// Estructura de los datos que enviara el cliente para realizar la suma de los mismos
    /// </Operation>
    public class OperationDTO
    {
        [Range(0, 999999, ErrorMessage ="El valor debe estar entre 0 y 999999")]
        [Required]
        public int num1 { get; set; }
        [Range(0, 999999, ErrorMessage = "El valor debe estar entre 0 y 999999")]
        [Required]
        public int num2 { get; set; }
    }
}