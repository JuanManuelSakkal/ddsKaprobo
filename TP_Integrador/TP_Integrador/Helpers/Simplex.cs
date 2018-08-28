using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using TP_Integrador.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TP_Integrador.Helpers
{
    public class Simplex
    {
        private List<DispositivoInteligente> dispositivos;
        private JsonAdapter json;
        private List<Restriccion> restricciones;

        public Simplex(List<DispositivoInteligente> dispos)
        {
            json = new JsonAdapter();
            dispositivos = dispos;
            restricciones = new List<Restriccion>();
        }

        public void AgregarRestriccion(double valorAComparar, DispositivoInteligente dispositivoAComparar, string operador)
        {
            List<double> valoresDispositivos = new List<double>();

            //Puedo comparar horas que esta prendido un dispositivo, o consumo de los mismos
            //Si quiero comparar consumos, se pasa null a ese parametro
            //Si quiero un dispositivo en particular, se pasa por parametro el dispositivo
            //seteando todos los valores del list double a 0 menos el de la posicion del dispositivo a comparar
            if (dispositivoAComparar == null)
            {
                foreach (DispositivoInteligente dispo in dispositivos)
                {
                    valoresDispositivos.Add(dispo.kwPorHora);
                }
            }
            else
            {
                for (int i = 0; i < dispositivos.Count(); i++)
                {
                    if (dispositivos[i] == dispositivoAComparar)
                    {
                        valoresDispositivos.Add(1);
                    }
                    else
                    {
                        valoresDispositivos.Add(0);
                    }
                }
            }
            
            //Creo la restriccion
            Restriccion unaRestriccion = new Restriccion(valorAComparar, valoresDispositivos, operador);
            restricciones.Add(unaRestriccion);
        }
        
        public string Ejecutar()
        {
            if (restricciones.Count() > 0)
            {
                var myWebClient = new WebClient();
                myWebClient.Headers.Add("Content-Type", "application/json");

                var sURI = "https://dds-simplexapi.herokuapp.com/consultar";

                JObject json = CrearJson();

                var resultado = myWebClient.UploadString(sURI, json.ToString());

                return resultado;
            }
            return null;
        }

        public JObject CrearJson()
        {
            JObject json = new JObject();

            JArray cantVars = new JArray();
            foreach (DispositivoInteligente dispo in dispositivos)
            {
                cantVars.Add(1);
            }

            json["vars"] = cantVars;

            JArray array = new JArray();

            foreach (Restriccion restriccion in restricciones)
            {
                JObject restriccionJson = new JObject();

                JArray restriccionValues = new JArray();
                restriccionValues.Add(restriccion.valorAComparar);
                for (int i = 0; i < restriccion.valoresDeLosDispositivos.Count(); i++)
                {
                    restriccionValues.Add(restriccion.valoresDeLosDispositivos[i]);
                }
                restriccionJson["values"] = restriccionValues;

                restriccionJson["operator"] = restriccion.operador;

                array.Add(restriccionJson);
            }
                
            json["restrictions"] = array;

            return json;
        }
    }
}