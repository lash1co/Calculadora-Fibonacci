using System.Collections.Generic;

namespace CalculatorWebAPI.BL
{
    public interface IOperation
    {
        List<int> ListaFibonacci();
        bool ExisteEnFibonacci(int valor);
    }
}
