using Microsoft.AspNetCore.Mvc;
using zeynep.Models;
using zeynep.Repositories;

namespace zeynep.Controllers
{
    public class AnketlerController : Controller
    {
        private readonly IAnketlerReporsitory _anketlerReporsitory;
        private object anketler;

        public AnketlerController(IAnketlerReporsitory context)
        {
            _anketlerReporsitory = context;
        }
        public IActionResult Index()
        {
            List<Anketler> objAnketlerList = _anketlerReporsitory.GetAll().ToList();

            return View(objAnketlerList);
        }

        public IActionResult Add() 
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Add(Anketler anketler)
        {
            if (ModelState.IsValid)
            {
                _anketlerReporsitory.Ekle(anketler);
                _anketlerReporsitory.Kaydet();
                TempData["Basarili"] = "Yeni Anket  Başarıyla Oluşturuldu!";
                return RedirectToAction("Index");
            }
            return View();  
          
        }

        public IActionResult Update(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Anketler? anketlerDb = _anketlerReporsitory.Get(u=>u.Id==id);
            if (anketlerDb == null) 
            {
                return NotFound();
            }
            return View(anketlerDb);
        }

        [HttpPost]
        public IActionResult Update(Anketler anketler)
        {
            if (ModelState.IsValid)
            {
                _anketlerReporsitory.Guncelle(anketler);
                _anketlerReporsitory.Kaydet();
                TempData["Basarili"] = "Yeni Anketler Başarıyla Güncellendi!";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id) //? nulluble olabilir anlamıjna gelir.
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Anketler? anketlerDb = _anketlerReporsitory.Get(u => u.Id == id);
            if (anketlerDb == null)
            {
                return NotFound();
            }
            return View(anketlerDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id  )
        {
            Anketler? anketlerDb = _anketlerReporsitory.Get(u => u.Id == id);
            if (anketler == null)
            {
                return NotFound();
            }
            _anketlerReporsitory.Sil(anketler);
            _anketlerReporsitory.Kaydet();
            TempData["Basarili"] = "Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index");

        }
    }
}
