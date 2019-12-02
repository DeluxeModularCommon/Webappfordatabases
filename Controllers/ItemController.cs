namespace DeluxeModularProTest.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Linq;
    using DeluxeModularProTest.Services;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Microsoft.AspNetCore.Authorization;
    [Authorize]
    public class ItemController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        public ItemController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index(string searchString)
        {
            //querystring = 
            if(string.IsNullOrEmpty(searchString))
                searchString = "*";
            var querystring = "SELECT " + searchString + " FROM c";
            return View(await _cosmosDbService.GetItemsAsync(querystring));
        }

        [ActionName("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind("ProductID,ProductName,ManufactorID,CSICode,ProdCategory,ProdType,ProdMaterial,PerformanceReq,Color(Hex),Texture," +
            "Shape,Dimension,BIMObject,InstallationType,Datasheet,SafetySheet,ContactName,ContactTitle,ContactPhone,ContactEmail,Inventory")] Item item)
            {
                if (ModelState.IsValid)
                {
                    item.Id = Guid.NewGuid().ToString();
                    await _cosmosDbService.AddItemAsync(item);
                    return RedirectToAction("Index");
                }

                return View(item);
            }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind("ProductID,ProductName,ManufactorID,CSICode,ProdCategory,ProdType,ProdMaterial,PerformanceReq,Color(Hex),Texture," +
            "Shape,Dimension,BIMObject,InstallationType,Datasheet,SafetySheet,ContactName,ContactTitle,ContactPhone,ContactEmail,Inventory")] Item item)
        {
            if (ModelState.IsValid)
            {
                await _cosmosDbService.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Item item = await _cosmosDbService.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Item item = await _cosmosDbService.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        {
            await _cosmosDbService.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            return View(await _cosmosDbService.GetItemAsync(id));
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}