using System; //librería de sistema para el uso de funciones matemáticas y de consola

namespace EcoMovilidad //espacio de nombres para la organización del código
{
    public class AnalisisMovilidad //clase pública para el analisis de la movilidad urbana
    {
        //método 1 para el calculo del indice de demanda del servicio
        public double CalcularIndiceDemanda(int bicicletas, double horas)
        {
            return (bicicletas * horas * 0.12) + 25;
        }

        //método 2 para el calculo del nivel de desgaste estimado
        public float CalcularDesgaste(int bicicletas)
        {
            return 5f + (bicicletas / 20f);
        }

        //método 3 para el calculo de la carga operativa del evento
        public int CalcularCargaOperativa(int bicicletas, double horas)
        {
            return (int)(bicicletas * horas * 1.5);
        }
    }
}