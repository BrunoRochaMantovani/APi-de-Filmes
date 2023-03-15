﻿using Filmes_API.Data;
using Filmes_API.Extensions;
using Filmes_API.Models;
using Filmes_API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Runtime;

namespace Filmes_API.Controllers
{
    [ApiController]
    [Route("/v1/filme")]
    public class FilmeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try 
            {
                var filmes = await _context.Filmes
                .AsNoTracking()
                .Include(x => x.Genero)
                .Include(x => x.Diretor)
                .ToListAsync();
                List<FilmeGetViewModel> Lista = new List<FilmeGetViewModel>();

                foreach (var filme in filmes) 
                {
                    Lista.Add(new FilmeGetViewModel
                    {
                        Id = filme.Id,
                        Titulo= filme.Titulo,
                        AnoLancamento = filme.AnoLancamento,
                        EstrelasAvaliacao = filme.EstrelasAvaliacao,
                        Plot = filme.Plot,
                        DuracaoFilme= filme.DuracaoFilme,
                        Diretor = filme.Diretor.PrimeiroNome,
                        TItuloCategoria = filme.Genero.NomeGenero
                    });
                }


                return Ok(Lista);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            
        }

        [HttpGet(template:"{id}")]
        public async Task<IActionResult> ListarUm(int id)
        {
            try 
            {
                var escolhido = await _context.Filmes
                        .AsNoTracking()
                        .Include(x=>x.Diretor)
                        .Include(x=>x.Genero)
                        .FirstOrDefaultAsync();

                if(escolhido == null)
                    return NotFound("Usuário não encontrado");

                var retorno = new FilmeGetViewModel
                {
                    Id = escolhido.Id,
                    Titulo = escolhido.Titulo,
                    AnoLancamento = escolhido.AnoLancamento,
                    EstrelasAvaliacao = escolhido.EstrelasAvaliacao,
                    Plot = escolhido.Plot,
                    DuracaoFilme = escolhido.DuracaoFilme,
                    Diretor = escolhido.Diretor.PrimeiroNome,
                    TItuloCategoria = escolhido.Genero.NomeGenero
                };

                return Ok(retorno);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] FilmePostOrPutViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Modelo informado incorreto");

                var filme = new Filme
                {
                    Titulo = model.Titulo,
                    AnoLancamento = DateTime.Now,
                    EstrelasAvaliacao = model.EstrelasAvaliacao,
                    Plot = model.Plot,
                    DuracaoFilme = model.DuracaoFilme,
                    DiretorId = model.DiretorId,
                    GeneroId = model.CategoriaID
                };

                await _context.Filmes.AddAsync(filme);
                await _context.SaveChangesAsync();

                return Ok(filme);

                 
            }catch(Exception ex) { return BadRequest(ex.Message); }
        }


        }
}