using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoinikSokal.BLL;
using DoinikSokal.ViewModels;

namespace DoinikSokal.Controllers
{
    public class EntertainmentController : Controller
    {
        // GET: Fashion
        private CategoryManager categoryManager;
        private PostManager postManager;

        public EntertainmentController(CategoryManager category, PostManager post)
        {
            this.categoryManager = category;
            this.postManager = post;
        }
        public ActionResult Index()
        {
            PostViewModel postViewModel = new PostViewModel();
            var homePost = postManager.GetAll().OrderByDescending(c => c.Id);
            var technologyPost = homePost.Where(c => c.Category.Name == "Entertainment");

            var datas = homePost.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Category.Name == "Entertainment");
            BannerViewModel bannerViewModel = new BannerViewModel()
            {
                Id = datas.Id,
                Title = datas.Title,
                Description = datas.Description,
                ImagePath = datas.ImagePath,
                Tags = datas.Tags,
                PostDate = datas.PostDate
            };
            postViewModel.BannerViewModel = bannerViewModel;

            List<SiteBannerViewModel> siteBannerViewModels = new List<SiteBannerViewModel>();
            var siteBannerPost = technologyPost.Skip(1).Take(2);
            foreach (var data in siteBannerPost)
            {
                var sitebannerVM = new SiteBannerViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    Description = data.Description,
                    ImagePath = data.ImagePath
                };
                siteBannerViewModels.Add(sitebannerVM);
            }
            postViewModel.SiteBannerViewModels = siteBannerViewModels;


            List<BannerBottomViewModel> bannerBottomViewModels = new List<BannerBottomViewModel>();
            var BannerbottomPost = technologyPost.Skip(3).Take(4);
            foreach (var data in BannerbottomPost)
            {
                var sitebannerVM = new BannerBottomViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    ImagePath = data.ImagePath,
                    Description = data.Description,
                    PostDate = data.PostDate.ToString("yyyy MMMM dd")
                };
                bannerBottomViewModels.Add(sitebannerVM);
            }
            postViewModel.BannerBottomViewModels = bannerBottomViewModels;


            List<LatestPostViewModel> latestPostViewModels = new List<LatestPostViewModel>();
            var latestPost = technologyPost.Skip(7).Take(20);
            foreach (var data in latestPost)
            {
                var sitebannerVM = new LatestPostViewModel()
                {
                    Id = data.Id,
                    Title = data.Title,
                    ImagePath = data.ImagePath,
                    Description = data.Description,
                };
                latestPostViewModels.Add(sitebannerVM);
            }
            postViewModel.LatestPostViewModels = latestPostViewModels;


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
            if (SearchString == null)
            {
                throw new Exception("Empty Search");
            }

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

            return View(postViewModels);
        }


    }
}