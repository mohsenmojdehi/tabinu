using AddBuzz.CustomeAuthorizeAttribute;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace AddBuzz.Controllers
{
    public class GalleryController : Controller
    {
       
        private readonly string ImagesFolderAddress = "/Files/Images/";

        [AuthorizeFilter()]
        [HttpPost]
        public IActionResult UploadImage(IFormFile pic)
        {
            
            string uniqueFileName = null;

            if (pic != null && ( pic.ContentType.ToLower() == "image/jpeg" || pic.ContentType.ToLower()== "image/png" || pic.ContentType.ToLower()== "image/jpg" || pic.ContentType.ToLower()== "image/svg"))
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + pic.FileName;
                //string filePath =( ImagesFolderAddress+ uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\Images", uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pic.CopyTo(fileStream);
                }
                return Ok(new { Url = ImagesFolderAddress+uniqueFileName });
            }
            return BadRequest();
        }

        
    }
}