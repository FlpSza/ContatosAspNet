using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_MVC.Context;
using Projeto_MVC.Models;

namespace Projeto_MVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _context;

        public ContatoController(AgendaContext context){
            _context = context;
        }

        public ActionResult Index(){
            var contatos = _context.Contatos.ToList();
            return View(contatos);
        }
        public ActionResult Criar(){
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Contato contato){
            if(ModelState.IsValid){
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public ActionResult Editar(int Id){
            var contato = _context.Contatos.Find(Id);

            if(contato ==null){
                return NotFound();
            }

            return View(contato);
        }   

        [HttpPost]
        public ActionResult Editar(Contato contato){
            if(ModelState.IsValid){
                _context.Contatos.Add(contato);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(contato);
        }
    }
}