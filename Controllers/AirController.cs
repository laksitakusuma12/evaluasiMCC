using Household.Context;
using Household.Models.ViewModels;
using Household.Models;
using Household.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Household.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirController : ControllerBase
    {
        private readonly AirRepository repository;
        public AirController(AirRepository airRepository)
        {
            this.repository = airRepository;
        }
        // READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = repository.Get();
            if (data.Count == 0)
                return Ok(new { message = "gagal mengambil data Pembyaran Air", StatusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data Pembyaran Air", StatusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = repository.Get(id);
            if (data == null)
                return Ok(new { message = "gagal mengambil data Pembyaran Air", StatusCode = 200, data = "null" });
            return Ok(new { message = "berhasil mengambil data Pembyaran Air", StatusCode = 200, data = data });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AirViewModel airViewModel)
        {
            var result = repository.Put(id, airViewModel);

            if (result > 0)
            {
                return Ok(new { message = "Sukses mengganti data Pembyaran Air!", StatusCode = 200 });
            }
            else if (airViewModel.Biaya < 200000)
            {
                return BadRequest(new { message = "Gagal mengganti data Pembyaran Air karena tidak memenuhi standar biaya Air", StatusCode = 400 });
            }
            else
            {
                return BadRequest(new { message = "Gagal mengganti data Pembyaran Air!", StatusCode = 400 });
            }
        }

        [HttpPost]
        public IActionResult Post(AirViewModel airViewModel)
        {
            var result = repository.Post(airViewModel);

            if (result > 0)
            {
                return Ok(new { message = "Sukses menambah data Pembyaran Air!", StatusCode = 200 });
            }
            else if (airViewModel.Biaya < 200000)
            {
                return BadRequest(new { message = "Gagal menambah data Pembyaran Air karena tidak memenuhi standar biaya Air", StatusCode = 400 });
            }
            else
            {
                return BadRequest(new { message = "Gagal mengganti data Pembyaran Air!", StatusCode = 400 });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = repository.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "Sukses menghapus data Pembyaran Air!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menghapus data Pembyaran Air!", StatusCode = 400 });
        }
    }
}
