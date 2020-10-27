using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        public readonly ProductAppInterface _productAppInterface;
        public readonly PurchaseUserAppInterface _PurchaseUserAppInterface;
        public readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(
            ProductAppInterface productAppInterface,
            PurchaseUserAppInterface purchaseUserAppInterface,
            UserManager<ApplicationUser> userManager)
        {
            _productAppInterface = productAppInterface;
            _PurchaseUserAppInterface = purchaseUserAppInterface;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _productAppInterface.ListUserProducts(await getLoggedUserId()));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            return View(await _productAppInterface.GetEntityById(id));
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                product.UserId = await getLoggedUserId();
                await _productAppInterface.AddProduct(product);
                if (product.Notifications.Any())
                {
                    foreach (var item in product.Notifications)
                    {
                        ModelState.AddModelError(item.PropertyName, item.Message);
                    }
                    return View("Create", product);
                }
            }
            catch
            {
                return View("Create", product);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _productAppInterface.GetEntityById(id));
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Product product)
        {
            try
            {
                await _productAppInterface.UpdateProduct(product);
                if (product.Notifications.Any())
                {
                    foreach (var item in product.Notifications)
                    {
                        ModelState.AddModelError(item.PropertyName, item.Message);
                    }
                    ViewBag.Alert = true;
                    ViewBag.Message = "Verifique, ocorreu algum erro!";
                    return View("Edit", product);
                }
            }
            catch
            {
                return View("Edit", product);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _productAppInterface.GetEntityById(id));
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, Product product)
        {
            try
            {
                var productToDelete = await _productAppInterface.GetEntityById(id);
                await _productAppInterface.Delete(productToDelete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/listProductsWithStock")]
        public async Task<JsonResult> ListProductsWithStock()
        {
            return Json(await _productAppInterface.ListProductsWithStock());
        }

        public async Task<ActionResult> ListProductsUserCart()
        {
            var loggedUserId = await getLoggedUserId();
            return View(await _productAppInterface.ListProductsUserCart(loggedUserId));
        }

        public async Task<IActionResult> RemoveCart(Guid id)
        {
            return View(await _productAppInterface.GetProductCart(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCart(Guid id, Product product)
        {
            try
            {
                var purchaseUserToDelete = await _PurchaseUserAppInterface.GetEntityById(id);
                await _PurchaseUserAppInterface.Delete(purchaseUserToDelete);
                return RedirectToAction(nameof(ListProductsUserCart));
            }
            catch
            {
                return View();
            }
        }

        private async Task<string> getLoggedUserId()
        {
            var user = await _userManager.GetUserAsync(User);
            return user.Id;
        }
    }
}
