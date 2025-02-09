﻿using AutoMapper;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModernSchoolWEB.Models;
using Service;

namespace ModernSchoolWEB.Controllers
{
    public class FrequenciaAlunoController : Controller
    {
        private readonly IFrequenciaAlunoService _frequenciaAlunoService;
        private readonly IMapper _mapper;
        public FrequenciaAlunoController(IFrequenciaAlunoService frequenciaAlunoService, IMapper mapper)
        {
            _frequenciaAlunoService = frequenciaAlunoService;
            _mapper = mapper;
        }

        // GET: FrequenciaAlunoController
        public ActionResult Index()
        {
            var listaFrequenciaAluno = _frequenciaAlunoService.GetAllFrequenciaAlunoDTO();
            var listaFrequenciaAlunoModel = _mapper.Map<List<FrequenciaAlunoDTOViewModel>>(listaFrequenciaAluno);
            return View(listaFrequenciaAlunoModel);
        }

        // GET: FrequenciaAlunoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FrequenciaAlunoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FrequenciaAlunoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FrequenciaAlunoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FrequenciaAlunoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(List<FrequenciaAlunoDTOViewModel> frequenciaAlunos)
        {
            Frequenciaaluno frequenciaaluno = new();
            foreach(var frequenciaAlunoDTO in frequenciaAlunos)
            {
                frequenciaaluno = _frequenciaAlunoService.Get(frequenciaAlunoDTO.idAluno,frequenciaAlunoDTO.idDiarioDeClasse);
                if (frequenciaAlunoDTO != null) 
                {
                    if(frequenciaAlunoDTO.presente == true)
                    {
                        frequenciaaluno.Faltas++;
                    }
                    
                    _frequenciaAlunoService.Edit(frequenciaaluno);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: FrequenciaAlunoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FrequenciaAlunoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
