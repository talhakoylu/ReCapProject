using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //brand
        public static string BrandGetAllSuccess = "Markalar başarılı bir şekilde getirildi.";
        public static string BrandAddError = "Marka isim uzunluğu 2 karakterdan fazla olmalıdır.";
        public static string BrandAddSuccess = "Marka başarılı bir şekilde eklendi.";
        public static string BrandDeleteSuccess = "Marka başarılı bir şekilde silindi.";
        public static string BrandUpdateSuccess = "Marka başarılı bir şekilde güncellendi.";
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
        public static string ColorUpdateSuccess = "Renk başarılı bir şekilde güncellendi.";
        public static string ColorDeleteSuccess = "Renk başarılı bir şekilde silindi.";
        //user
        public static string UserAddSuccess = "Kullanıcı başarılı bir şekilde eklendi.";
        public static string UserUpdateSuccess = "Kullanıcı başarılı bir şekilde güncellendi.";
        public static string UserDeleteSuccess = "Kullanıcı başarılı bir şekilde silindi.";
        public static string UserGetAllSuccess = "Kullanıcı listesi başarılı bir şekilde getirildi.";
        //customer
        public static string CustomerAddSuccess = "Müşteri başarılı bir şekilde eklendi.";
        public static string CustomerUpdateSuccess = "Müşteri başarılı bir şekilde güncellendi.";
        public static string CustomerDeleteSuccess = "Müşteri başarılı bir şekilde silindi.";
        public static string CustomerGetAllSuccess = "Müşteri listesi başarılı bir şekilde getirildi.";
        //customer
        public static string RentalAddSuccess = "Araç kiralama başarılı.";
        public static string RentalAddError = "Araç kiralama başarısız, araç kullanımda.";
        public static string RentalUpdateSuccess = "Kiralama bilgileri başarılı bir şekilde güncellendi.";
        public static string RentalDeleteSuccess = "Kiralama bilgileri başarılı bir şekilde silindi.";
        public static string RentalGetAllSuccess = "Kiralama listesi başarılı bir şekilde getirildi.";
    }
}
