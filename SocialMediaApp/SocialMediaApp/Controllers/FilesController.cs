﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Interfaces;
using SocialMediaApp.Models;
using SocialMediaApp.Services;

namespace SocialMediaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFile _uploadService;

        public FilesController(IFile uploadService)
        {
            _uploadService = uploadService;
        }


        [HttpPost("PostSingleFile")]
        public async Task<IActionResult> PostSingleFile(IFormFile fileData)
        {
            if (fileData == null)
                return BadRequest("File data is null.");
            if (fileData.Length == 0) return BadRequest("File is empty.");

            try
            {
                FileDetails fileDetails = await _uploadService.PostFileAsync(fileData);
                return Ok(fileDetails);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while uploading the file.");
            }
        }


        [HttpGet("DownloadFileById")]
        public async Task<IActionResult> DownloadFileById(int Id)
        {
            await _uploadService.DownloadFileById(Id);
            return Ok("File downloaded successfully.");
        }

        [HttpGet("GetFileById/{id}")]

        public IActionResult GetFileById(int id)
        {
            var _file = _uploadService.GetFileById(id);
            return Ok(_file);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allFiles = _uploadService.GetAll();
            return Ok(allFiles);

        }
    }
}
