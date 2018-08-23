using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using TP_Integrador.Clases;


namespace TP_Integrador.Tests
{
    [TestFixture]

    public class CreationalTests
    {

        public Usuario crearUsuario()
        {
            return new Usuario(1,"robertocapo","holis","Roberto","Martinez","Segurola y Habana");
        }

        public DispositivoEstandar crearDispositivoEstandar()
        {
            return new DispositivoEstandar("Whirpool", 1000);
        }

        [Test]
        public void Crear_Usuario()
        {
            var usuario = crearUsuario();

            Assert.IsInstanceOf(typeof(Usuario), usuario);
        }

        [Test]
        public void Chequear_nombre_usuario()
        {
            var usuario = crearUsuario();

            Assert.AreEqual("robertocapo", usuario.nombreUsuario);
        }

        [Test]
        public void Crear_Dispositivo_Estandar()
        {
            var dEstandar = crearDispositivoEstandar();

            Assert.IsInstanceOf(typeof(DispositivoEstandar), dEstandar);
        }
    }
}