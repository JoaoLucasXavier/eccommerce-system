using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;
using Application.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private IWebHostEnvironment _environment;

        public ProductsController(
            ProductAppInterface productAppInterface,
            PurchaseUserAppInterface purchaseUserAppInterface,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            _productAppInterface = productAppInterface;
            _PurchaseUserAppInterface = purchaseUserAppInterface;
            _userManager = userManager;
            _environment = environment;
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
                product.Url = await UploadProductsImage(product);
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

        private async Task<string> UploadProductsImage(Product screenProduct)
        {
            try
            {
                var imgPrefix = Guid.NewGuid() + "_";
                var url = "~/img/productImage/" + imgPrefix + screenProduct.Image.FileName;

                if (screenProduct.Image.Length <= 0) throw new System.ArgumentException("File not found.");
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/img/productImage", imgPrefix + screenProduct.Image.FileName);
                if (System.IO.File.Exists(path)) throw new System.ArgumentException("A file with that name already exists.");
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await screenProduct.Image.CopyToAsync(stream);
                }
                return url;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task SaveProductsImage(Product screenProduct)
        {
            try
            {
                var product = await _productAppInterface.GetEntityById(screenProduct.Id);
                if (screenProduct.Image != null)
                {
                    var webRoot = _environment.WebRootPath;
                    var permissionSet = new PermissionSet(PermissionState.Unrestricted);
                    var writePermission = new FileIOPermission(FileIOPermissionAccess.Append, string.Concat(webRoot, "/productImage"));
                    permissionSet.AddPermission(writePermission);
                    var extension = System.IO.Path.GetExtension(screenProduct.Image.FileName);
                    var fileName = string.Concat(product.Id.ToString(), extension);
                    var saveFileDirectory = string.Concat(webRoot, "\\productImage\\", fileName);
                    screenProduct.Image.CopyTo(new FileStream(saveFileDirectory, FileMode.Create));
                    product.Url = string.Concat("https://localhost:5001", "/productImage/", fileName);
                    await _productAppInterface.UpdateProduct(product);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        private async Task<string> getLoggedUserId()
        {
            var user = await _userManager.GetUserAsync(User);
            return user.Id;
        }
    }
}
