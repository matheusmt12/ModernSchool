﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IComunicacaoService
    {
        int Create(Comunicacao comunicacao);
        void Edit(Comunicacao comunicacao);
        void Delete(int idComunicacao);
        Comunicacao Get(int idComunicacao);
        IEnumerable<Comunicacao> GetAll();
    }
}
