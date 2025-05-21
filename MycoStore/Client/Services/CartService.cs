using Blazored.LocalStorage;
using MycoStore.Shared;

namespace MycoStore.Client.Services
{
    public class CartService
    {
        public event Action? OnChange;
        private readonly ILocalStorageService _localStorage;

        private List<CartItem> CartItems { get; set; } = new();

        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public IReadOnlyList<CartItem> GetCartItems() => CartItems.AsReadOnly();

        public void AddToCart(MushroomProduct product)
        {
            var existing = CartItems.FirstOrDefault(i => i.ProductId == product.Id);
            if (existing != null)
                existing.Quantity++;
            else
                CartItems.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    ImageUrl = product.ImageUrl,
                    Quantity = 1
                });

            NotifyStateChanged();
        }

        public void RemoveFromCart(int productId)
        {
            var item = CartItems.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                CartItems.Remove(item);
                NotifyStateChanged();
            }
        }

        public void ClearCart()
        {
            CartItems.Clear();
            NotifyStateChanged();
        }

        public decimal GetTotalPrice() => CartItems.Sum(i => i.TotalPrice);

        private async void NotifyStateChanged()
        {
            await _localStorage.SetItemAsync("cart", CartItems);
            OnChange?.Invoke();
        }

        public async Task LoadCartAsync()
        {
            var storedCart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (storedCart != null)
            {
                CartItems = storedCart;
                OnChange?.Invoke();
            }
        }
    }
}
