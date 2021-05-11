using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GSCS_Cameras_API.Data;

namespace GSCS_Cameras_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamerasController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        

        public CamerasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cameras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camera>>> GetCameras()
        {
            return await _context.Cameras
                .Include(c => c.Model)
                .Include(c => c.School)
                .ToListAsync();
        }

        // GET: api/Cameras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Camera>> GetCamera(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camera = await _context.Cameras
                .Include(c => c.Model)
                .Include(c => c.School)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camera == null)
            {
                return NotFound();
            }

            return camera;
        }

       [HttpPost]
        public async Task<ActionResult<Camera>> PostCamera([FromBody] Camera camera)
        {
            var SchoolID = camera.School.ID;
            if (_context.Schools.Any(s => s.ID == SchoolID)) 
            {
                var existingSchool = await _context.Schools.FirstOrDefaultAsync(s => s.ID == SchoolID);
                camera.School = existingSchool;
            }

            var ModelID = camera.Model.Id;
            if (_context.Models.Any(m => m.Id == ModelID))
            {
                var existingModel = await _context.Models.FirstOrDefaultAsync(m => m.Id == ModelID);
                camera.Model = existingModel;
            }
            if (camera.Username == null) {
                camera.Username = camera.Model.DefaultUsername;
            }
            if (camera.Password == null) {
                camera.Password = camera.Model.DefaultPassword;
            }
            _context.Cameras.Add(camera);
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetCamera", new { id = camera.ID }, camera);
        }

        private bool CameraExists(int id)
        {
            return _context.Cameras.Any(e => e.ID == id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCamera(int id, Camera camera)
        {
            if (id != camera.ID)
            {
                return BadRequest();
            }

            _context.Entry(camera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CameraExists(id))
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

        // DELETE: api/Cameras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCamera(int id)
        {
            var camera = await _context.Cameras.FindAsync(id);
            if (camera == null)
            {
                return NotFound();
            }

            _context.Cameras.Remove(camera);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
