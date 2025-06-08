using cv_tax.Data;
using Microsoft.EntityFrameworkCore;

namespace cv_tax.Repositories;

public class PictureGalleryRepository<T> : IPictureGalleryRepository<T> where T : class {
    
    private readonly PictureGalleryDbContext _context;
    private readonly DbSet<T> _dbSet;

    public PictureGalleryRepository(PictureGalleryDbContext context) {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public async Task<T?> FindByIdAsync(int id) {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<T>> FindAllAsync() {
        return await _dbSet.ToListAsync();
    }

    public void Add(T item) {
        _dbSet.Add(item);
    }

    public async Task SaveChangesAsync() {
        await _context.SaveChangesAsync();
    }
    
}