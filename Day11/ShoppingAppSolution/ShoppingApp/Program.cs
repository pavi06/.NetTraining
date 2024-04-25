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
        public void UpdateProduct(ProductBL productBl, Cart cart)
        {
            try
            {
                var productList = productBl.GetAllProduct();
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
            Console.WriteLine("---------------Creating Customers--------------");
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
            Console.WriteLine("---------------Creating Products--------------");
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
            }
            catch (ObjectAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void GetAllProduct(ProductBL productBl) {
            try
            {
                var productList = productBl.GetAllProduct();
                Console.WriteLine("----------Product List-----------");
                foreach (var prod in productList)
                {
                    Console.WriteLine(prod);
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
                if (productBl.GetAllCategoriesAvailable().Contains(category))
                    products = productBl.GetAllProductByAttribute("Category", category);
                else
                    products = productBl.GetAllProductByAttribute("Name", category);
                foreach (var product in products)
                {
                    Console.WriteLine(product);
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
                var cart = cartBl.GetCartByCustomerId(id);
                if (cart == null)
                {
                    Console.WriteLine("Your cart is Empty!");
                    return;
                }
                var cartList = customerBl.GetCartByCustomerId(id);
                if (cartList.Count() == 0)
                {
                    Console.WriteLine("No items where added to the cart!");
                }
                else
                {
                    Console.WriteLine("----------------Cart Details-----------\n----Items Added-----");
                    foreach (var c in cartList)
                    {
                        Console.WriteLine(c);
                    }
                    double totalAmount = cartBl.GetTotalAmountOfCartItems(cart.Id);
                    double discountAmount = cartBl.GetDiscountAmount(cartBl.GetCartItemsCount(cart.Id), totalAmount);
                    double shippingCharges = cartBl.GetShippingCharges(totalAmount);
                    Console.WriteLine("Total Amount : " + totalAmount);
                    Console.WriteLine("After Discount : " + discountAmount);
                    Console.WriteLine("Shipping charges : " + shippingCharges);
                    Console.WriteLine("\nFinal Amount : " + discountAmount + shippingCharges);
                    Console.WriteLine(" Want to PLACE ORDER ??\nEnter Y/N");
                    string userInput = Console.ReadLine();
                    while (userInput.Any(char.IsDigit))
                    {
                        Console.WriteLine("Invalid Input.Enter Again!");
                        userInput = Console.ReadLine();
                    }
                    Console.WriteLine("-----------Order Placed Successfully!!-----------------");
                    UpdateProduct(productBl,cart);
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

        public void AddProductToCart(ProductBL productBl,CartItemBL cartItemBl)
        {
            string userInput;
            try
            {
                do
                {
                    Console.WriteLine("Provide the product id : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the quanity you want : ");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    var product = productBl.GetProductById(id);
                    CartItem cartItem = new CartItem(id, product, quantity, product.Price, 0.0, new DateTime(2024, 06, 12));
                    cartItemBl.AddCartItem(cartItem);
                    Console.WriteLine("Want to add more??\nEnter Y/N");
                    userInput = Console.ReadLine();
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
                n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Want any specific Products ?? \nPress Y/N");
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() == "y")
                        {
                            Console.WriteLine("Enter Category/ProductName : ");
                            string category = Console.ReadLine();
                            GetSpcificProducts(productBl, category);
                        }
                        else
                        {
                            GetAllProduct(productBl);
                        }
                        break;
                    case 2:
                        AddProductToCart(productBl,cartItemBl);
                        break;
                    case 3:
                        Console.WriteLine("Enter your Id : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        GetMyCart(customerBl, cartBl, productBl, id);
                        break;
                    case 4:
                        Console.WriteLine("-----------Byeeeee---------------");
                        break;
                }

            } while (n != 4);
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            //IRepository<int, Product> productRepository = new ProductRepository();
            //IRepository<int, Customer> customerRepository = new CustomerRepository();
            //IRepository<int, Cart> cartRepository = new CartRepository();
            //IRepository<int, CartItem> cartItemRepository = new CartItemRepository();
            //ProductBL productBl = new ProductBL(productRepository);
            //CustomerBL customerBl = new CustomerBL(customerRepository, cartRepository);
            //CartBL cartBl = new CartBL(cartRepository);
            //CartItemBL cartItemBl = new CartItemBL(cartItemRepository, cartRepository);

            //program.AddProducts(productBl);
            //program.AddCustomers(customerBl);

            //Console.WriteLine("----------- Welcome ----------");
            //program.Menu(productBl,cartBl,cartItemBl,customerBl);    

            Cart cart = new Cart(1,1,new Customer(1,"Pavi","978675","no.3 gandhi nagar"),new List<CartItem>());
            cart.ToString();

            Customer cust = new Customer(1,"Pavi","978546","chennai");
            Console.WriteLine(cust);


        }

        
    }

}
