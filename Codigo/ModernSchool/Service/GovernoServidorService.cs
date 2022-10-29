﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class GovernoServidorService : IGovernoServidorService
    {
        private readonly ModernSchoolContext _context;

        public GovernoServidorService(ModernSchoolContext context)
        {
            _context = context;
        }   

        /// <summary>
        /// Criar um novo Governo Servidor
        /// </summary>
        /// <param name="governoservidor"></param>
        /// <returns>Id Governo</returns>
        public int Create(Governoservidor governoservidor)
        {
            _context.Add(governoservidor);
            _context.SaveChanges();
            return governoservidor.IdGoverno;
        }

        /// <summary>
        /// Deleta um Governo Servidor
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var governoservidor = _context.Governoservidors.Find(id);
            _context.Remove(governoservidor);
            _context.SaveChanges();
        }

        /// <summary>
        /// Edita um Governo Servidor
        /// </summary>
        /// <param name="governoservidor"></param>
        public void Edit(Governoservidor governoservidor)
        {
            _context.Update(governoservidor);
            _context.SaveChanges();
        }

        /// <summary>
        /// Busca um Governo Servidor
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um Governo Servidor</returns>
        public Governoservidor Get(int id)
        {
            return _context.Governoservidors.Find(id);
        }

        /// <summary>
        /// Busca uma lista de Governo Servidor
        /// </summary>
        /// <returns>Uma lisda de Governo Servidor</returns>
        public IEnumerable<Governoservidor> GetAll()
        {
            return _context.Governoservidors.AsNoTracking();

        }
    }
}
