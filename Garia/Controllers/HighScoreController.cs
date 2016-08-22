using Garia.Core.Handlers;
using Garia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garia.Controllers
{
    public class HighScoreController : Controller
    {
        [Authorize]
        public ActionResult HighScore()
        {
            HighScoreModel model = new HighScoreModel();
            model.HighScoreYTD = SaleHandler.GetHighscore_YTD(DateTime.Now.Year);
            model.TotalSale = SaleHandler.TotalSaleYTD(DateTime.Now.Year);
            model.HighScoreMonthly = SaleHandler.GetHighscore_Month();
            model.HighscoreByDealerYear = SaleHandler.GetHighscoreByDealerYear();
            model.HighscoreByRegionYear = SaleHandler.GetHighscoreByRegionYear();
            model.HighscoreByCarYear = SaleHandler.GetHighscoreByCarYear();
            return View(model);

        }
	}
}