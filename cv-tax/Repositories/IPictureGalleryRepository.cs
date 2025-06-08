namespace cv_tax.Repositories;

public interface IPictureGalleryRepository<T> {

    Task<T?> FindByIdAsync(int id);
    Task<List<T>> FindAllAsync();
    void Add(T item);
    Task SaveChangesAsync();
}