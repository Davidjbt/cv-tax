using System.Threading.Tasks;
using cv_tax.Data;
using cv_tax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cv_tax.Controllers {
    public class PhotoGalleryController : Controller {

        private readonly PictureGalleryDbContext _pictureGalleryDbContext;

        public PhotoGalleryController(PictureGalleryDbContext pictureGalleryDbContext) {
            _pictureGalleryDbContext = pictureGalleryDbContext;
        }

        public async Task<IActionResult> Index() {
            var pictures = await _pictureGalleryDbContext.Pictures.ToListAsync();

            return View(pictures);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile photo) {
            if (photo == null) return View();

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "gallery", photo.FileName);
            using (var stream = System.IO.File.Create(filePath)) {
                await photo.CopyToAsync(stream);
            }

            var picture = new PictureModel(filePath: photo.FileName);
            _pictureGalleryDbContext.Add(picture);

            await _pictureGalleryDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
