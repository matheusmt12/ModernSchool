﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Service;
using AutoMapper;
using ModernSchoolWEB.Models;
using Core;
using Core.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ModernSchoolWEB.Controllers
{
    public class GovernoServidorController : Controller
    {

        private readonly IGovernoServidorService _governoService;
        private readonly IMapper _mapper;
        private readonly IPessoaService _pessoaService;
        private readonly ICargoService _cargoService;
        private readonly IGovernoService _governoServiceG;

        public GovernoServidorController(IGovernoServidorService governoService,
            IMapper mapper, IPessoaService pessoaService, ICargoService cargoService,
            IGovernoService governoServiceG)
        {
            _governoService = governoService;
            _mapper = mapper;
            _pessoaService = pessoaService;
            _cargoService = cargoService;
            _governoServiceG = governoServiceG;
        }



        // GET: GovernoServidorController
        public ActionResult Index()
        {
            var listaGovernoS = _governoService.GetAllDTO();
            var listaGovernoM = _mapper.Map<List<GovernoServidorDTOModel>>(listaGovernoS);

            return View(listaGovernoM);
        }

        // GET: GovernoServidorController/Details/5
        public ActionResult Details(int id)
        {
            GovernoServidorDTO? governoServidor = _governoService.GetDTO(id);
            var governoServidorM = _mapper.Map<GovernoServidorDTOModel>(governoServidor);

            return View(governoServidorM);
        }

        // GET: GovernoServidorController/Create
        public ActionResult Create()
        {
            GovernoServidorModel governoServidorModel = new GovernoServidorModel();

            IEnumerable<Governo> listaGoverno = _governoServiceG.GetAll();
            IEnumerable<Pessoa> listaPessoa = _pessoaService.GetAll();
            IEnumerable<Cargo> listaCargo = _cargoService.GetAll();

            governoServidorModel.listaGoverno = new SelectList(listaGoverno, "Id", "Municipio",null);
            governoServidorModel.listaPessoa = new SelectList(listaPessoa, "Id", "Nome", null);
            governoServidorModel.listaCargo = new SelectList(listaCargo, "IdCargo", "Descricao", null);




            return View(governoServidorModel);
        }

        // POST: GovernoServidorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GovernoServidorModel governoservidorM)
        {
            if (ModelState.IsValid)
            {
                var governoServidor = _mapper.Map<Governoservidor>(governoservidorM);
                _governoService.Create(governoServidor);
            }

            return RedirectToAction(nameof(Index));


        }

        // GET: GovernoServidorController/Edit/5
        public ActionResult Edit(int id)
        {
            Governoservidor governoservidor = _governoService.Get(id);
            GovernoServidorModel governoModel = _mapper.Map<GovernoServidorModel>(governoservidor);

            return View(governoModel);
        }

        // POST: GovernoServidorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GovernoServidorModel governoServidorModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<Governoservidor>(governoServidorModel);
                _governoService.Edit(model);
            }
            return RedirectToAction(nameof(Index));


        }

        // GET: GovernoServidorController/Delete/5
        public ActionResult Delete(int id)
        {
            GovernoServidorDTO? governoS = _governoService.GetDTO(id);
            GovernoServidorDTOModel model = _mapper.Map<GovernoServidorDTOModel>(governoS);

            return View(model);
        }

        // POST: GovernoServidorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, GovernoServidorModel governoServidorModel)
        {
            _governoService.Delete(id);

            return RedirectToAction(nameof(Index));


        }
    }
}
