using System; //librería de sistema para el uso de funciones matemáticas y de consola
using EcoMovilidad; //importación del espacio de nombres para el uso de la clase AnalisisMovilidad

namespace EcoMovilidadMX //espacio de nombres para la organización del código
{
    class Program //clase principal del programa
    {
        static void Main(string[] args)
        {
        //variables para almacenar los datos de entrada
        string supervisor;
        string evento;
        int bicicletas;
        double horas;

        //variable para almacenar el resultado del cálculo del índice de demanda
        double consumoSinReserva;
        double consumoConReserva;
        double costoOperacion;
        double consumoPromedio;
        int tecnicosNecesarios;
        bool multiploCinco;

        //variables para los resultados de la biblioteca de movilidad
        double indiceDemanda;
        float nivelDesgaste;
        int cargaOperativa;
        double cargaOperativaDouble;
        int consumoConReservaInt;

        //constantes para el cálculo del costo de operación
        const double ConsumoPorBicicleta = 0.35;
        const double Reserva = 0.10;
        const double CostoPorBicicleta = 2.50;
        const int BicicletasPorTecnico = 25;

        //bienvenida al programa
        Console.WriteLine("PROGRAMA ECO MOVILIDAD MX - Planificación de Eventos de Movilidad");
        Console.WriteLine();

        //solicitud de datos al usuario
        Console.Write("Ingresa el nombre del supervisor:");
        supervisor = Console.ReadLine();
        Console.Write("Ingresa el nombre del evento:");
        evento = Console.ReadLine();
        Console.Write("Ingresa el número de bicicletas necesarias:");
        bicicletas = int.Parse(Console.ReadLine());
        Console.Write("Ingresa el número de horas que dura el evento:");
        horas = double.Parse(Console.ReadLine());

        Console.WriteLine();

        //cálculo del consumo total de baterias sin reserva
        consumoSinReserva = bicicletas * horas * ConsumoPorBicicleta;
        //cálculo del costo de operación del evento
        costoOperacion = bicicletas * horas * CostoPorBicicleta;
        //cálculo de la reserva energética del 10% del consumo total de baterias
        consumoConReserva = consumoSinReserva + (consumoSinReserva * Reserva);
        //cálculo del total de técnicos necesarios para el evento, considerando que cada técnico puede atender 25 bicicletas
        tecnicosNecesarios = bicicletas / BicicletasPorTecnico;
        //cálculo del consumo promedio por bicicleta
        consumoPromedio = consumoSinReserva / bicicletas;
        //verificación si el número de bicicletas es múltiplo de 5
        multiploCinco = bicicletas % 5 == 0;
        
        //creación de un objeto de la clase AnalisisMovilidad para realizar cálculos adicionales
        AnalisisMovilidad analisis = new AnalisisMovilidad();
        
        //obtenemos los resultados de la biblioteca de movilidad
        indiceDemanda = analisis.CalcularIndiceDemanda(bicicletas, horas);
        nivelDesgaste = analisis.CalcularDesgaste(bicicletas);
        cargaOperativa = analisis.CalcularCargaOperativa(bicicletas, horas);
        cargaOperativaDouble = cargaOperativa; //convertimos el resultado a double para mostrarlo en la consola
        consumoConReservaInt = (int)consumoConReserva; //convertimos el resultado a entero para mostrarlo en la consola

        //mostramos los resultados en la consola
        Console.WriteLine("RESULTADOS DEL EVENTO DE MOVILIDAD");
        Console.WriteLine("Supervisor: " + supervisor);
        Console.WriteLine("Evento: " + evento);
        Console.WriteLine("Bicicletas: " + bicicletas);
        Console.WriteLine("Duración: " + horas + " horas");
        Console.WriteLine();

        Console.WriteLine("Consumo de batería (sin reserva): " + consumoSinReserva.ToString("F2") + " kWh");
        Console.WriteLine("Costo operativo (sin reserva): $" + costoOperacion.ToString("F2"));
        Console.WriteLine("Reserva energética aplicada: 10%");
        Console.WriteLine("Consumo de batería (con reserva): " + consumoConReserva.ToString("F2") + " kWh");
        Console.WriteLine();

        Console.WriteLine("Técnicos requeridos: " + tecnicosNecesarios);
        Console.WriteLine("Consumo promedio por bicicleta: " + consumoPromedio.ToString("F2") + " kWh");
        
        //verificar si el número de bicicletas es múltiplo de 5 y mostrar un mensaje adicional
        if (multiploCinco)
        { 
            Console.WriteLine("El número de bicicletas es múltiplo de 5, lo que facilita la logística del evento");
        }
        else
        {
            Console.WriteLine("El número de bicicletas no es múltiplo de 5, se recomienda ajustar la cantidad para optimizar la logística");

        }
        Console.WriteLine();

        //resultados de la biblioteca de movilidad
        Console.WriteLine("Índice de demanda: " + indiceDemanda.ToString("F2"));
        Console.WriteLine("Nivel de desgaste estimado: " + nivelDesgaste.ToString("F2"));
        Console.WriteLine("Carga operativa: " + cargaOperativa);

        }

    }
}
