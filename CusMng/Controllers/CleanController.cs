using CusMng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CusMng.Controllers
{
    public class CleanController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        客戶資料Repository repo客戶資料 = RepositoryHelper.Get客戶資料Repository();
        vw客戶關聯資料統計表Repository vwRepo = RepositoryHelper.Getvw客戶關聯資料統計表Repository();
        // GET: Clean
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult 客戶關連統計表()
        {
            return View(vwRepo.vsList().ToList());
        }

        public ActionResult 客戶資料管理(string keyword)
        {
            var data = repo客戶資料.FindByAll(ShowAll: false, ShowCnt: 10, kWord: keyword);

            return View(data.ToList());
        }

        public ActionResult 聯絡人管理()
        {
            var 客戶聯絡人 = db.客戶聯絡人.Include(C => C.客戶資料);
            return View(客戶聯絡人.ToList());
        }

        public ActionResult 客戶銀行資訊()
        {
            var 客戶銀行資訊 = db.客戶銀行資訊.Include(客 => 客.客戶資料);
            return View(客戶銀行資訊.ToList());
        }
    }
}