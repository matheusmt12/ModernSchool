﻿using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ComunicacaoService : IComunicacaoService
    {
        private readonly ModernSchoolContext _context;
        public ComunicacaoService(ModernSchoolContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Criar uma comunicacão no banco de dados
        /// </summary>
        /// <param name="comunicacao">Dados da comunicação</param>
        /// <returns>Id da comunicação</returns>
        public int Create(Comunicacao comunicacao)
        {
            _context.Add(comunicacao);
            _context.SaveChanges();

            if (comunicacao.EnviarAlunos > 0)
            {
                Alunocomunicacao alunocomunicacao = new Alunocomunicacao();
                //necessário buscar id da pessoa que está enviando a comunicação ou é o id da turma.
                //se for o idPessoa, será necessário fazer um array com a lista de todos os destinatários
                alunocomunicacao.IdAluno = comunicacao.IdTurma;
                alunocomunicacao.IdComunicacao = comunicacao.Id;

                createAlunoComunicacao(alunocomunicacao);
            }
            if (comunicacao.EnviarResponsaveis > 0)
            {
                Pessoacomunicacao pessoacomunicacao = new Pessoacomunicacao();
                //necessário buscar id da pessoa que está enviando a comunicação ou é o id da turma.
                //se for o idPessoa, será necessário fazer um array com a lista de todos os destinatários
                pessoacomunicacao.IdPessoa = comunicacao.IdTurma;
                pessoacomunicacao.IdComunicacao = comunicacao.Id;

                createPessoaComunicacao(pessoacomunicacao);

            }
            return comunicacao.Id;
        }

        /// <summary>
        /// Deletar uma comunicação no banco de dados
        /// </summary>
        /// <param name="idComunicacao">Id da comunicação</param>
        public void Delete(int idComunicacao)
        {
            var _comuinicacao = _context.Comunicacaos.Find(idComunicacao);
            _context.Remove(_comuinicacao);
            _context.SaveChanges();
        }
        /// <summary>
        /// Editar uma comunicação no banco de dados
        /// </summary>
        /// <param name="comunicacao">Dados do comunicação</param>
        public void Edit(Comunicacao comunicacao)
        {
            _context.Update(comunicacao);
            _context.SaveChanges();
        }

        /// <summary>
        /// Consultar uma comunicação no banco
        /// </summary>
        /// <param name="idComunicacao"></param>
        /// <returns>Dados da comunicação</returns>
        public Comunicacao Get(int idComunicacao)
        {
            return _context.Comunicacaos.Find(idComunicacao);
        }
        /// <summary>
        /// Consultar todos as comunicações no banco
        /// </summary>
        /// <returns>Dados de todas as comunicações</returns>
        public IEnumerable<Comunicacao> GetAll()
        {
            return _context.Comunicacaos.AsNoTracking();
        }
        /// <summary>
        /// Inserindo os dados das comunicações com aluno no banco, tabela alunocomunicacao, relacionamento (n:n)
        /// </summary>
        /// <param name="alunocomunicacao"></param>
        public void createAlunoComunicacao(Alunocomunicacao  alunocomunicacao)
        {
            _context.Add(alunocomunicacao);
            _context.SaveChanges();

        }
        /// <summary>
        /// Inserindo os dados das comunicações com pessoa no banco, tabela pessoacomunicacao, relacionamento (n:n)
        /// </summary>
        /// <param name="pessoacomunicacao"></param>
        private void createPessoaComunicacao(Pessoacomunicacao pessoacomunicacao)
        {
            _context.Add(pessoacomunicacao);
            _context.SaveChanges();
        }
    }
}
