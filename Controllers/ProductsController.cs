using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols;
using WebApiYayinlayalim.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApiYayinlayalim.Controllers
{

    //[Route("api/[controller]")]
    //[ApiController]
    //public class ProductsController : ControllerBase
    //{
    //    private readonly DataContext context;

    //    public ProductsController(DataContext context)
    //    {
    //        this.context = context;
    //    }

    ////GET-LİSTELE
    //[HttpGet]
    //    public async Task<ActionResult<List<Product>>> Get()
    //    {
    //        return Ok(await context.tbl_Products.ToListAaync());
    //    }

    //    //delete
    //    [HttpDelete["{id}")]

    //    public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
    //    {
    //        /* var urun = urunler.Find(p=>p.Id == id);
    //         * if (urun == nul)
    //         * {
    //         * return BadRequest("Ürün not foud");
    //         * }
    //         * urunler.Remoce(urun); 
    //         * return Ok(urunler);
    //         * */
    //        var urun = await context.tbl_Products.FindAsync(propa.Id);
    //        if (urun == null)
    //        {
    //            return BadRequest("Ürün not found");

    //        }
    //        context.tbl_Products.Remove(urun);
    //        await context.SaveChangesAsync();

    //        return Ok(await context.tbl_Products.ToListAsync());
    //    }

    //    [HttpPut]
    //    public async Task<ActionResult<List<Product>>> UpdateProduct(Product pr)
    //    {
    //        /*
    //         * var urun = urunler.Find(p=>p.Id == pr.Id);
    //         * if (urun == null)
    //         * {
    //         * return BadRequest("Ürün not found");
    //        urun.ProductName=pr.ProductName;
    //        urun.Price = pr.Price;
    //        urun.Stock = pr.Stock;
    //        return Ok(urunler);
    //        */

    //        var urun = await context.tbl_Prodcts.FindAsync(pr.id);
    //        if (urun == null)
    //        {
    //            return BadRequest("Üürn not found");

    //        }
    //        urun.ProductNmae = pr.ProductName;
    //        urun.Price = pr.Price;
    //        urun.Stock = pr.Stock;

    //        await context.SaveChanges();
    //        return Ok(await context.tbl_Products.ToListAsync());
    //    }

    //    //insert
    //    [HttpPost]
    //    public async Task<ActionResult<List<Product>>> AddProduct(Product pr)
    //    {
    //        /* urunler.Add(pr);
    //        return Ok(urunler);
    //        */

    //        contect.tbl_Products.Add(pr);
    //        await context.SaveChangesAsync();
    //        return Ok(await context.tbl_Products.ToListAsync());
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Product>> Get(int id)
    //    {
    //        /* var urun = urunler.Find(p => p.id == id);
    //         * if (urun == nul)
    //         * {
    //         * retur BadRequest("Ürün not found");
    //         * }
    //         * return Ok(urun);
    //         * */
    //        var urun = await context.tbl_Products.FindAsync(id);
    //        if (urun == null)
    //        {
    //            return BadRequest("Ürün nnot found");
    //        }
    //        return Ok(urun);
    //    }

    //    private Static List<Product> urunler = new List<Product>()
    //    {
    //        new Product
    //        {
    //            Id = 1,
    //            ProductName = "Ürün1",
    //            Price = 1000,
    //            Stock  = 35
    //        },

    //          new Product
    //        {
    //            Id = 2,
    //            ProductName = "Ürün2",
    //            Price = 2000,
    //            Stock  = 25
    //        },
    //                new Product
    //        {
    //            Id = 3,
    //            ProductName = "Ürün3",
    //            Price = 3000,
    //            Stock  = 35
    //        }

    //    };
    //}
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    namespace WebApiYayinlayalim.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ProductsController : ControllerBase
        {
            private static List<Product> urunler = new List<Product>()
        {
            new Product
            {
                Id = 1,
                ProductName = "Ürün1",
                Price = 1000,
                Stock  = 35
            },
            new Product
            {
                Id = 2,
                ProductName = "Ürün2",
                Price = 2000,
                Stock  = 25
            },
            new Product
            {
                Id = 3,
                ProductName = "Ürün3",
                Price = 3000,
                Stock  = 35
            }
        };

            [HttpGet]
            public ActionResult<List<Product>> Get()
            {
                return Ok(urunler);
            }

            [HttpGet("{id}")]
            public ActionResult<Product> Get(int id)
            {
                var urun = urunler.FirstOrDefault(p => p.Id == id);
                if (urun == null)
                {
                    return NotFound("Ürün not found");
                }
                return Ok(urun);
            }

            [HttpPost]
            public ActionResult<List<Product>> AddProduct(Product pr)
            {
                pr.Id = urunler.Count + 1; 
                urunler.Add(pr);
                return Ok(urunler);
            }

            [HttpPut("{id}")]
            public ActionResult<List<Product>> UpdateProduct(int id, Product pr)
            {
                var urun = urunler.FirstOrDefault(p => p.Id == id);
                if (urun == null)
                {
                    return NotFound("Ürün not found");
                }

                urun.ProductName = pr.ProductName;
                urun.Price = pr.Price;
                urun.Stock = pr.Stock;

                return Ok(urunler);
            }

            [HttpDelete("{id}")]
            public ActionResult<List<Product>> DeleteProduct(int id)
            {
                var urun = urunler.FirstOrDefault(p => p.Id == id);
                if (urun == null)
                {
                    return NotFound("Ürün not found");
                }

                urunler.Remove(urun);
                return Ok(urunler);
            }
        }

        public class Product
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }
    }

}

