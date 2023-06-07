using System.Collections.Generic;
using System.Linq;

namespace CalculatorWebAPI.BL
{
    /// <Modulo>
    ///     Modulo aparte con las funciones propias para crear una lista con los valores Fibonacci hasta el ciclo 99999999,
    ///     y luego para buscar si un dato se encuentra en dicha lista
    /// </Modulo>
    public class OperationBL: IOperation
    {
        public List<int> ListaFibonacci()
        {
            List<int> lista = new List<int>();
            int n1 = 0;
            int n2 = 1;
            int aux = 0;
            int counter = 0;
            int MAX = 99999999;
            while(counter <= MAX)
            {
                if(counter == 0)
                {
                    counter++;
                    lista.Add(n1);
                }
                else if (counter == 1)
                {
                    counter++;
                    lista.Add(n2);
                }
                else 
                {
                    aux = n1 + n2;
                    n1 = n2;
                    n2 = aux;
                    counter++;
                    lista.Add(aux);
                }
            }
            return lista;
        
        }

        public bool ExisteEnFibonacci(int valor)
        {
            bool existe = false;
            var fibo = ListaFibonacci();
            return existe = fibo.Any(x => x == valor);
        }
    }
}