using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Entities
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new System.ArgumentException(nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet("fieldId")]
        public IActionResult GetFiles(string fileId)
        {
            var pathToFile = "doc.txt";

            if (!System.IO.File.Exists(pathToFile))
            {
                NotFound();
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octect-stream";
                ///"text/plain"
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            //
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
