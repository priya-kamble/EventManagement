using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.ViewModels;


namespace WebMvc.ViewComponents
{
    public class Cart: ViewComponent 
    {
        private readonly ICartService _cartsvc;
        public Cart(ICartService cartsvc) =>  _cartsvc = cartsvc;
        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {
            var vm = new CartComponentViewModel();
            try
            {
                var cart = await _cartsvc.GetCart(user);
                vm.TicketsInCart = cart.CartTickets.Count;
                vm.TotalCost = cart.Total();
            }

            catch(BrokenCircuitException)
            {
                ViewBag.IsBasketInoperative = true;
            }
            return View(vm);
        }
    }
}
