using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MediaController : ControllerBase
    {
        private readonly IMediaService _service;
        public MediaController(IMediaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedia([FromBody] MediaCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createResult = await _service.CreateMediaAsync(model);
            if (createResult)
            {
                return Ok("Media was created");
            }

            return BadRequest("Media could not be created.");
        }

        [HttpPut]
        public async Task<IActionResult> MediaUpdate([FromBody] MediaUpdate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return await _service.UpdateMediaAsync(model)
            ? Ok("Media updated succesfully.")
            : BadRequest("Media could not be updated.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMediaAsync()
        {
        var medias = await _service.GetAllMediaAsync();
        return Ok(medias);
        }

        //No Active Delete Method - Each product in the databse has a media attached, so we are opting to not pursue a Delete option as it will affect products already present

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteMediaType([FromRoute] int id)
        // {
        //     return await _service.DeleteMediaAsync(id)
        //         ? Ok($"Media Type was deleted successfully")
        //         : BadRequest($"Media Type could not be deleted");
        // }
    }
