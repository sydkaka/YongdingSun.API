using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YongdingSun.API.Modles.Domain;
using YongdingSun.API.Modles.DTO;
using YongdingSun.API.Repositories.Implementation;
using YongdingSun.API.Repositories.Interface;

namespace YongdingSun.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;
        private readonly IMapper mapper;

        public ImagesController(IImageRepository imageRepository, IMapper mapper)
        {
            this.imageRepository = imageRepository;
            this.mapper = mapper;
        }

        // GET: {apibaseURL}/api/Images
        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            // call image repository to get all images
            var images = await imageRepository.GetAll();

            // Convert Domain model to DTO
            var response = mapper.Map<List<ImageDto>>(images);
           
            return Ok(response);
        }

        // POST: {apibaseurl}/api/images
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file,
            [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);

            if (ModelState.IsValid)
            {
                // File upload
                var image = new Image
                {
                    FileExtension = Path.GetExtension(file.FileName).ToLower(),
                    FileName = fileName,
                    Title = title,
                    DateCreated = DateTime.Now,
                    Likes = 0

                };

                image = await imageRepository.Upload(file, image);

                // Convert Domain Model to DTO
                var response = mapper.Map<ImageDto>(image);

                return Ok(response);
            }

            return BadRequest(ModelState);
        }


        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName).ToLower()))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more than 10MB");
            }
        }
    }


}
