using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.Models
{
    interface IPhotosRepository
    {
        IEnumerable<Photo> GetAllPhotos();
        void AddPhoto(Photo photo);
        int GetTotalNumberOfPhotos();
        PagedList<Photo> GetPageOfPhotos(int pageNum, int pageSize);
        void RemoveAllPhotos();
    }
}
