using Microsoft.AspNetCore.Mvc;
using zeynep.Models;
using zeynep.Repositories;

namespace zeynep.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyReporsitory _surveyReporsitory;
        private object survey;

        public SurveyController(ISurveyReporsitory context)
        {
            _surveyReporsitory = context;
        }
        public IActionResult Index()
        {
            List<Survey> objSurveyList = _surveyReporsitory.GetAll().ToList();

            return View(objSurveyList);
        }

        public IActionResult Add() 
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Add(Survey survey)
        {
            if (ModelState.IsValid)
            {
                _surveyReporsitory.Ekle(survey);
                _surveyReporsitory.Kaydet();
                TempData["Basarili"] = "Yeni Anket Sorusu Başarıyla Oluşturuldu!";
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
            Survey? surveyDb = _surveyReporsitory.Get(u=>u.Id==id);
            if (surveyDb == null) 
            {
                return NotFound();
            }
            return View(surveyDb);
        }

        [HttpPost]
        public IActionResult Update(Survey survey)
        {
            if (ModelState.IsValid)
            {
                _surveyReporsitory.Guncelle(survey);
                _surveyReporsitory.Kaydet();
                TempData["Basarili"] = "Yeni Anket Sorusu Başarıyla Güncellendi!";
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
            Survey? surveyDb = _surveyReporsitory.Get(u => u.Id == id);
            if (surveyDb == null)
            {
                return NotFound();
            }
            return View(surveyDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id  )
        {
            Survey? surveyDb = _surveyReporsitory.Get(u => u.Id == id);
            if (survey == null)
            {
                return NotFound();
            }
            _surveyReporsitory.Sil((Survey)survey);
            _surveyReporsitory.Kaydet();
            TempData["Basarili"] = "Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index");

        }
    }
}
