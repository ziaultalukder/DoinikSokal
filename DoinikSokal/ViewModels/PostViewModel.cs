using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DoinikSokal.Models.Models;

namespace DoinikSokal.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public DateTime PostDate { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public double Views { get; set; }
        public bool IsDeleted { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public BannerViewModel BannerViewModel { get; set; }
        public IEnumerable<BannerViewModel> BannerViewModels { get; set; }
        public IEnumerable<SiteBannerViewModel> SiteBannerViewModels { get; set; }
        public IEnumerable<BannerBottomViewModel> BannerBottomViewModels { get; set; }
        public IEnumerable<LatestPostViewModel> LatestPostViewModels { get; set; }
        public IEnumerable<SportsViewModel> SportsViewModels { get; set; }
        public IEnumerable<EntertainmentViewModel> EntertainmentViewModels { get; set; }
        public TechnologyViewModel TechnologyViewModel { get; set; }
        public EducationViewModel EducationViewModel { get; set; }
        public TravelViewModel TravelViewModel { get; set; }
        public FoodViewModel FoodViewModel { get; set; }
        public HealthViewModel HealthViewModel { get; set; }
        public EconomicsViewModel EconomicsViewModel { get; set; }
        public IEnumerable<PopularPostViewModel> PopularPostViewModels { get; set; }
        public TitleTagDescriptionViewModel TitleTagDescriptionViewModel { get; set; }

    }
}
