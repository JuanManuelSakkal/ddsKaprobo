using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Integrador.Clases
{
    public abstract class SubjectObserverRegla
    {
        protected List<ObserverActuador> observadores;

        public void Attach(ObserverActuador observador)
        {
            observadores.Add(observador);
        }

        public void Detach(ObserverActuador observador)
        {
            observadores.Remove(observador);
        }

        public void Notify()
        {
            foreach (ObserverActuador observador in observadores)
            {
                observador.Update();
            }
        }

        public void Update()
        {

        }
    }
}
