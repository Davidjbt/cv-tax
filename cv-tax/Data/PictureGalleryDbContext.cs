using cv_tax.Models;
using Microsoft.EntityFrameworkCore;

namespace cv_tax.Data {
    public class PictureGalleryDbContext : DbContext {

        public PictureGalleryDbContext(DbContextOptions<PictureGalleryDbContext> opts) : base(opts) { }

        public DbSet<PictureModel> Pictures { get; set; }

    }
}
