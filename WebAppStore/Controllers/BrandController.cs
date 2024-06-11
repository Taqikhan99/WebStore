using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAppStore.DAL;
using WebAppStore.Models;
using WebAppStore.Services;
using WebAppStore.ViewModels;

namespace WebAppStore.Controllers
{
    public class BrandController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IFileService fileService;

        public BrandController(AppDbContext dbContext,IMapper mapper,IFileService fileService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.fileService = fileService;
        }


        public IActionResult Index()
        {
            var brands = dbContext.Brands.ToList();
            List<BrandViewModel> brandList = new List<BrandViewModel>();

            foreach (var brand in brands)
            {
                BrandViewModel brandViewModel = new BrandViewModel
                {
                    
                    BrandName = brand.BrandName,
                    ImageUrl = brand.ImageUrl,
                    LaptopCount=brand.Laptops.Count,
                };

                //brandViewModel.LaptopCount = brand.Laptops.Count>0 ? brand.Laptops.Count() : 0;
                brandList.Add(brandViewModel);
            }

            return View(brandList);
        }

        //Create Brand
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandViewModel brandView)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    string imagePath = fileService.UploadImage(brandView.ImageFile);
                    var brandToPost = mapper.Map<Brand>(brandView);
                    
                    //set the imagepathvalue for db model
                    brandToPost.ImageUrl=imagePath;
                    
                    await dbContext.Brands.AddAsync(brandToPost);
                    var res=await dbContext.SaveChangesAsync();

                    if(res>0)
                    {
                        return RedirectToAction("Index");
                    }

                    return View();
                }
                return View(brandView);

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }

        }

    }
}
