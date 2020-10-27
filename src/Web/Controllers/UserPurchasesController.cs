using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class UserPurchasesController : Controller
    {
        public readonly PurchaseUserAppInterface _PurchaseUserAppInterface;
        public readonly UserManager<ApplicationUser> _UserManager;

        public UserPurchasesController(
            PurchaseUserAppInterface purchaseUserAppInterface,
            UserManager<ApplicationUser> userManager
        )
        {
            _PurchaseUserAppInterface = purchaseUserAppInterface;
            _UserManager = userManager;
        }

        [HttpPost("/api/addProductsToCart")]
        public async Task<JsonResult> AddProductsToCart(Guid productId, string productName, string purchaseAmount)
        {
            var loggedUser = await _UserManager.GetUserAsync(User);
            if (loggedUser != null)
            {
                await _PurchaseUserAppInterface.Add(new PurchaseUser()
                {
                    ProductId = productId,
                    PurchaseAmount = Convert.ToInt32(purchaseAmount),
                    PurchaseStatus = PurchaseStatusEmum.InCart,
                    UserId = loggedUser.Id
                });
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpGet("/api/UserCartProductQuantity")]
        public async Task<JsonResult> UserCartProductQuantity()
        {
            var loggedUser = await _UserManager.GetUserAsync(User);
            var quantity = 0;
            if (loggedUser != null)
            {
                quantity = await _PurchaseUserAppInterface.UserCartProductQuantity(loggedUser.Id);
                return Json(new { success = true, quantity = quantity });
            }
            return Json(new { success = false, quantity = quantity });
        }
    }
}
