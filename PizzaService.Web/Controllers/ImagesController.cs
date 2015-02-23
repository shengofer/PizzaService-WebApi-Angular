using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace PizzaService.Web.Controllers
{
    public class ImagesController : BaseApiController
    {
        // GET: Images
        public HttpResponseMessage Get(int id)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            String pizzaPath = TheRepository.GetPizzaImagePathByPizzaId(id);
          //  String filePath = HostingEnvironment.MapPath("~/Images/Margarita.png");
            String filePath = HostingEnvironment.MapPath("~/Images/" + pizzaPath+".png");
            FileStream fileStream = new FileStream(filePath, FileMode.Open);            
            Image image = Image.FromStream(fileStream);
            fileStream.Close();
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
           // result.Content = new Base64FormattingOptions
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            memoryStream.Close();
            
            return result;
        }

       /* public HttpResponseMessage Get(int id)
        {
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            String filePath = HostingEnvironment.MapPath("~/Images/Margarita.png");
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
            Image image = Image.FromStream(fileStream);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            result.Content = new ByteArrayContent(memoryStream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

            return result;
        }*/
    }
}