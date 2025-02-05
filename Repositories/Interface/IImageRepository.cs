using YongdingSun.API.Modles.Domain;

namespace YongdingSun.API.Repositories.Interface
{
    public interface IImageRepository
    {
        Task<Image> Upload(IFormFile file, Image blogImage);

        Task<IEnumerable<Image>> GetAll();
    }
}
