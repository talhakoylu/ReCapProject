using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //brand
        public static string BrandGetAllSuccess = "Markalar başarılı bir şekilde getirildi.";
        public static string BrandGetAllError = "Markalar getirilimedi. Acaba hiç marka bulunmuyor olmasın?";
        public static string BrandGetError = "Lütfen geçerli bir marka seçiniz!";
        public static string BrandGetSuccess = "Markaya başarılı bir şekilde ulaşıldı.";
        public static string BrandAddError = "Marka isim uzunluğu 2 karakterdan fazla olmalıdır.";
        public static string BrandAddSuccess = "Marka başarılı bir şekilde eklendi.";
        public static string BrandDeleteSuccess = "Marka başarılı bir şekilde silindi.";
        public static string BrandDeleteError = "Geçerli bir marka seçmelisiniz.";
        public static string BrandUpdateSuccess = "Marka başarılı bir şekilde güncellendi.";
        public static string BrandUpdateError = "Geçerli bir marka seçmelisiniz.";
        //car
        public static string CarAddErrorDailyPrice = "Araç fiyatı 0dan büyük olmak zorunda.";
        public static string CarAddErrorName = "Araç ismi en az 3 karakter olmalıdır.";
        public static string CarAddSuccess = "Araç başarılı bir şekilde eklendi.";
        public static string CarUpdateSuccess = "Araç başarılı bir şekilde güncellendi.";
        public static string CarUpdateError = "Geçerli bir araç seçiniz.";
        public static string CarDeleteSuccess = "Araç başarılı bir şekilde silindi.";
        public static string CarDeleteError = "Lütfen geçerli bir araç seçiniz.";
        public static string CarGetAllSuccess = "Araçlar başarılı bir şekilde listelendi.";
        public static string CarGetAllError = "Araçlar getirilirken bir sorunla karşılaşıldı.";
        public static string CarGetByIdError = "Araç bulunamadı.";
        public static string CarGetByIdSuccess = "Araç bilgilerine başarılı bir şekilde erişildi.";
        public static string CarGetCarsByBrandIdSuccess = "Markaya göre araç bilgilerine başarılı bir şekilde erişildi.";
        public static string CarGetCarsByBrandIdError = "Lütfen geçerli bir marka seçiniz.";
        public static string CarGetCarsByColorIdSuccess = "Renge göre araç bilgilerine başarılı bir şekilde erişildi.";
        public static string CarGetCarsByColorIdError = "Lütfen geçerli bir renk seçiniz.";
        //color
        public static string ColorAddSuccess = "Renk başarılı bir şekilde eklendi.";
        public static string ColorAddErrorName = "Renk ismi en az 3 karakter uzunluğunda olmalıdır.";
        public static string ColorUpdateSuccess = "Renk başarılı bir şekilde güncellendi.";
        public static string ColorUpdateError = "Geçerli bir renk seçiniz.";
        public static string ColorDeleteSuccess = "Renk başarılı bir şekilde silindi.";
        public static string ColorDeleteError = "Geçerli bir renk seçiniz.";
        public static string ColorGetAllSuccess= "Renkler başarıyla getirildi.";
        public static string ColorGetAllError= "Renkler getirilemedi, belki de hiç renk yoktur.";
        public static string ColorGetByIdSuccess= "Renk başarıyla getirildi.";
        public static string ColorGetByIdError= "Geçerli bir renk seçiniz.";
        //user
        public static string UserAddSuccess = "Kullanıcı başarılı bir şekilde eklendi.";
        public static string UserAddErrorName = "İsim uzunluğu minimum 3 harften oluşmalıdır.";
        public static string UserAddErrorPassword = "Şifre en az 4, en fazla 16 karakterden oluşmalıdır. Büyük, küçük harf, sayı, şekil içermelidir.";
        public static string UserUpdateSuccess = "Kullanıcı başarılı bir şekilde güncellendi.";
        public static string UserUpdateError = "Geçerli bir kullanıcı seçiniz.";
        public static string UserDeleteSuccess = "Kullanıcı başarılı bir şekilde silindi.";
        public static string UserDeleteError = "Geçerli bir kullanıcı seçiniz.";
        public static string UserGetAllSuccess = "Kullanıcı listesi başarılı bir şekilde getirildi.";
        public static string UserGetAllError = "Kullanıcılar getirilemedi, acaba hiç kullanıcı yok mu?";
        public static string UserGetByIdSuccess = "Kullanıcıya başarıyla erişildi.";
        public static string UserGetByIdError = "Geçerli bir kullanıcı seçiniz.";
        public static string UserCheckUserExistsError = "Kullanıcı bulunamadı gibi duruyor.";
        //customer
        public static string CustomerAddSuccess = "Müşteri başarılı bir şekilde eklendi.";
        public static string CustomerUpdateSuccess = "Müşteri başarılı bir şekilde güncellendi.";
        public static string CustomerUpdateError = "Lütfen geçerli bir müşteri bilgisi giriniz.";
        public static string CustomerDeleteSuccess = "Müşteri başarılı bir şekilde silindi.";
        public static string CustomerDeleteError = "Lütfen geçerli bir müşteri bilgisi giriniz.";
        public static string CustomerGetAllSuccess = "Müşteri listesi başarılı bir şekilde getirildi.";
        //rental
        public static string RentalAddSuccess = "Araç kiralama başarılı.";
        public static string RentalAddError = "Araç kiralama başarısız, araç kullanımda.";
        public static string RentalUpdateSuccess = "Kiralama bilgileri başarılı bir şekilde güncellendi.";
        public static string RentalUpdateError = "Lütfen geçerli bir kiralama işlemi seçiniz.";
        public static string RentalDeleteSuccess = "Kiralama bilgileri başarılı bir şekilde silindi.";
        public static string RentalDeleteError = "Lütfen geçerli bir kiralama işlemi seçiniz.";
        public static string RentalGetAllSuccess = "Kiralama listesi başarılı bir şekilde getirildi.";
        public static string RentalCheckIsCarReturnError = "Araç hala kullanımda, kiralama gerçekleştirilemez.";
        public static string RentalCheckRentalExistsError = "Geçerli bir kiralama işlemi seçtiğinizden emin olunuz.";
        //Car Image
        public static string CarImageGetAllSuccess = "Tüm resimler başarıyla listelendi.";
        public static string CarImageGetByIdSuccess = "Resim başarıyla getirildi.";
        public static string CarImageAddSuccess = "Resim başarıyla eklendi.";
        public static string CarImageExistsError = "Lütfen geçerli bir resim seçtiğinizden emin olunuz.";
        public static string CarImageUpdateSuccess = "Görsel başarılı bir şekilde güncellendi.";
        public static string CarImageDeleteSuccess = "Görsel başarılı bir şekilde silindi.";
        public static string CarImageImageLimitError = "Aracın makisumum 5 görseli bulunabilir.";


        //Validator Messages

        //for user
        public static string UserValidatorPasswordError =
            "Şifre en az 8 karakter uzunluğunda, büyük-küçük harf ve sayı içermelidir.";
        
    }
}
