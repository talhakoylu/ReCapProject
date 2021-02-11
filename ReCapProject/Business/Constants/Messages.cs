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
        public static string CarDeleteSuccess = "Araç başarılı bir şekilde silindi.";
        //color
        public static string ColorAddSuccess = "Renk başarılı bir şekilde eklendi.";
        public static string ColorUpdateSuccess = "Renk başarılı bir şekilde güncellendi.";
        public static string ColorDeleteSuccess = "Renk başarılı bir şekilde silindi.";

    }
}
