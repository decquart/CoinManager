using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using PresentationLayer.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class WalletController : Controller
    {
        private IMapper mapper;
        private IWalletService walletService;

        public WalletController(IMapper _mapper, IWalletService _walletService)
        {
            mapper = _mapper;
            walletService = _walletService;
        }

        // GET: Wallet
        public ActionResult Index()
        {
            var walletsDTO = walletService.GetWallets();
            var wallets = mapper.Map<IEnumerable<WalletDTO>, List<WalletModel>>(walletsDTO);
            return View(wallets);
        }

        // GET: Wallet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var walletModel = walletService.GetWallet((int)id);
            if (walletModel == null)
            {
                return HttpNotFound();
            }
            return View(mapper.Map<WalletDTO, WalletModel>(walletModel));
        }

        // GET: Wallet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wallet/Create
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


            return View(mapper.Map<WalletModel, WalletDTO>(walletModel));
        }

        // GET: Wallet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var walletDTO = walletService.GetWallet((int)id);
            var walletModel = mapper.Map<WalletDTO, WalletModel>(walletDTO);
            if (walletModel == null)
            {
                return HttpNotFound();
            }
            return View(walletModel);
        }

        // POST: Wallet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Balance,Name")] WalletModel walletModel)
        {
            if (ModelState.IsValid)
            {
                var walletDTO = mapper.Map<WalletModel, WalletDTO>(walletModel);
                walletService.ChangeWalletName(walletDTO);
                return RedirectToAction("Index");
            }
            return View(walletModel);
        }

        // GET: Wallet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var walletDTO = walletService.GetWallet((int)id);
            if (walletDTO == null)
            {
                return HttpNotFound();
            }
            return View(mapper.Map<WalletDTO, WalletModel>(walletDTO));
        }

        // POST: Wallet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var walletDTO = walletService.GetWallet(id);
            walletService.RemoveWallet(walletDTO.Id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            walletService.Dispose();
            base.Dispose(disposing);
        }
    }
}
