using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DoinikSokal.BLL;
using DoinikSokal.ViewModels;

namespace DoinikSokal.Controllers
{
    public class HomeController : Controller
    {
        private CategoryManager categoryManager;
        private PostManager postManager;

        public HomeController(CategoryManager category, PostManager post)
        {
            this.categoryManager = category;
            this.postManager = post;
        }
        // GET: Home
        public ActionResult Index()
        {
            PostViewModel postViewModel = new PostViewModel();
            var homePost = postManager.GetAll().OrderByDescending(c => c.Id);
            

            var politicsPost = homePost.Where(c => c.Category.Name == "Politics");

            var datas = homePost.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Category.Name == "Politics");
            BannerViewModel bannerViewModel = new BannerViewModel()
            {
                Id = datas.Id,
                Title = datas.Title,
                Description = datas.Description,
                ImagePath = datas.ImagePath,
                Tags = datas.Tags,
                PostDate = datas.PostDate
            };

            List<SiteBannerViewModel> siteBannerViewModels = new List<SiteBannerViewModel>();
            var siteBannder = homePost.Where(c=>c.Category.Name == "Politics").OrderByDescending(c => c.Id).Skip(1).Take(2);

            foreach (var data in siteBannder)
            {
                var siteBannerVM = new SiteBannerViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    Description = data.Description,
                    ImagePath = data.ImagePath
                };
                siteBannerViewModels.Add(siteBannerVM);
            }

