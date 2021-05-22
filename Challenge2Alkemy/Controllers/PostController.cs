﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Challenge2Alkemy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Challenge2Alkemy.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }
        //http get Index
        public IActionResult Index()
        {
            IEnumerable<PostViewModel> listaPosts = _context.Post;
            List<PostViewModel> listaOrdenada = new List<PostViewModel>();
            foreach (var item in listaPosts)
            {
                if (item.EstaBorrado==false)
                {
                    listaOrdenada.Add(item);
                }
            }
            listaOrdenada.OrderBy(x => x.FechaDeCreacion);

            return View(listaOrdenada);
        }
        //http get create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PostViewModel model)
        {
            //obtener los bytes de model.Imagen para guardar en la db
            if (ModelState.IsValid)
            {
                _context.Post.Add(model);
                _context.SaveChanges();
                TempData["mensaje"] = "Se creo el nuevo posteo exitosamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        //http get edit
        public IActionResult Edit(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            var post = _context.Post.Find(id);

            if (post==null)
            {
                return NotFound();
            }

            return View(post);
        }
        [HttpPost]
        public IActionResult Edit(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Post.Update(model);
                _context.SaveChanges();
                TempData["mensaje"] = "Se modifico el posteo exitosamente";
                return RedirectToAction("Index");
            }
            return View();
        }
        //http get delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var post = _context.Post.Find(id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var post = _context.Post.Find(id);
            if (post==null)
            {
                return NotFound();
            }
            
                post.EstaBorrado = true;
                _context.Post.Update(post);
                _context.SaveChanges();
                TempData["mensaje"] = "Se elimino el posteo exitosamente";
                return RedirectToAction("Index");
            
        }
        //http get detalles
        public IActionResult Details(int? id)
        {
            var post = _context.Post.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        //Post random en el home
        public IActionResult RandomPost()
        {
            IEnumerable<PostViewModel> listaPosts = _context.Post;
            var random = new Random();
            var numeroRandom = random.Next(0, listaPosts.Count());

            var post = _context.Post.Find(numeroRandom);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
    }
}
