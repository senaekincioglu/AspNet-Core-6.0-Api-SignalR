using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;//service olur çünkü bunun içinde DAL da var. 

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        [HttpGet] //Listeleme
        public IActionResult AboutList()
        {
            var result = _aboutService.TGetListAll();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto) //Ekleme bunun için POST isteği ile gelen verileri bu parametre üzerinden alıp işlem yapmaktır.CreateAboutDto ise genellikle gelen verilerin modelini temsil eden bir sınıftır ve bu sınıf üzerinden gelen veriler model bağlama ile alınır ve işlenir.
        {
            About about = new About()//Burda map leme yapılmıyor aslında ama mapleme gibi. burdakinin amacı ise şöyle:

            // AboutManager da Add kısmı entity alınıyor, dto alamaz. entity aldığı için burda da dto alıyor. dto yu alıp entity e atıyoruz. 
            //YANİ GELEN DTO YU ENTİTY E ÇEVİRME İŞLEMİ YAPILIYOR. 
            {
                //ımage title desc
                ImageUrl=createAboutDto.ImageUrl,
                Title=createAboutDto.Title,
                Description=createAboutDto.Description
            };
           
            _aboutService.TAdd(about);
            return Ok("Hakkımda kısmı başarılı bir şekilde eklendi");
        }
        [HttpDelete] //Silme
        public IActionResult DeleteAbout(int id) //Id ye göre siler. 
        {
            //İlk önce sildirmek için değeri bulmalıyız. 
            var value=_aboutService.TGetByID(id); //Id burdan buluyor.
            _aboutService.TDelete(value); //bulduğu ıd yi siliyor.
            return Ok ("Hakkımda alanı silindi");
        }

        [HttpPut] //Güncelleme işlemi
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
           About about = new About()
            {
                Id= updateAboutDto.Id,
                ImageUrl=updateAboutDto.ImageUrl,
                Title=updateAboutDto.Title,
                Description=updateAboutDto.Description
                
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımda alanı güncellendi");
        }
        [HttpGet("GetAbout")]//Id ye göre getirme işlemi olacak
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }



    }
}
