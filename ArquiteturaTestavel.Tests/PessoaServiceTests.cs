using System;
using ArquiteturaTestavel.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArquiteturaTestavel.Tests
{
    //Ver mais em https://docs.microsoft.com/pt-br/visualstudio/test/unit-test-basics?view=vs-2019


    [TestClass]
    public class PessoaServiceTests
    {
        [TestMethod]
        public void Adicionar_DadosOk_Sucesso()
        {
            //Arrange
            var pessoaService = new PessoaService();
            var nome = "Cersei";
            var dataNascimento = DateTime.Now.AddYears(-10);

            //Act
            pessoaService.Adicionar(nome, dataNascimento);

            //Assert
            var pessoas = pessoaService.ObterTodos();
            var ultimaPessoa = pessoas[pessoas.Count - 1];
            Assert.IsTrue(ultimaPessoa.Nome == nome);
            Assert.IsTrue(ultimaPessoa.DataNascimento == dataNascimento);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Adicionar_NomeNulo_ArgumentException()
        {
            //Arrange
            var pessoaService = new PessoaService();

            //Act
            pessoaService.Adicionar("", DateTime.Now.AddYears(-10));

            // assert is handled by the ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Adicionar_DataNascimentoMaiorQueDiaAtual_ArgumentException()
        {
            //Arrange
            var pessoaService = new PessoaService();

            //Act
            pessoaService.Adicionar("", DateTime.Now.AddYears(10));

            // assert is handled by the ExpectedException
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Editar_DataNascimentoMaiorQueDiaAtual_ArgumentException()
        {
            //Arrange
            var pessoaService = new PessoaService();

            //Act
            pessoaService.Editar(Guid.NewGuid(), DateTime.Now.AddYears(10));

            // assert is handled by the ExpectedException
        }

        //TODO: como testar NotFoundException?
        //TODO: como testar ErroCadastroPessoaException?
    }
}
