using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IyzicoPay.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            Options options = new Options();
            options.ApiKey = "API ANAHTARI";
            options.SecretKey = "API SECRETKEY";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";



            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = "1"; // Tutar
            request.PaidPrice = "1.1";
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "http:/<Iyzico Api Geri Dönüş Adresi>/OdemeSonucu"; /// Geri Dönüş Urlsi

            List<int> enabledInstallments = new List<int>();
            enabledInstallments.Add(2);
            enabledInstallments.Add(3);
            enabledInstallments.Add(6);
            enabledInstallments.Add(9);
            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer();
            buyer.Id = "1";
            buyer.Name = "Ferit";
            buyer.Surname = "Gezgil";
            buyer.GsmNumber = "-";
            buyer.Email = "info@feritgezgil.com";
            buyer.IdentityNumber = "12345678911";
            buyer.LastLoginDate = "2020-09-05 12:43:35";
            buyer.RegistrationDate = "2020-09-04 15:12:09";
            buyer.RegistrationAddress = "Antalya";
            buyer.Ip = "93.34.78.121";
            buyer.City = "İzmir";
            buyer.Country = "Turkey";
            buyer.ZipCode = "35130";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Ferit Gezgil";
            shippingAddress.City = "İzmir";
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = "Mahalle --- İzmir";
            shippingAddress.ZipCode = "35130";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = "Ferit Gezgil";
            billingAddress.City = "Turkey";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Mahalle --- İzmir";
            billingAddress.ZipCode = "35130";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();


            /** Demo ürün listesi manuel olarak doldurulmuştur.**/
            List<Product> productList = new List<Product>() { 
                new Product
                {
                    StockCode = "PR0001",
                    Name =  "Dell 5010",
                    CategoryName = "Bilgisayar",
                    SubCategoryName = "Dizüstü",
                    Price = 10350
                },
                 new Product
                {
                    StockCode = "PR0002",
                    Name =  "Asus Zenbook",
                    CategoryName = "Bilgisayar",
                    SubCategoryName = "Dizüstü",
                    Price = 12550
                }
            };
            

            foreach (var item in productList) 
            {
                BasketItem firstBasketItem = new BasketItem();
                firstBasketItem.Id = item.StockCode;
                firstBasketItem.Name = item.Name;
                firstBasketItem.Category1 = item.CategoryName;
                firstBasketItem.Category2 = item.SubCategoryName;
                firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                firstBasketItem.Price = item.Price.ToString();
                basketItems.Add(firstBasketItem);
            }

            request.BasketItems = basketItems;
            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            ViewBag.Iyzico = checkoutFormInitialize.CheckoutFormContent; //View Dönüş yapılan yer, Burada farklı yöntemler ile View gönderim yapabilirsiniz.
            return View();
        }



       public ActionResult Sonuc(RetrieveCheckoutFormRequest model)
        {

            string data = "";
            Options options = new Options();
            options.ApiKey = "API KEY";
            options.SecretKey = "API SECRETKEY";
            options.BaseUrl = "https://sandbox-api.iyzipay.com"
            data = model.Token;
            RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
            request.Token = data;
            CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, options);
            if (checkoutForm.PaymentStatus == "SUCCESS")
            {

                return RedirectToAction("Onay");
            }

            return View();
        }
    }
}
