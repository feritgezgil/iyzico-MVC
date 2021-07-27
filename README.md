iyzico-MVC5

    iyzico Sanalpos Entegrasyonu ile Asp.Net MVC kullanımı için örnek bir şablondur.

IyziPay NuGet Kurulumu

    Yöntem 1: Package Manager Console -> Install-Package Iyzipay
    Yöntem 2: NuGet yönetimi penceresinden, IyziPay yazarak NuGet paketini projeye dahil ediniz.
  
API ayarları

    •	İyzico üyelik işlemlerini tamaladıktan sonra, size verilecek bilgileri HomeController.cs dosyasında aşağıdaki alanlara işleyiniz.

            options.ApiKey = "API ANAHTARI";
            options.SecretKey = "API SECRETKEY";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

    •	Geri dönüş URL'nizi İzyco Panel üzerinden tanımlayınız ve HomeController.cs içerisinde bu adresi belirtiniz.

            request.CallbackUrl = "http:/<Iyzico Api Geri Dönüş Adresi>/OdemeSonucu"; /// Geri Dönüş Urlsi

