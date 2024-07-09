using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class //dışardan nesne, metot veya değişken gibi bir durum girmiş olmicak. Diğerleri bunu kullanıcak mesela ekleme metodu gibi, bunu çağırıcaz. Yani bu yazılan interfacelerin içi  IGenericDal dan miras almalı. bunları kullanacakları için. Yani her entity nin bir Interface olması gerektği için 

        //Yani şöyle. her tabloya ait ekleme silme güncelleme ıd ye göre getirme ve listeleme olduğu için her tablo bu şekilde IGenericDal dan miras almalı. 
    {
        void Add(T entity); //Ekleme
        void Delete (T entity); //Silme 
        void Update(T entity); //Güncelleme
        T GetByID (int id); //Id ye göre Listeleme
        List<T> GetListAll(); //Tüm hepsini listeleme
    }
}
