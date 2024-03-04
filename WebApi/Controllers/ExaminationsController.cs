using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryContracts;
using RepositoryContracts.Entities;
using RepositoryContracts.Intefaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationsController : ControllerBase
    {
        private readonly IExaminationRepository examinationRepository;

        public ExaminationsController(IExaminationRepository examinationRepository)
        {
            this.examinationRepository = examinationRepository;
        }

        [HttpGet("page/{pageSize}/{pageNumber}")]
        public async Task<IActionResult> GetExaminationsList(int pageSize, int pageNumber) 
        {
            var page = new SearchPage(pageNumber, pageSize);
            var examinations = await examinationRepository.ReadPageAsync(page);
            return Ok(examinations);
        }
    }
}