            /*banner Bottom post*/
            List<BannerBottomViewModel> bannerBottomViewModels = new List<BannerBottomViewModel>();
            var BannerBottom = homePost.Where(c => c.Category.Name == "Politics").OrderByDescending(c => c.Id).Skip(3).Take(4);
            foreach (var data in BannerBottom)
            {
                var bannerBottomVM = new BannerBottomViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    Description = data.Description,
                    ImagePath = data.ImagePath,
                    PostDate = data.PostDate.ToString("d")
                };
                bannerBottomViewModels.Add(bannerBottomVM);
            }
            postViewModel.BannerBottomViewModels = bannerBottomViewModels;
            /*banner Bottom post*/

            /*latest Post */
            List<LatestPostViewModel> latestPostViewModels = new List<LatestPostViewModel>();
            var latestPost = homePost.Where(c => c.Category.Name == "Politics").OrderByDescending(c => c.Id).Skip(7).Take(7);
            foreach (var data in latestPost)
            {
                var latestPostVM = new LatestPostViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    Description = data.Description,
                    ImagePath = data.ImagePath
                };
                latestPostViewModels.Add(latestPostVM);
            }
            postViewModel.LatestPostViewModels = latestPostViewModels;
            /*latest Post */

            /*popular Post */
            var popularPost = homePost.Skip(14).Take(4);
            List<PopularPostViewModel> popularPostViewModels = new List<PopularPostViewModel>();
            foreach (var data in popularPost)
            {
                var popularPostVM = new PopularPostViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    PostDate = data.PostDate.ToString("d"),
                    ImagePath = data.ImagePath,
                    Category = data.Category
                };
                popularPostViewModels.Add(popularPostVM);
            }
            postViewModel.PopularPostViewModels = popularPostViewModels;
            /*popular Post */

            /*Sports Post */
            var entertainmentPost = homePost.Where(c => c.Category.Name == "Entertainment").OrderByDescending(c => c.Id).Take(4);
            List<EntertainmentViewModel> entertainmentViewModels  = new List<EntertainmentViewModel>();
            foreach (var data in entertainmentPost)
            {
                var entertainmentVM = new EntertainmentViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    ImagePath = data.ImagePath,
                    Description = data.Description,
                    PostDate = data.PostDate.ToString("D")
                };
                entertainmentViewModels.Add(entertainmentVM);
            }
            postViewModel.EntertainmentViewModels = entertainmentViewModels;
            /*Sports Post */




            /*Sports Post */
            var sportsPost = homePost.Where(c => c.Category.Name == "Sports").OrderByDescending(c => c.Id).Take(4);
            List<SportsViewModel> sportsViewModels = new List<SportsViewModel>();
            foreach (var data in sportsPost)
            {
                var sportsVM = new SportsViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    ImagePath = data.ImagePath,
                    Description = data.Description,
                    PostDate = data.PostDate.ToString("D")
                };
                sportsViewModels.Add(sportsVM);
            }
            postViewModel.SportsViewModels = sportsViewModels;
            /*Sports Post */
            
            
            /*technology Post */
            var techPost = homePost.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Category.Name == "Technology");
            TechnologyViewModel technologyViewModel = new TechnologyViewModel()
            {
                Id = techPost.Id,
                Title = techPost.Title,
                Description = techPost.Description,
                PostDate = techPost.PostDate.ToString("D"),
                ImagePath = techPost.ImagePath
            };
            postViewModel.TechnologyViewModel = technologyViewModel;
            /*technology Post */

            /*education Post */
            var educationPost = homePost.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Category.Name == "Education");
            EducationViewModel educationViewModel = new EducationViewModel()
            {
                Id = educationPost.Id,
                Title = educationPost.Title,
                Description = educationPost.Description,
                ImagePath = educationPost.ImagePath,
                PostDate = educationPost.PostDate.ToString("D")
            };
            postViewModel.EducationViewModel = educationViewModel;
            /*education Post */

            /*travel Post */
            var travelPost = homePost.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Category.Name == "Travel");
            TravelViewModel travelViewModel = new TravelViewModel()
            {
                Id = travelPost.Id,
                Title = travelPost.Title,
                Description = travelPost.Description,
                ImagePath = travelPost.ImagePath,
                PostDate = travelPost.PostDate.ToString("D")
            };
            postViewModel.TravelViewModel = travelViewModel;
            /*travel Post */


            /*food Post */
            var foodPost = homePost.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Category.Name == "Food");
            FoodViewModel foodViewModel = new FoodViewModel()
            {
                Id = foodPost.Id,
                Title = foodPost.Title,
                Description = foodPost.Description,
                ImagePath = foodPost.ImagePath,
                PostDate = foodPost.PostDate.ToString("D")
            };
            postViewModel.FoodViewModel = foodViewModel;
            /*food Post */

            /*health Post */
            var healthPost = homePost.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Category.Name == "Health");
            HealthViewModel healthViewModel = new HealthViewModel()
            {
                Id = healthPost.Id,
                Title = healthPost.Title,
                Description = healthPost.Description,
                ImagePath = healthPost.ImagePath,
                PostDate = healthPost.PostDate.ToString("D")
            };
            postViewModel.HealthViewModel = healthViewModel;
            /*health Post */


            /*economics Post */
            var economicsPost = homePost.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Category.Name == "Economics");
            EconomicsViewModel economicsViewModel = new EconomicsViewModel()
            {
                Id = economicsPost.Id,
                Title = economicsPost.Title,
                Description = economicsPost.Description,
                ImagePath = economicsPost.ImagePath,
                PostDate = economicsPost.PostDate.ToString("D")
            };
            postViewModel.EconomicsViewModel = economicsViewModel;
            /*economics Post */

            postViewModel.BannerViewModel = bannerViewModel;
            postViewModel.SiteBannerViewModels = siteBannerViewModels;
            
            return View(postViewModel);
        }

        public ActionResult Details(int? id, string title)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var postDetails = postManager.GetById((int)id);
            PostViewModel postViewModel = new PostViewModel()
            {
                Id = postDetails.Id,
                Title = postDetails.Title,
                Description = postDetails.Description,
                ImagePath = postDetails.ImagePath
            };
            ViewBag.Title = postDetails.Title;
            ViewBag.Tags = postDetails.Tags;

            /*site popularpost*/
            var homePost = postManager.GetAll().OrderByDescending(c => c.Id);
            var popularPost = homePost.Skip(12).Take(8);
            List<PopularPostViewModel> popularPostViewModels = new List<PopularPostViewModel>();
            foreach (var data in popularPost)
            {
                var popularPostVM = new PopularPostViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    PostDate = data.PostDate.ToString("yyyy MMMM dd"),
                    ImagePath = data.ImagePath,
                    Category = data.Category
                };
                popularPostViewModels.Add(popularPostVM);
            }
            postViewModel.PopularPostViewModels = popularPostViewModels;
            /*site popularpost*/


            /*bottom popularpost*/

            var bottomPost = homePost.Skip(20).Take(8);
            List<BannerBottomViewModel> bannerBottomViewModels = new List<BannerBottomViewModel>();
            foreach (var data in bottomPost)
            {
                var bottomPostVM = new BannerBottomViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    PostDate = data.PostDate.ToString("yyyy MMMM dd"),
                    ImagePath = data.ImagePath,
                    Description = data.Description
                };
                bannerBottomViewModels.Add(bottomPostVM);
            }
            postViewModel.BannerBottomViewModels = bannerBottomViewModels;
            /*bottom popularpost*/

            return View(postViewModel);
        }

        public ActionResult Search(string SearchString)
        {
            var homePost = postManager.GetAll().OrderByDescending(c => c.Id);
            if (SearchString == null)
            {
                throw new Exception("Empty Search");
            }
            PostViewModel postViewModel = new PostViewModel();

            List<PostViewModel> postViewModels = new List<PostViewModel>();
           var searchPost = postManager.GetAll().Where(c => c.Title.Contains(SearchString) || c.Description.Contains(SearchString));
            foreach (var post in searchPost)
            {
                var postVM = new PostViewModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    ImagePath = post.ImagePath,
                    Description = post.Description
                };
                postViewModels.Add(postVM);
            }


            /*popular Post */
            var popularPost = homePost.Skip(14).Take(14);
            List<PopularPostViewModel> popularPostViewModels = new List<PopularPostViewModel>();
            foreach (var data in popularPost)
            {
                var popularPostVM = new PopularPostViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    PostDate = data.PostDate.ToString("d"),
                    ImagePath = data.ImagePath,
                    Category = data.Category
                };
                popularPostViewModels.Add(popularPostVM);
            }
            postViewModel.PopularPostViewModels = popularPostViewModels;
            /*popular Post */


            return View(postViewModels);
        }

    }
}