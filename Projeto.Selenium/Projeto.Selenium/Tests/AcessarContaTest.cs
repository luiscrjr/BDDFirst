using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Projeto.Selenium.Steps;

namespace Projeto.Selenium.Tests
{
    [TestClass]
    public class AcessarContaTest
    {
        private IWebDriver webDriver;

        private const string urlPaginaLogin = "https://lojaexemplod.lojablindada.com/customer/account/login/";
        private const string urlPaginaConta = "https://lojaexemplod.lojablindada.com/customer/account/";


        [TestInitialize]
        public void SetUp()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void AutenticarUsuarioComSucesso()
        {
            webDriver.Navigate().GoToUrl(urlPaginaLogin);

            using (var steps = new AcessarContaSteps(webDriver))
            {
                steps.InformarEmail("sergio.coti@gmail.com");
                steps.InformarSenha("adminadmin");
                steps.SolicitarAcesso();

                Assert.AreEqual(urlPaginaConta, webDriver.Url);
            }
        }

        [TestMethod]
        public void AcessoNegado()
        {
            webDriver.Navigate().GoToUrl(urlPaginaLogin);

            using (var steps = new AcessarContaSteps(webDriver))
            {
                steps.InformarEmail("teste@gmail.com");
                steps.InformarSenha("adminadmin");
                steps.SolicitarAcesso();

                Assert.IsTrue(steps.ObterMensagemAcessoNegado().Contains("Usuário ou Senha Inválido"));
            }
        }
    }
}
