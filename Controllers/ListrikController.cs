using Household.Context;
using Household.Models;
using Household.Models.ViewModels;
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
    public class ListrikController : ControllerBase
    {
        private readonly ListrikRepository repository;
        public ListrikController(ListrikRepository listrikRepository)
        {
            this.repository = listrikRepository;
        }
        // READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = repository.Get();
            if (data.Count == 0)
                return Ok(new { message = "gagal mengambil data Pembyaran Listrik", StatusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data Pembyaran Listrik", StatusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = repository.Get(id);
            if (data == null)
                return Ok(new { message = "gagal mengambil data Pembyaran Listrik", StatusCode = 200, data = "null" });
            return Ok(new { message = "berhasil mengambil data Pembyaran Listrik", StatusCode = 200, data = data });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ListrikViewModel listrikViewModel)
        {
            var result = repository.Put(id, listrikViewModel);

            if (result > 0)
            {
                return Ok(new { message = "Sukses mengganti data Pembyaran Listrik!", StatusCode = 200 });
            }
            else if (listrikViewModel.Biaya < 200000)
            {
                return BadRequest(new { message = "Gagal mengganti data Pembyaran Listrik karena tidak memenuhi standar biaya Listrik", StatusCode = 400 });
            }
            else
            {
                return BadRequest(new { message = "Gagal mengganti data Pembyaran Listrik!", StatusCode = 400 });
            }
        }

        [HttpPost]
        public IActionResult Post(ListrikViewModel listrikViewModel)
        {
            var result = repository.Post(listrikViewModel);

            if (result > 0)
            {
                return Ok(new { message = "Sukses menambahkan data Pembyaran Listrik!", StatusCode = 200 });
            } else if (listrikViewModel.Biaya < 200000){
                return BadRequest(new { message = "Gagal menambahkan data Pembyaran Listrik karena tidak memenuhi standar biaya Listrik", StatusCode = 400 });
            } else
            {
                return BadRequest(new { message = "Gagal menambahkan data Pembyaran Listrik!", StatusCode = 400 });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = repository.Delete(id);
            if (result > 0)
            {
                return Ok(new { message = "Sukses menghapus data Pembyaran Listrik!", StatusCode = 200 });
            }

            return BadRequest(new { message = "Gagal menghapus data Pembyaran Listrik!", StatusCode = 400 });
        }
    }
}
