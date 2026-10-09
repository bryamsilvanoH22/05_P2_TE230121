// Ejercicio 5: Control de posición y desplazamiento de un servomotor

Console.WriteLine("SISTEMA DE CONTROL DE SERVOMOTOR");
Console.WriteLine();

// Objeto: Se instancia el objeto "servo1" a partir de la clase Servomotor
Servomotor servo1 = new Servomotor();

// Capturar y validar la posición actual (debe estar entre 0 y 180 grados)
do
{
    Console.Write("Ingrese la posición actual (0 a 180 °): ");
    servo1.PosicionActual = Convert.ToDouble(Console.ReadLine());

    if (servo1.PosicionActual < 0 || servo1.PosicionActual > 180)
    {
        Console.WriteLine("Error: La posición debe estar entre 0 y 180 grados. Intente de nuevo.");
    }
} while (servo1.PosicionActual < 0 || servo1.PosicionActual > 180);

// Capturar y validar la posición objetivo (debe estar entre 0 y 180 grados)
do
{
    Console.Write("Ingrese la posición objetivo (0 a 180 °): ");
    servo1.PosicionObjetivo = Convert.ToDouble(Console.ReadLine());

    if (servo1.PosicionObjetivo < 0 || servo1.PosicionObjetivo > 180)
    {
        Console.WriteLine("Error: La posición debe estar entre 0 y 180 grados. Intente de nuevo.");
    }
} while (servo1.PosicionObjetivo < 0 || servo1.PosicionObjetivo > 180);

// Solicitar al objeto que calcule el desplazamiento absoluto
double desplazamiento = servo1.CalcularDesplazamiento();

// Mostrar resultados con unidades correspondientes (° para grados)
Console.WriteLine();
Console.WriteLine($"Desplazamiento absoluto: {desplazamiento:F2} °");
Console.WriteLine($"Estado del movimiento: {servo1.ObtenerDireccionMovimiento()}");


// Clase: Definición de la clase Servomotor
class Servomotor
{
    // Propiedad: Almacena la posición actual en grados (0 - 180)
    public double PosicionActual { get; set; }

    // Propiedad: Almacena la posición objetivo en grados (0 - 180)
    public double PosicionObjetivo { get; set; }

    // Método: Calcula el desplazamiento absoluto evitando valores negativos
    public double CalcularDesplazamiento()
    {
        double diferencia = PosicionObjetivo - PosicionActual;
        return Math.Abs(diferencia);
    }

    // Método: Determina si el movimiento es hacia una posición mayor, menor o si no hay movimiento
    public string ObtenerDireccionMovimiento()
    {
        if (PosicionObjetivo > PosicionActual)
        {
            return "MOVIMIENTO HACIA UNA POSICION MAYOR";
        }
        else if (PosicionObjetivo < PosicionActual)
        {
            return "MOVIMIENTO HACIA UNA POSICION MENOR";
        }
        else
        {
            return "NO HAY MOVIMIENTO";
        }
    }
}