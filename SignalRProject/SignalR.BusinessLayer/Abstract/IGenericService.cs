using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        //Başına T gelme sebebi IGenericDal ile karışmaması için. Başında T olan metotlar business katmanındaki metotlar olacak, başında T olmayan metotlar ise DataAccess katmanındaki metotlar olacak. 

        void TAdd(T entity); //Ekleme
        void TDelete(T entity); //Silme 
        void TUpdate(T entity); //Güncelleme
        T TGetByID(int id); //Id ye göre Listeleme
        List<T> TGetListAll(); //Tüm hepsini listeleme
    }
}
