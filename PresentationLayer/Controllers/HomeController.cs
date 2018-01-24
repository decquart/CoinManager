using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        IWalletService walletService;

        public HomeController(IWalletService service)
        {
            walletService = service;
        }

        public ActionResult Index()
        {
            var walletDTO = walletService.GetWallets();
            Mapper.Initialize(cfg => cfg.CreateMap<WalletDTO, WalletViewModel>());
            var wallet = Mapper.Map<IEnumerable<WalletDTO>, List<WalletViewModel>>(walletDTO);
            return View(wallet);
        }

        protected override void Dispose(bool disposing)
        {
            walletService.Dispose();
            base.Dispose(disposing);
        }
    }
}