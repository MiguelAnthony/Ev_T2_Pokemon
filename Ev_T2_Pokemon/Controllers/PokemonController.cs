using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ev_T2_Pokemon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Ev_T2_Pokemon.Controllers
{
    
        [Authorize]
        public class PokemonController : BaseController
        {
            private Ev_T2_Pokemon_Context _context;
            public IHostEnvironment _hostEnv;

            public PokemonController(Ev_T2_Pokemon_Context context, IHostEnvironment hostEnv) : base(context)
            {
                _context = context;
                _hostEnv = hostEnv;
            }

            [HttpGet]
            public ActionResult Index()
            {
                var Pokemon = new Reg_Pokemon();
                var Pokemons = _context.Reg_Pokemon
                    .ToList();
                return View(Pokemons);
            }


            [HttpGet]
            public ActionResult Create() // GET
            {
                return View("Create", new Reg_Pokemon());
            }

            [HttpPost]
            public ActionResult Create(Reg_Pokemon pokemon, IFormFile RutaImgPo) // POST
            {
                var pokemonv = _context.Reg_Pokemon.FirstOrDefault(o => o.Nombre == pokemon.Nombre);
                if (pokemonv != null)
                    ModelState.AddModelError("Name2", "Ya existe ese pokemon");
                if (ModelState.IsValid)
                {
                    pokemon.Imagen = SaveImage(RutaImgPo);

                    _context.Reg_Pokemon.Add(pokemon);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View("Create", pokemon);
            }



            [HttpGet]
            public ActionResult Edit(int PokemonId)
            {
                var pokemon = _context.Reg_Pokemon.Where(o => o.Id == PokemonId).FirstOrDefault(); // si no lo encutra retorna un null

                return View(pokemon);
            }

            [HttpPost]
            public ActionResult Edit(Reg_Pokemon pokemon)
            {
                var pokemonv = _context.Reg_Pokemon.FirstOrDefault(o => o.Nombre == pokemon.Nombre);
                if (pokemonv != null)
                    ModelState.AddModelError("Name2", "Ya existe ese pokemon");
                if (ModelState.IsValid)
                {
                    _context.Reg_Pokemon.Update(pokemon);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                    return View(pokemon);
            }

            [HttpGet]
            public ActionResult Delete(int PokemonId)
            {
                var pokemon = _context.Reg_Pokemon.Where(o => o.Id == PokemonId).FirstOrDefault();
                _context.Reg_Pokemon.Remove(pokemon);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            [HttpGet]
            public ActionResult Capturar(int PokemonId) // GET
            {
                var pokeser = new Us_Pokemon { IdPokemon = PokemonId, IdUser = LoggedUser().Id, Fecha = DateTime.Now };
                _context.Us_Pokemon.Add(pokeser);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            [HttpGet]
            public ActionResult Capturados() // GET
            {
                var pokeser = _context.Us_Pokemon.Where(o => o.IdUser == LoggedUser().Id);
                
                return View(pokeser);
            }
            [HttpGet]
            public ActionResult liberar(int PokemonId) // GET
            {
                var pokeser = _context.Us_Pokemon.Where(o => o.IdPokemon == PokemonId && o.IdUser == LoggedUser().Id).FirstOrDefault();
                _context.Us_Pokemon.Remove(pokeser);
                _context.SaveChanges();
                return RedirectToAction("Capturados");
            }

            private string SaveImage(IFormFile image)
            {
                if (image != null && image.Length > 0)
                {
                    var basePath = _hostEnv.ContentRootPath + @"\wwwroot";
                    var ruta = @"\files\" + image.FileName;

                    using (var strem = new FileStream(basePath + ruta, FileMode.Create))
                    {
                        image.CopyTo(strem);
                        return ruta;
                    }
                }
                return null;
            }
        }
}
