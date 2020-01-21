using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task2.DAL;

namespace task2.Models
{
    class EFPhotosRepository : IPhotosRepository
    {
        PhotosContext context;

        public EFPhotosRepository()
        {
            this.context = new PhotosContext();
        }
        public void AddPhoto(Photo photo)
        {
            context.Photos.Add(photo);
            context.SaveChanges();
        }

        public IEnumerable<Photo> GetAllPhotos() => context.Photos.ToList();

        public PagedList<Photo> GetPageOfPhotos(int pageNum, int pageSize)
        {
            var totalNum = this.GetTotalNumberOfPhotos();
            if (pageNum < 0 || pageNum > totalNum / pageSize + 1)
            {
                throw new ArgumentException(nameof(pageNum));
            }
            var page = new PagedList<Photo>() { CurrentPage = pageNum, PageSize = pageSize };
            page.TotalRecords = totalNum;
            page.Content = this.context.Photos.OrderByDescending(p => p.Id).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return page;
        }

        public int GetTotalNumberOfPhotos() => context.Photos.Count();
    }
}
