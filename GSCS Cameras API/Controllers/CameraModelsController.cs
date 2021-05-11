using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GSCS_Cameras_API.Data;

namespace GSCS_Cameras_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CameraModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CameraModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CameraModel>>> GetModels()
        {
            return await _context.Models.ToListAsync();
        }

        // GET: api/CameraModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CameraModel>> GetCameraModel(int id)
        {
            var cameraModel = await _context.Models.FindAsync(id);

            if (cameraModel == null)
            {
                return NotFound();
            }

            return cameraModel;
        }

        // PUT: api/CameraModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCameraModel(int id, CameraModel cameraModel)
        {
            if (id != cameraModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(cameraModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CameraModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CameraModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CameraModel>> PostCameraModel(CameraModel cameraModel)
        {
            _context.Models.Add(cameraModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCameraModel", new { id = cameraModel.Id }, cameraModel);
        }

        // DELETE: api/CameraModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCameraModel(int id)
        {
            var cameraModel = await _context.Models.FindAsync(id);
            if (cameraModel == null)
            {
                return NotFound();
            }

            _context.Models.Remove(cameraModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CameraModelExists(int id)
        {
            return _context.Models.Any(e => e.Id == id);
        }
    }
}
