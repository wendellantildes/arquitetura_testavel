using System;
using ArquiteturaTestavel.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArquiteturaTestavel.Tests
{
    [TestClass]
    public class PessoaServiceTests
    {
        [TestMethod]
        public void Adicionar_DadosOk_Sucesso()
        {
            var pessoaService = new PessoaService();
            var resultado = pessoaService.Adicionar("Daenerys", DateTime.Now.AddYears(-10));
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Adicionar_NomeNulo_ArgumentException()
        {
            var pessoaService = new PessoaService();
            var resultado = pessoaService.Adicionar("", DateTime.Now.AddYears(-10));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Adicionar_DataNascimentoMaiorQueDiaAtual_ArgumentException()
        {
            var pessoaService = new PessoaService();
            var resultado = pessoaService.Adicionar("", DateTime.Now.AddYears(10));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Editar_DataNascimentoMaiorQueDiaAtual_ArgumentException()
        {
            var pessoaService = new PessoaService();
            var resultado = pessoaService.Editar(100, DateTime.Now.AddYears(10));
        }

        //TODO: como testar NotFoundException?
        //TODO: como testar ErroCadastroPessoaException?
    }
}
