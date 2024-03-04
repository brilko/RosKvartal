using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryContracts;
using RepositoryContracts.Entities;
using RepositoryContracts.Intefaces;
using ServicesContracts.DTOs;
using ServicesContracts.Interfaces;
using WebApi.Models;
using WebApiModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationsController : ControllerBase
    {
        private readonly IExaminationPageReader examinationPageReader;
        private readonly IMapper mapper;

        public ExaminationsController(IExaminationPageReader examinationPageReader, IMapper mapper)
        {
            this.examinationPageReader = examinationPageReader;
            this.mapper = mapper;
        }

        [HttpGet("page/{pageSize}/{pageNumber}")]
        public async Task<IActionResult> GetExaminationsList(int pageSize, int pageNumber) 
        {
            var page = new SearchPageDto(pageNumber, pageSize);
            var examinationDtos = await examinationPageReader.ReadExaminationPage(page);
            var examinationModels = mapper.Map<List<ExaminationGetPageModel>>(examinationDtos);
            return Ok(examinationModels);
        }
    }
}
