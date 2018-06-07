using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Integrador.Clases
{
    public class SensorTemperatura : Sensor
    {
        public void Notify(float temperatura)
        {
            foreach (SubjectObserverRegla observador in observadores)
            {
                if (observador.GetType().Equals(typeof(ReglaTemperatura)))
                {
                    ((ReglaTemperatura)observador).Update(temperatura);
                }
            }
        }
    }
}