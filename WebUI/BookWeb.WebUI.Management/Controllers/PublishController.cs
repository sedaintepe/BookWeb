using BookWeb.Datas;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace BookWeb.WebUI.Management.Controllers
{
    public class PublishController : Controller
    {
        PublishData _publish;
        public PublishController(PublishData publishData)
        {
            _publish = publishData;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var publishes = _publish.GetBy(x => !x.IsDelete);//listeler
            return View(publishes);
        }
        [HttpGet]
        public IActionResult Add()
        {
            var publish = new BookWeb.Models.PublishModel()
            {
                PublishName = "",
                PublishTime=new System.DateTime(),
                Address="",
                IsActive=false,
                IsDelete=false
                
            };
            return View(publish);
        }
        [HttpPost]
        public IActionResult Add(BookWeb.Models.PublishModel publishModel)
        {
            var error = new List<string>();
            if (string.IsNullOrEmpty(publishModel.PublishName)) error.Add("Yayın adı boş bırakılamaz");
            if (error.Count() > 0)
            {
                ViewBag.Result = "";
                return View(publishModel);
            }

            var operationResult = _publish.Insert(publishModel);
            if (operationResult.IsSucceed)
            {
                ViewBag.Result = "Eklendi";
                return View(new BookWeb.Models.PublishModel());
            }

            ViewBag.Result = "";
            return View(publishModel);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var publish = _publish.GetByKey(id);
            if (publish == null) return RedirectToAction("Index", "Home", new { q = "yayınismi-bulunamadı" });
            return View(publish);
        }
        [HttpPost]
        public IActionResult Edit(BookWeb.Models.PublishModel publishModel)
        {
            var error = new List<string>();
            var modelInDb = _publish.GetByKey(publishModel.Id);
            if (string.IsNullOrEmpty(publishModel.PublishName)) error.Add("Yayın adı boş bırakılamaz");
            if (error.Count() > 0)
            {
                ViewBag.Result = "";
                return View(publishModel);
            }
            var exist_publish=_publish.GetBy(x=>!x.IsDelete&& x.Id==publishModel.Id).FirstOrDefault();

            if (exist_publish != null)
            {
                ViewBag.Result = "";
                return View(publishModel);
            }

           modelInDb.PublishName=publishModel.PublishName;
          modelInDb.Address=publishModel.Address;
            modelInDb.PublishTime=publishModel.PublishTime;
            modelInDb.IsActive=publishModel.IsActive;

            var operationResult = _publish.Update(modelInDb);
            if (operationResult.IsSucceed)
            {
                ViewBag.Result = "Güncellendi";
                return View(publishModel);
            }

            ViewBag.Result = "";
            return View(publishModel);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var publish = _publish.GetByKey(id);
            if (publish == null)
                return RedirectToAction("Index", "Publish", new { q = "yayınadı-bulunamadi" });

            publish.IsDelete = true;
            var operationResult = _publish.Update(publish);
            if (operationResult.IsSucceed)
                return RedirectToAction("Index", "Publish", new { q = "yayınadı-silindi" });
            else
                return RedirectToAction("Index", "Publish", new { q = "yayınadı-silemedim" });
        }


    }
}
