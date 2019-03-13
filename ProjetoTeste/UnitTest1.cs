using System;
using Xunit;
using WebApplication1.Models;

namespace ProjetoTeste
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            UsuarioModel modelo = new UsuarioModel();
            modelo.Email = "enplat1or@hotmail.com";
            modelo.Senha = "1";
            bool result = modelo.ValidarLogin();
            Assert.True(result);
        }
    }
}
