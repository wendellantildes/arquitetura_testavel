using System;
using System.Collections.Generic;
using ArquiteturaTestavel.Domain;
using System.Linq;

namespace ArquiteturaTestavel.Repository
{
    public class PessoaRepository
    {
        private readonly List<Pessoa> _banco;

        public PessoaRepository()
        {
            _banco = new List<Pessoa>()
            {
                new Pessoa { Id = Guid.Parse("97234697-0fa1-4910-b3e4-3250e19542a0"), DataNascimento = DateTime.Now.AddYears(20), Nome = "Jon Snow"},
                new Pessoa { Id = Guid.Parse("a9fa9088-47cd-4b87-8163-29132fcb5c2e"), DataNascimento = DateTime.Now.AddYears(-10), Nome = "Daenerys" }
            };
        }

        public void Add(Pessoa pessoa)
        {
            _banco.Add(pessoa);
        }

        public void Update(Pessoa pessoa)
        {
            var pessoaNoBanco = _banco.SingleOrDefault(x => x.Id == pessoa.Id);
            pessoaNoBanco = pessoa;
        }

        public Pessoa Get(Guid id)
        {
            return _banco.SingleOrDefault(x => x.Id == id);
        }

        public List<Pessoa> GetAll()
        {
            //considere para fins didáticos que os objetos Pessoa da nova lista
            // não possuem a mesma 
            //referência em memória da lista de Pessoas de _banco.
            return new List<Pessoa>(_banco);
        }
    }
}
