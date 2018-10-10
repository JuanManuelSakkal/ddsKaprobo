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
        private List<DispositivoInteligente> Dispositivos;
        private JsonAdapter Json;
        private List<Restriccion> Restricciones;

        public Simplex(List<DispositivoInteligente> dispos)
        {
            Json = new JsonAdapter();
            Dispositivos = dispos;
            Restricciones = new List<Restriccion>();
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
                foreach (DispositivoInteligente dispo in Dispositivos)
                {
                    valoresDispositivos.Add(dispo.KwPorHora);
                }
            }
            else
            {
                for (int i = 0; i < Dispositivos.Count(); i++)
                {
                    if (Dispositivos[i] == dispositivoAComparar)
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
            Restricciones.Add(unaRestriccion);
        }
        
        public string Ejecutar()
        {
            if (Restricciones.Count() > 0)
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
            foreach (DispositivoInteligente dispo in Dispositivos)
            {
                cantVars.Add(1);
            }

            json["vars"] = cantVars;

            JArray array = new JArray();

            foreach (Restriccion restriccion in Restricciones)
            {
                JObject restriccionJson = new JObject();

                JArray restriccionValues = new JArray();
                restriccionValues.Add(restriccion.ValorAComparar);
                for (int i = 0; i < restriccion.ValoresDeLosDispositivos.Count(); i++)
                {
                    restriccionValues.Add(restriccion.ValoresDeLosDispositivos[i]);
                }
                restriccionJson["values"] = restriccionValues;

                restriccionJson["operator"] = restriccion.Operador;

                array.Add(restriccionJson);
            }
                
            json["restrictions"] = array;

            return json;
        }
    }
}