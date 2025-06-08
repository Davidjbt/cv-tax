using System.Threading.Tasks;
using cv_tax.Data;
using cv_tax.Models;
using cv_tax.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cv_tax.Controllers {
    public class PhotoGalleryController : Controller {
        
        private readonly IPictureGalleryRepository<PictureModel> _pictureGalleryRepository;

        public PhotoGalleryController(IPictureGalleryRepository<PictureModel> pictureGalleryRepository) {
            _pictureGalleryRepository = pictureGalleryRepository;
        }

        public async Task<IActionResult> Index() {
            var pictures = await _pictureGalleryRepository.FindAllAsync();

            return View(pictures);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile photo) {
            if (photo == null) return View();

            var galleryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "gallery");
            
            if (!Directory.Exists(galleryPath)) {
                Directory.CreateDirectory(galleryPath);
            }

            var filePath = Path.Combine(galleryPath, photo.FileName);
            using (var stream = System.IO.File.Create(filePath)) {
                await photo.CopyToAsync(stream);
            }

            var picture = new PictureModel(filePath: photo.FileName);
            
            _pictureGalleryRepository.Add(picture);
            await _pictureGalleryRepository.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets all pictures
        /// </summary>
        /// <returns>A list of pictures data</returns>
        /// <response code="200">Returns the data of all pictures</response>
        [HttpGet]
        [Route("api/v1/pictures")]
        [ProducesResponseType(typeof(List<PictureModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPictures() {
            var pictures = await _pictureGalleryRepository.FindAllAsync();
            
            return Ok(pictures);
        }

        /// <summary>
        /// Gets a picture by ID
        /// </summary>
        /// <param name="id">The picture ID</param>
        /// <returns>The picture data</returns>
        /// <response code="200">Returns the picture data</response>
        /// <response code="404">If the picture id is not found</response>
        [HttpGet]
        [Route("api/v1/pictures/{id}")]
        [ProducesResponseType(typeof(PictureModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPicture(int id) {
            var picture = await _pictureGalleryRepository.FindByIdAsync(id);

            if (picture == null) return NotFound($"Picture with ID: {id} not found");

            return Ok(picture);
        }

    }
}
