using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using PresentationLayer.Context;
using PresentationLayer.Models;


namespace PresentationLayer.Controllers
{
    public class WalletModelsController : Controller
    {
        private IWalletService walletService;
        private IMapper mapper;

        public WalletModelsController(IWalletService _walletService, IMapper _mapper)
        {
            walletService = _walletService;
            mapper = _mapper;
        }

        // GET: WalletModels
        public ActionResult Index()
        {
            var walletDTOs = walletService.GetWallets();
            var walletModels = mapper.Map<IEnumerable<WalletDTO>, List<WalletModel>>(walletDTOs);
            return View(walletModels);
        }

        // GET: WalletModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var walletDTOs = walletService.GetWallet((int)id);
            if (walletDTOs == null)
            {
                return HttpNotFound();
            }
            return View(mapper.Map<WalletDTO, WalletModel>(walletDTOs));
        }

        // GET: WalletModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WalletModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Balance,Name")] WalletModel walletModel)
        {
            if (ModelState.IsValid)
            {
                walletService.CreateWallet(mapper.Map<WalletModel, WalletDTO>(walletModel));
                return RedirectToAction("Index");
            }

            return View(walletModel);
        }

        //// GET: WalletModels/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WalletModel walletModel = db.WalletModels.Find(id);
        //    if (walletModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(walletModel);
        //}

        //// POST: WalletModels/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Balance,Name")] WalletModel walletModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(walletModel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(walletModel);
        //}

        //// GET: WalletModels/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    WalletModel walletModel = db.WalletModels.Find(id);
        //    if (walletModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(walletModel);
        //}

        //// POST: WalletModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    WalletModel walletModel = db.WalletModels.Find(id);
        //    db.WalletModels.Remove(walletModel);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            walletService.Dispose();
            base.Dispose(disposing);
        }
    }
}
