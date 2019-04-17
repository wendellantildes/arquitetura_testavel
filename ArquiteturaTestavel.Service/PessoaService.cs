using System;
using ArquiteturaTestavel.Domain;
using ArquiteturaTestavel.Repository;

namespace ArquiteturaTestavel.Service
{
    public class PessoaService
    {

        private readonly PessoaRepository _pessoaRepository;

        public PessoaService()
        {
            _pessoaRepository = new PessoaRepository();
        }

        public bool Adicionar(string nome, DateTime dataNascimento)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("Nome não pode ser nulo");
            }

            if (dataNascimento.Date > DateTime.Now.Date)
            {
                throw new ArgumentException("Data de nascimento não pode ser maior que o dia atual");
            }

            try
            {
                _pessoaRepository.Add(new Pessoa { Nome = nome, DataNascimento = dataNascimento });
                return _pessoaRepository.Commit();
            }
            catch (SqlException)
            {
                throw new ErroCadastroPessoaException();
            }
        }

        public bool Editar(long id, DateTime dataNascimento)
        {
            if (dataNascimento.Date > DateTime.Now.Date)
            {
                throw new ArgumentException("Data de nascimento não pode ser maior que o dia atual");
            }
            var pessoa = _pessoaRepository.Get(id);
            if(pessoa == null)
            {
                throw new NotFoundException();
            }
            try
            {
                pessoa.DataNascimento = dataNascimento;
                _pessoaRepository.Update(pessoa);
                return _pessoaRepository.Commit();
            }
            catch (SqlException)
            {
                throw new ErroCadastroPessoaException();
            }
        }


    }
}
