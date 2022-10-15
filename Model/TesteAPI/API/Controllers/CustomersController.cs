using API.Entities;
using API.Repositories;
using API.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
//using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        //  private readonly IHostingEnvironment _hosting;
        public CustomersController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            //_hosting = hosting;
        }
        // GET: api/<CustomersController>
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    GetUserQuery command = new();
        //    var result = await _mediator.Send(command);
        //    return result.Any() ? Ok(result) : NotFound();
        //}

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GetUserByIdQuery command = new(id);
            var result = await _mediator.Send(command);
            return result is null ? NotFound() : Ok(result);
        }



        // POST api/<CustomersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            CreateUserCommand createUserCommand = new(user);
            var result = await _mediator.Send(createUserCommand);

            return result is null ? NotFound() : Ok(result);
        }

        // PUT api/<CustomersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<CustomersController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}


        [HttpPost("FileUpload")]
        public async Task<IActionResult> Index(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                    filePaths.Add(filePath);
                    using var stream = new FileStream(filePath, FileMode.Create);
                    await formFile.CopyToAsync(stream);
                }
            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok(new { count = files.Count, size, filePaths });
        }

        //[HttpPost("upload"), DisableRequestSizeLimit]
        //public async Task<IActionResult> Upload(ContentDispositionHeaderValue contentDispositionHeaderValue)
        //{
        //    try
        //    {
        //        var formCollection = await Request.ReadFormAsync();
        //        var file = formCollection.Files[0];
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        if (file.Length > 0)
        //        {
        //            string? fileName = contentDispositionHeaderValue.Parse(file.ContentDisposition).FileName
        //                                                            .Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}

        //[HttpGet("AllTypeFile")]
        //public async Task<IActionResult> Download(Guid id)
        //{
        //    var fileDetail = await _userRepository.FileDetail(id);

        //    if (fileDetail is not null)
        //    {
        //        System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
        //        {
        //            FileName = fileDetail.DocumentName,
        //            Inline = false
        //        };
        //        Response.Headers.Add("Content-Disposition", cd.ToString());

        //        //get physical path
        //        var path = _hosting.ContentRootPath;
        //        var fileReadPath = Path.Combine(path, "Files", fileDetail.Id.ToString() + fileDetail.DocType);

        //        var file = System.IO.File.OpenRead(fileReadPath);

        //        return File(file, "application/force-download", Path.Combine(cd.FileName));

        //        // return File(file, fileDetail.DocType);
        //    }
        //    else
        //    {
        //        return StatusCode(404);
        //    }
        //}

        //[HttpPost("AllTypeFile")]
        //public IActionResult UploadFile(IList<IFormFile> files)
        //{
        //    //either you can pass the list of files in the method or you can initialize them inside the method like the commented line below
        //    //var files = HttpContext.Request.Form.Files;
        //    FileDetail fileDetail = new FileDetail();
        //    foreach (var file in files)
        //    {
        //        var fileType = Path.GetExtension(file.FileName);
        //        //var ext = file.;
        //        if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
        //        {
        //            var filePath = _hosting.ContentRootPath;
        //            var docName = Path.GetFileName(file.FileName);
        //            if (file != null && file.Length > 0)
        //            {
        //                fileDetail.Id = Guid.NewGuid();
        //                fileDetail.DocumentName = docName;
        //                fileDetail.DocType = fileType;
        //                fileDetail.DocUrl = Path.Combine(filePath, "Files", fileDetail.Id.ToString() + fileDetail.DocType);
        //                using (var stream = new FileStream(fileDetail.DocUrl, FileMode.Create))
        //                {
        //                    file.CopyToAsync(stream);
        //                }

        //                _userRepository.Add(fileDetail);
        //                // _context.SaveChangesAsync();
        //            }
        //            else
        //            {
        //                return BadRequest();
        //            }
        //        }
        //    }
        //    return Ok(fileDetail.Id);
        //}

        /*
         * CRUD: https://medium.com/@sagargupta.gupta977/implementation-of-cqrs-in-net-6-f7fbcd05ea1c
         
         What's CQRS?-> is an architectural design pattern  commands, queries
          
         Write -> information(command)
         Read -> information(Query)

         Entity: Model -> class
                 DTO's View model --> record, struct
        MediatR :
         ServiceExtensions
            AddAutoMapper --assembly
            AddMediatR --assembly
            AddScoped --repository

         */
    }
}
