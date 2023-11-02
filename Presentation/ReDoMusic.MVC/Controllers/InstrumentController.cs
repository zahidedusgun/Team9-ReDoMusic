﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDoMusic.Persistence.Contexts;


namespace ReDoMusic.MVC.Controllers
{
    public class InstrumentController : Controller
    {
        private readonly ReDoMusicDbContext _dbContext;

        public InstrumentController()
        {
            _dbContext = new();
        }

        public IActionResult Index() //All Instruments will be shown
        {
            var products = _dbContext.Instruments.ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var brands = _dbContext.Brands.ToList();
            return View(brands);
        }


        [HttpPost]
        public IActionResult Add(string name, string description, string brandId, string categoryId, string price, string barcode, string pictureUrl)
        {
            var brand = _dbContext.Brands.Where(x => x.Id == Guid.Parse(brandId)).FirstOrDefault();
            var category = _dbContext.Category.Where(x => x.Id == Guid.Parse(categoryId)).FirstOrDefault();

            var instrument = new ReDoMusic.Domain.Entities.Instrument()
            {

                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = Convert.ToDecimal(price),
                Barcode = barcode,
                Brand = brand,
                Category = category,
                CreatedOn = DateTime.UtcNow,
                PictureUrl = pictureUrl
            };

            _dbContext.Instruments.Add(instrument);

            _dbContext.SaveChanges();

            return RedirectToAction("add");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Inspect(string id)
        {
            var instrument = _dbContext.Instruments.Where(x => x.Id == Guid.Parse(id)).FirstOrDefault();

            return View(instrument);
        }
    }
}