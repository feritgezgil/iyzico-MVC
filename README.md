iyzico-MVC5

   iyzico Sanalpos Entegrasyonu ile Asp.Net MVC kullanımı için örnek bir şablondur.

IyziPay NuGet Kurulumu

    Yöntem 1: Package Manager Console -> Install-Package Iyzipay
    Yöntem 2: NuGet yönetimi penceresinden, IyziPay yazarak NuGet paketini projeye dahil ediniz.
  
API Ayarları

   •	İyzico üyelik işlemlerini tamaladıktan sonra, size verilecek bilgileri HomeController.cs dosyasında aşağıdaki alanlara işleyiniz.

            options.ApiKey = "API ANAHTARI";
            options.SecretKey = "API SECRETKEY";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

   •	Geri dönüş URL'nizi İzyco Panel üzerinden tanımlayınız ve HomeController.cs içerisinde bu adresi belirtiniz.

            request.CallbackUrl = "http:/<Iyzico Api Geri Dönüş Adresi>/OdemeSonucu"; /// Geri Dönüş Urlsi


Ödeme Formu Başlatma
   •  CheckoutFormContent parametresi iyzico ödeme formunu oluşturmak için gerekli HTML kodunu içermektedir. chekoutFormContent parametresini bastırdığınız sayfada aşağıdaki "div" satırını eklediğiniz alanda ödeme formu oluşacaktır.

   •	Ödeme Formlarına SAhip Olabileceğiniz Senaryolar.

            //Responsive kullanım
            <div id="iyzipay-checkout-form" class="responsive"></div>

            //Pop-up kullanım
            <div id="iyzipay-checkout-form" class="popup"></div>
            iyzico tarafından barındırılan entegrasyonlar için

   	      //iframe kullanım
            paymentPageUrl parametresi ile dönen değere &iframe=true ifadesi eklenip kaynak olarak gösterilir.

            //ortak ödeme sayfası kullanım
            paymentPageUrl parametresi ile dönen değere yönlendirilir.


Test Kart Bilgileri

   •	Bir ödemeyi simüle etmek için aşağıdaki test kartları kullanabilirsiniz.

            Kart numarası	   Banka	   Kart tipi
            _____________________________________________
            5890040000000016	Akbank	Ana Kart (Banka)
            5526080000000006	Akbank	Ana Kart (Kredi)
            4766620000000001	Denizbank	Vize (Borç)
            4603450000000000	Denizbank	Vize (Kredi)
            4987490000000002	Finansbank	Vize (Borç)
            5311570000000005	Finansbank	Ana Kart (Kredi)
            97920200000000001	Finansbank	Troya (Borç)
            9792030000000000	Finansbank	Troya (Kredi)
            5170410000000004	Garanti Bankası	Ana Kart (Banka)
            5400360000000003	Garanti Bankası	Ana Kart (Kredi)
            374427000000003	Garanti Bankası	American Express
            4475050000000003	Halkbank	Vize (Borç)
            5528790000000008	Halkbank	Ana Kart (Kredi)
            4059030000000009	HSBC Bankası	Vize (Borç)
            5504720000000003	HSBC Bankası	Ana Kart (Kredi)
            5892830000000000	Türkiye İş Bankası	Ana Kart (Banka)
            4543590000000006	Türkiye İş Bankası	Vize (Kredi)
            4910050000000006	Vakıfbank	Vize (Borç)
            4157920000000002	Vakıfbank	Vize (Kredi)
            5168880000000002	Yapı ve Kredi Bankası	Ana Kart (Banka)
            5451030000000000	Yapı ve Kredi Bankası	Ana Kart (Kre

