using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded { get; } = "Ekleme İşlemi Başarılır";
        public static string ProductNameAlreadyExists { get; } = "Bu isimde bir ürün sistemde bulunmaktadır.";
        public static string ProductUpdated { get; } = "Güncelleme İşlemi Başarılır";
        public static string ProductNameInvalid { get; } = "Ürün İsmi Geçersiz";
        public static string MaintenanceTime { get; } = "İşlem Saatleri İçerisinde Tekrar Deneyiniz.";
        public static string ProductsListed { get; } = "Ürünler Listelendi";
        public static string ProductsListedByCategoryId { get; } = "Ürünler Kategori Id Değeriyle Listelendi";
        public static string ProductCountOfCategoryError { get; } = "Eklemeye çalıştığınız kategorideki ürünlerin sayısı 10 taneden fazla olamaz";
        public static string CategoryLimitedExceded { get; } = "Kategori sayısı belirtilen değerden fazla";
        public static string AuthorizationDenied { get; } = "İşlem için yetkiniz bulunmamaktadır !";
        public static string UserRegistered { get; } = "Kullanıcı Kayıt edildi";
        public static string UserNotFound { get; } = "Kullanıcı Bulunamadı";
        public static string PasswordError { get; } = "Hatala Password";
        public static string SuccessfulLogin { get; } = "Giriş İşlemi Başarılı";
        public static string UserAlreadyExists { get; } = "Kayıtlı Kullanıcı";
        public static string AccessTokenCreated { get; } = "Access Token Oluşturuldu";
    }
}
