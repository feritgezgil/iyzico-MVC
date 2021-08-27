using IyzicoPay.Models;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace IyzicoPay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Options options = new Options();
            options.ApiKey = "sandbox-......"; //Iyzico Tarafından Sağlanan Api Key
            options.SecretKey = "sandbox-..."; //Iyzico Tarafından Sağlanan Secret Key
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            //Kart Bilgilerini Dolduralım.
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

            //Alıcı Bilgilerini Dolduralım.
            Buyer buyer = new Buyer();
            buyer.Id = "1";
            buyer.Name = "Ferit";
            buyer.Surname = "Gezgil";
            buyer.GsmNumber = "-";
            buyer.Email = "info@feritgezgil.com";
            buyer.IdentityNumber = "12345678911";
            buyer.LastLoginDate = "2015-09-04 11:40:00";
            buyer.RegistrationDate = "2013-03-12 13:11:00";
            buyer.RegistrationAddress = "İzmir";
            buyer.Ip = "91.93.129.194";
            buyer.City = "İzmir";
            buyer.Country = "Turkey";
            buyer.ZipCode = "35130";
            request.Buyer = buyer;
            Address shippingAddress = new Address();
            shippingAddress.ContactName = "Ferit Gezgil";
            shippingAddress.City = "Antalya";
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

            //DummyListCreateile Yeni Bir Ürün Listesi Olşuturarak, Iyzico BasketItem modeline aktarıyoruz.
            //Buradaki Listeyi, Farklı bir View'den ürün seçimi yapılarak alabilirsiniz. !
            DummyListCreate newList = new DummyListCreate();
            List<Product> dummyBasketItems = newList.GetProductList();

            //Satın alınan ürün bilgilerini dolduralım.
            foreach (var item in dummyBasketItems) 
            {
                BasketItem basketItem = new BasketItem();
                basketItem.Id = item.ProductCode;
                basketItem.Name = item.Name;
                basketItem.Category1 = item.Category;
                basketItem.Category2 = item.SubCategory;
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                basketItem.Price = item.Price.ToString();
                basketItems.Add(basketItem);
            }

            request.BasketItems = basketItems;
            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            ViewBag.Iyzico = checkoutFormInitialize.CheckoutFormContent; 
            //View Dönüş yapılan yer, Burada farklı yöntemler ile View gönderim yapabilirsiniz.
            return View();
        }

        public ActionResult ResultPay(RetrieveCheckoutFormRequest model)
        {
            string data = "";
            Options options = new Options();
            options.ApiKey = "sandbox-......"; //Iyzico Tarafından Sağlanan Api Key
            options.SecretKey = "sandbox-...."; //Iyzico Tarafından Sağlanan Secret Key
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
             data = model.Token;
            RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
            request.Token = data;
            CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, options);
            if (checkoutForm.PaymentStatus == "SUCCESS")
            {
                return RedirectToAction("Confirmation");
            }

            return View();
        }


        public ActionResult Confirmation()
        {
            return View();
        }

    }
}