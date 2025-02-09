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
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly ModernSchoolContext _context;

        public AvaliacaoService(ModernSchoolContext context)
        {
            _context = context;
        }
        public int Create(Avaliacao avaliacao)
        {
            _context.Add(avaliacao);
            _context.SaveChanges();

            return avaliacao.Id;
            //throw new NotImplementedException();
        }

        public void Delete(int idAvaliacao)
        {
            var _avaliacao = _context.Avaliacaos.Find(idAvaliacao);
            _context.Remove(_avaliacao);
            _context.SaveChanges();

            //throw new NotImplementedException();
        }

        public void Edit(Avaliacao avaliacao)
        {

            _context.Update(avaliacao);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public Avaliacao Get(int idAvaliacao)
        {
            return _context.Avaliacaos.Find(idAvaliacao);
            //throw new NotImplementedException();
        }

        public IEnumerable<Avaliacao> GetAll()
        {

            return _context.Avaliacaos.AsNoTracking();
            //throw new NotImplementedException();
        }
    }
}
