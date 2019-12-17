using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Projeto.BDD.TestSteps
{
    [Binding]
    public class AcessarContaTestSteps : IDisposable
    {
        //atributo para acessar os comandos do Selenium WebDriver
        private IWebDriver webDriver;

        [Given(@"Acessar a página de login de usuários")]
        public void DadoAcessarAPaginaDeLoginDeUsuarios()
        {
            //abrindo o navegador
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();

            webDriver.Navigate().GoToUrl("https://lojaexemplod.lojablindada.com/customer/account/login");
        }

        [Given(@"Infomar o email ""(.*)""")]
        public void DadoInfomarOEmail(string email)
        {
            //acessar o campo de texto da página
            var element = webDriver.FindElement(By.CssSelector("#email"));
            element.Clear(); //limpar o conteúdo do campo
            element.SendKeys(email);
        }

        [Given(@"Infomar o a senha ""(.*)""")]
        public void DadoInfomarOASenha(string senha)
        {
            //acessar o campo de senha da página
            var element = webDriver.FindElement(By.CssSelector("#pass"));
            element.Clear(); //limpar o conteúdo do campo
            element.SendKeys(senha);
        }

        [When(@"Solicitar o acesso")]
        public void QuandoSolicitarOAcesso()
        {
            
            var element = webDriver.FindElement(By.CssSelector("#send2"));

            if (element.Displayed && element.Enabled)
            {
                element.Click();
            }
            
        }

        [Then(@"Sistema autentica o usuário")]
        public void EntaoSistemaAutenticaOUsuario()
        {
            Assert.AreEqual("https://lojaexemplod.lojablindada.com/customer/account/", webDriver.Url);
        }

        [Then(@"Sistema exibe mensagem ""(.*)""")]
        public void EntaoSistemaExibeMensagem(string mensagem)
        {
            var element = webDriver.FindElement(By.CssSelector("body > div.wrapper > div > div.main-container.col1-layout > div > div > div > ul > li > ul > li > span"));
            Assert.IsTrue(element.Text.Contains(mensagem));
        }

        public void Dispose()
        {
            webDriver.Quit();
        }
    }
}
