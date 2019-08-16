using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteBack.Model.Criteria;
using TesteBack.Model.Model;
using TesteBack.Repository.Repository;

namespace TesteBack.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        #region property
        private readonly ILivroRepository _repo; 
        #endregion

        #region constructor
        public LivroController(ILivroRepository repo)
        {
            _repo = repo;
        }

        #endregion
    
        #region endPoints
        [HttpGet("getall")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllAsync();

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, filename.Replace("\"", " ").Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            try
            {
                var result = await _repo.GetById(id);


                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpGet("getByCriteria")]
        public async Task<IActionResult> Get(String autor = null, String titulo = null)
        {
            try
            {
                var results = await _repo.GetByCriteria(new LivroCriteria() { Autor = autor, Titulo = titulo });

                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post(Livro model)
        {
            try
            {

                await _repo.Create(model);
                if (model.Id > 0)
                {
                    return Ok(model);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Banco Dados Falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int? id, Livro model)
        {
            try
            {
                var updtedted = await _repo.GetById(id);

                if (updtedted == null) return NotFound();

                await _repo.Update(id, model);

                return Ok(model);

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou " + ex.Message);
            }
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var deleted = await _repo.GetById(id);
                if (deleted == null) return NotFound();

                await _repo.Delete(id);

                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }

        }

        #endregion
    }
}