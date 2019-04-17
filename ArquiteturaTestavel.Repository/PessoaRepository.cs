using System;
using ArquiteturaTestavel.Domain;

namespace ArquiteturaTestavel.Repository
{
    public class PessoaRepository
    {
        public void Add(Pessoa pessoa)
        {

        }

        public void Update(Pessoa pessoa)
        {

        }

        public Pessoa Get(long id)
        {
            return new Pessoa { Id = id, DataNascimento = DateTime.Now.AddYears(-10), Nome = "Daenerys" };
        }

        public bool Commit()
        {
            return true;
        }
    }
}
