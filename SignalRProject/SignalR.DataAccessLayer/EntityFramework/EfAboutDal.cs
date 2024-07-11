using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(SignalRContext context) : base(context)
        {
            //context sınıfında bir conctractur oluşturmuşsun genericrepository de diyor, genericrepository sınıfından miras aldığın için burda da yapıcı metot oluşturman lazım diyor.  bu diğer bütün sınıflar için yaoılır.


            //DataAccess tarafına entity ile iletişim kurması için. GenericRepository içinde veritabanı için dependency tanımlanmış sonuçta. 
        }
    }
}
