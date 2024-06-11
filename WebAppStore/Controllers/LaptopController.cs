using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppStore.DAL;
using WebAppStore.ViewModels;

namespace WebAppStore.Controllers
{
    public class LaptopController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IMapper mapper;

        public LaptopController(AppDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var laptops = await dbContext.Laptops.ToListAsync();

            var laptopsViews = mapper.Map<List<LaptopViewModel>>(laptops);

            return View(laptopsViews);
        }


        // create new laptop httpget
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {

            var viewModel = new LaptopViewModel
            {
                BrandsList = dbContext.Brands.ToList(),
            };

            
            return View(viewModel);
        }





    }



}
