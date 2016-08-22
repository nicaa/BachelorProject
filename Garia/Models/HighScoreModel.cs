using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Garia.Core.Entities;
namespace Garia.Models
{
    public class HighScoreModel
    {
        public List<HighScore> HighScoreYTD { get; set; }
        public List<HighScore> HighScoreMonthly{ get; set; }
        public List<HighScore> HighscoreByDealerYear { get; set; }
        public List<HighScore> HighscoreByRegionYear { get; set; }
        public List<HighScore> HighscoreByCarYear { get; set; }
 

        public float TotalSale { get; set; }
    }
}