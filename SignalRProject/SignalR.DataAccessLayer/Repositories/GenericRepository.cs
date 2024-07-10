using Microsoft.EntityFrameworkCore.Internal;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly SignalRContext _context; // BU DEPENDENCY INJECTION DUR. farklı bir orm aracına geçildiğinde dependency injection kullanılırsa geçişi çok kolay olur. 
        //Dependency Injection, sınıfın ihtiyaç duyduğu bağımlılıkları (örneğin, veri tabanı bağlamı) dışarıdan almasını sağlayan bir desendir. Bu, sınıfın bağımlılıklarını kendisi oluşturmak yerine, dışarıdan sağlamasına olanak tanır.
        //Bağımlılık Enjeksiyonu: Bu teknik, bir sınıfın ihtiyaç duyduğu bağımlılıkları dışarıdan almasını sağlar. Örneğin, bir veritabanına bağlanmak için gereken bilgileri içeren SignalRContext nesnesi.
        //Yani IGenericDal daki crud işlemlerini kullanabilmem için ve bunların veritabanına işlenmesi için kullanılır. 
        //crud işlemlerindeki interfaceler üzerine sadece metotlar yazılmış oldu aşağıda. interface amacı ise sürekli kullanmamak için biryerde tanımlanıyor oradan miras alıyor.  yani bu metotların sql de ki ilişkisi için içeriğini yazınca birde o yüzden SignalRContext sınıfıdır veritabanı bağlantısı orda olduğu için. 
        public GenericRepository(SignalRContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T GetByID(int id)
        {
            //Id ye göre getirdiği için return ( döndürür ) olur
            return _context.Set<T>().Find(id); //find yani Id yi bulup getiriyor
        }

        public List<T> GetListAll()
        {
            return _context.Set<T>().ToList();//List çünkü bir listeyi getiriyor. 
        }

        public void Update(T entity)
        {
            _context.Update(entity);   
            _context.SaveChanges();
        }
    }
}
