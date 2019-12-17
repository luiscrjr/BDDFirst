using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Selenium.Steps
{
    public class AcessarContaSteps : IDisposable
    {
        private readonly IWebDriver webDriver;

        public AcessarContaSteps(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void InformarEmail(string email)
        {
            var element = webDriver.FindElement(By.CssSelector("#email"));
            element.SendKeys(email);
        }

        public void InformarSenha(string senha)
        {
            var element = webDriver.FindElement(By.CssSelector("#pass"));
            element.SendKeys(senha);
        }

        public void SolicitarAcesso()
        {
            var element = webDriver.FindElement(By.CssSelector("#send2"));
            element.Click();
        }

        public string ObterMensagemAcessoNegado()
        {
            var element = webDriver.FindElement(By.CssSelector("body > div.wrapper > div > div.main-container.col1-layout > div > div > div > ul > li > ul > li > span"));
            return element.Text;
        }

        public void Dispose()
        {
            webDriver.Quit();
        }
    }
}
