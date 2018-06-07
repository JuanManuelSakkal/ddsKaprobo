using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador.Clases
{
    public abstract class SubjectSensor
    {
        protected List<SubjectObserverRegla> observadores;

        public void Attach(SubjectObserverRegla observador)
        {
            observadores.Add(observador);
        }

        public void Detach(SubjectObserverRegla observador)
        {
            observadores.Remove(observador);
        }

        public void Notify()
        {
            foreach (SubjectObserverRegla observador in observadores)
            {
                observador.Update();
            }
        }
    }
}
