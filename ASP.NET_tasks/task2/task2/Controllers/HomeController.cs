using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task2.Models;

namespace task2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPhotosRepository repository;
        private const int PageSize = 6;

        public HomeController()
        {
            repository = new EFPhotosRepository();
        }

        public ActionResult Index(int pageNum = 1)
        {
            PagedList<Photo> page = repository.GetPageOfPhotos(pageNum, PageSize);
            return View(page);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var photo = new Photo();
            return View(photo);
        }

        [HttpPost]
        public ActionResult Create(Photo photo, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
                return View(photo);
            if (files.Count() == 0 || files.FirstOrDefault() == null)
            {
                ViewBag.error = "Please choose a file";
                return View(photo);
            }

            var model = new Photo();
            foreach (var file in files)
            {
                if (file.ContentLength == 0) continue;

                model.Description = photo.Description;

                int smallImageSize = 70;

                using (var img = Image.FromStream(file.InputStream))
                {
                    model.LargeImage = this.SaveImageToByteArray(
                        img,
                        new Size(smallImageSize * PageSize, smallImageSize * PageSize));
                    model.SmallImage = this.SaveImageToByteArray(img, new Size(smallImageSize, smallImageSize));
                }

                this.repository.AddPhoto(model);
            }

            return RedirectPermanent("/home");
        }

        public PartialViewResult PhotosPage(int pageNum)
        {
            PagedList<Photo> page = repository.GetPageOfPhotos(pageNum, PageSize);
            return PartialView(page);
        }

        private Size NewImageSize(Size imageSize, Size newSize)
        {
            double tempval = imageSize.Height > imageSize.Width ?
                newSize.Height / (imageSize.Height * 1.0) : newSize.Width / (imageSize.Width * 1.0);

            Size finalSize = new Size((int)(tempval * imageSize.Width), (int)(tempval * imageSize.Height));

            return finalSize;
        }

        private byte[] SaveImageToByteArray(Image img, Size newSize)
        {
            // Get new resolution
            Size imgSize = NewImageSize(img.Size, newSize);
            byte[] byteImage;
            using (Image newImg = new Bitmap(img, imgSize.Width, imgSize.Height))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    newImg.Save(memoryStream, ImageFormat.Png);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    byteImage = new byte[memoryStream.Length];
                    memoryStream.Read(byteImage, 0, byteImage.Length);
                }
            }
            return byteImage;
        }
    }
}