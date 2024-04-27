using ShoppingAppBLLLibrary;
using ShoppingAppDALLibrary;
using ShoppingAppModelLibrary;
using ShoppingAppModelLibrary.CustomExceptions;
using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace ShoppingApp
{
    internal class Program
    {
        public int GetNumericInputFromUser() {
            int userInput;
            while(!int.TryParse(Console.ReadLine(),out userInput))
                Console.WriteLine("Invalid Input! Provide numeric values alone.");
            return userInput;
        }
        public string GetYOrNoFromUser()
        {
            string userInput = Console.ReadLine();
            while (userInput.ToLower() != "n" && userInput.ToLower() != "y")
            {
                Console.WriteLine("Invalid input! Enter Either 'Y' or 'N'..");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        public void UpdateProduct(ProductBL productBl, Cart cart)
        {
            try
            {
                var productList = productBl.GetAllProduct().Result;
                foreach (var cartItem in cart.CartItems)
                {
                    var product = productList.FirstOrDefault(x => x.Id == cartItem.Id);
                    product.QuantityInHand -= cartItem.Quantity;
                    productBl.UpdateProduct(product);
                }
            }
            catch (NoObjectsAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ObjectNotAvailableException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void AddCustomers(CustomerBL customerBl)
        {
            try
            {
                Customer customer = new Customer("Pavi", "98968675645", "No.3 Chennai,TamilNadu");
                customerBl.AddCustomer(customer);
                customer = new Customer("Viji", "98967675644", "No.5 Chennai,TamilNadu");
                customerBl.AddCustomer(customer);

            }
            catch (ObjectAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void AddProducts(ProductBL productBl)
        {
            try
            {
                Product product = new Product("Pencil Box", 150.05, "Stationery", 50);
                productBl.AddProduct(product);
                product = new Product("Sunscream", 250.05, "Beauty", 50);
                productBl.AddProduct(product);
                product = new Product("HairOil", 253.00, "HairCare", 50);
                productBl.AddProduct(product);
                product = new Product("LipBalm", 300.05, "Beauty", 5);
                productBl.AddProduct(product);
                product = new Product("Painting Canvas", 500.00, "Stationery", 5);
                productBl.AddProduct(product);
                product = new Product("Camel Paint", 500.00, "Stationery", 15);
                productBl.AddProduct(product);
                product = new Product("TeddyBear", 500.00, "Toys", 5);
                productBl.AddProduct(product);
                product = new Product("Glitter Foam Sheet", 80.00, "Statinery", 5);
                productBl.AddProduct(product);
            }
            catch (ObjectAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void GetAllProduct(ProductBL productBl) {
            try
            {
                var productList = productBl.GetAllProduct().Result;
                Console.WriteLine("----------Product List-----------");
                foreach (var prod in productList)
                {
                    if (prod.QuantityInHand != 0)
                    {
                        Console.WriteLine(prod);
                    }                    
                }
            }
            catch (NoObjectsAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetSpcificProducts(ProductBL productBl,string category)
        {
            try
            {
                Console.WriteLine("---------------Products Based on Your Search----------------");
                List<Product> products = new List<Product>();
                if (productBl.GetAllCategoriesAvailable().Result.Contains(category.ToLower()))
                    products = productBl.GetAllProductByAttribute("Category", category).Result;
                else
                    products = productBl.GetAllProductByAttribute("Name", category).Result;
                foreach (var product in products)
                {
                    Console.WriteLine(product+"\n");
                }
            }
            catch (NoObjectsAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NullValueException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void GetMyCart(CustomerBL customerBl, CartBL cartBl,ProductBL productBl, int id)
        {
            try
            {
                var cart = cartBl.GetCartByCustomerId(id).Result;
                var cartList = customerBl.GetCartByCustomerId(id).Result;
                if (cartList.Count() == 0)
                {
                    Console.WriteLine("Your cart is Empty!");
                }
                else
                {
                    Console.WriteLine("----------------Cart Details-----------");
                    foreach (var c in cartList)
                    {
                        Console.WriteLine(c);
                    }
                    //double totalAmount = cartBl.GetTotalAmountOfCartItems(cart.Id);
                    //double discountAmount = cartBl.GetDiscountAmount(cartBl.GetCartItemsCount(cart.Id), totalAmount);
                    //double shippingCharges = cartBl.GetShippingCharges(totalAmount);
                    Console.WriteLine("Price : $" + Math.Round(cart.TotalAmount,2));
                    Console.WriteLine("Discount Percent : -"+Math.Round(cartBl.GetDiscountPercent(cartBl.GetCartItemsCount(cart.Id).Result, cart.TotalAmount),2)+"%");
                    Console.WriteLine("After Discount: $"+ Math.Round(cart.DiscountAmount,2));
                    Console.WriteLine("Shipping charges : " + Math.Round(cart.ShippingCharges,2));
                    Console.WriteLine("\nTotal Amount : " + Math.Round(cart.DiscountAmount + cart.ShippingCharges,2));
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Want to PLACE ORDER ??\nEnter Y/N");
                    string userInput = GetYOrNoFromUser();
                    if(userInput.ToLower() == "y")
                    {
                        Console.WriteLine("-----------Order Placed Successfully!!-----------------");
                        UpdateProduct(productBl, cart);
                        var updateCart = cartBl.GetCartByCustomerId(id).Result;
                        updateCart.CartItems.Clear();
                        cartBl.UpdateCart(updateCart);
                    }
                    else
                    {
                        Console.WriteLine("Want to Remove any product from cart ? Enter Y/N :");
                        string userInputFromConsole = GetYOrNoFromUser();
                        if(userInputFromConsole.ToLower() == "y")
                        {
                            Console.WriteLine("Provide the Product Id : ");
                            int prodId = GetNumericInputFromUser();
                            var product = cartBl.DeleteCartItemByCutsomerIdAndProductId(id, prodId).Result;
                            Console.WriteLine("Deleted Product from cart"+product);
                        }
                    }                    
                }             
            }
            catch (ObjectNotAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NoObjectsAvailableException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddProductToCart(ProductBL productBl,CartItemBL cartItemBl,CartBL cartBl,CustomerBL customerBl)
        {
            string userInput;
            Console.WriteLine("Enter your Id : ");
            int custId = GetNumericInputFromUser();
            while (!customerBl.GetAllCustomerId().Result.Contains(custId)) {
                Console.WriteLine("Invalid Customer ID. Enter Again!");
                custId = Convert.ToInt32(Console.ReadLine());
            }             
            
            try
            {
                do
                {                    
                    Console.WriteLine("Provide the product id : ");
                    int id = GetNumericInputFromUser();
                    Console.WriteLine("Enter the quanity you want : ");
                    int quantity = GetNumericInputFromUser();
                    var product = productBl.GetProductById(id).Result;
                    var cart = cartBl.GetAllCarts().Result.Find(c=>c.CustomerId == custId);
                    CartItem cartItem = new CartItem(cart.Id, id, product, quantity, product.Price, 0.0, new DateTime(2024, 06, 12));
                    cartItemBl.AddCartItem(cartItem);
                    Console.WriteLine("Want to add more??\nEnter Y/N");
                    userInput = GetYOrNoFromUser();

                } while (userInput.ToLower() != "n");
            }
            catch (ObjectNotAvailableException e)
            {
                Console.WriteLine(e.Message);
            } 
            catch(ObjectAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(CartLimitExceedsException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void Menu(ProductBL productBl,CartBL cartBl,CartItemBL cartItemBl,CustomerBL customerBl)
        {
            int n = 0;
            do
            {
                Console.WriteLine("-------------Menu-------------\n1.Get Products\n2.Add Items to cart\n3.Get Cart\n4.Exit");
                n = GetNumericInputFromUser();
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Want any specific Products ?? \nPress Y/N");
                        string userInput = GetYOrNoFromUser();
                        if (userInput.ToLower() == "y")
                        {
                            Console.WriteLine("Enter Category/ProductName : ");
                            string category = Console.ReadLine();
                            while (category.Any(char.IsDigit))
                            {
                                Console.WriteLine("Invalid Input.Enter Again!");
                                category = Console.ReadLine();
                            }
                            GetSpcificProducts(productBl, category);
                        }
                        else
                        {
                            GetAllProduct(productBl);
                        }
                        break;
                    case 2:
                        AddProductToCart(productBl,cartItemBl,cartBl,customerBl);
                        break;
                    case 3:
                        Console.WriteLine("Enter your Id : ");
                        int id = GetNumericInputFromUser();
                        GetMyCart(customerBl, cartBl, productBl, id);
                        break;
                    case 4:
                        Console.WriteLine("-----------Thank you! Shop Again---------------");
                        break;
                }

            } while (n != 4);
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            IRepository<int, Product> productRepository = new ProductRepository();
            IRepository<int, Customer> customerRepository = new CustomerRepository();
            IRepository<int, Cart> cartRepository = new CartRepository();
            IRepository<int, CartItem> cartItemRepository = new CartItemRepository();
            ProductBL productBl = new ProductBL(productRepository);
            CustomerBL customerBl = new CustomerBL(customerRepository, cartRepository);
            CartBL cartBl = new CartBL(cartRepository);
            CartItemBL cartItemBl = new CartItemBL(cartItemRepository, cartRepository);

            program.AddProducts(productBl);
            program.AddCustomers(customerBl);

            Console.WriteLine("----------- Welcome ----------");
            program.Menu(productBl, cartBl, cartItemBl, customerBl);


        }

        
    }

}
