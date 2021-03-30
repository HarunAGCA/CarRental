using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    static class Messages
    {
        internal static readonly string BrandAdded = "Marka Eklendi";
        internal static readonly string BrandReceived = "Marka Getirildi";
        internal static readonly string BrandsListed = "Markalar Listelendi";
        internal static readonly string BrandDeleted = "Marka Silindi";
        internal static readonly string BrandUpdated = "Marka Güncellendi";
        internal static readonly string CarNameLengthInvalid = "Araç Adı En Az 2 Karakter Olmalıdır";
        internal static readonly string DailyPriceMustBeGreaterThanZero = "Günlük Ücret Sıfırdan Büyük Olmalıdır";
        internal static readonly string CarAdded = "Araç Eklendi";
        internal static readonly string CarDeleted = "Araç Silindi";
        internal static readonly string CarsListed = "Araçlar Listelendi";
        internal static readonly string CarReceived = "Araç Getirildi";
        internal static readonly string ReceivedCarDetail = "Araç Detayları Getirildi";
        internal static readonly string ReceivedCarsDetail = "Araçların Detayları Getirildi";
        internal static readonly string CarUpdated = "Araç Güncellendi";
        internal static readonly string ColorAdded = "Renk Eklendi";
        internal static readonly string ColorDeleted = "Renk Silindi";
        internal static readonly string ColorReceived = "Renk Getirildi";
        internal static readonly string ColorsListed = "Renkler Listelendi";
        internal static readonly string ColorUpdated = "Renk Güncellendi";
        internal static readonly string RentalAdded = "Kiralama Kaydı Oluşturuldu";
        internal static readonly string CarIsNotFree = "Araç Boşta Değil";
        internal static readonly string UserAdded = "Kullanıcı Eklendi";
        internal static readonly string UserReceived = "Kullanıcı Getirildi";
        internal static readonly string UserDeleted = "Kullanıcı Silindi";
        internal static readonly string UsersReceived = "Kullanıcılar Getirildi";
        internal static readonly string UserUpdated = "Kullanıcı Güncellendi";
        internal static readonly string CustomerAdded = "Müşteri Eklendi";
        internal static readonly string CustomerReceived = "Müşteri Getirildi";
        internal static readonly string CustomerAlreadyExist = "Müşteri Zaten Mevcut";
        internal static readonly string RentalNotFound = "Kiralama Kaydı Bulunamadı";
        internal static readonly string RentalReceived = "Kiralama Kaydı Getirildi ";
        internal static readonly string RentalUpdated = "Kiralama Kaydı Güncellendi";
        internal static readonly string CarDelivered = "Araç Teslim Alındı";
        internal static readonly string CarIsFree = "Araç Kiralama İçin Uygun";
        internal static readonly string AccessTokenCreated = "Token Oluşturuldu";
        internal static readonly string UserAlreadyExists = "Kullanıcı Zaten Mevcut";
        internal static readonly string SuccessfulLogin = "Giriş Başarılı";
        internal static readonly string PasswordError = "Şifre Hatalı";
        internal static readonly string UserNotFound = "Kullanıcı Bulunamadı";
        internal static readonly string UserRegistered = "Kullanıcı Kaydedildi";
        internal static readonly string AuthorizationDenied = "Bu İşlem İçin Yetkiniz Yok";
        internal static readonly string CustomerDeleted ="Müşteri Silindi";
        internal static readonly string CustomerUpdated ="Müşteri Güncellendi";
        internal static readonly string CarNotFound = "Araç Bulunamadı";
        internal static readonly string BrandNotFound ="Marka Bulunamadı";
        internal static readonly string ColorNotFound = "Renk Bulunamadı";
        internal static readonly string CustomerNotFound = "Müşteri Bulunamadı";
        internal static readonly string CarImageAdded = "Araç Fotoğrafı Eklendi";
        internal static readonly string CarImageDeleted = "Araç Fotoğrafı Silindi";
        internal static readonly string CarImageNotFound= "Araç Fotoğrafı Bulunamadı";
        internal static readonly string CarImageUpdated = "Araç Fotoğrafı Güncellendi";
        internal static readonly string CarImageLimitExceeded = "Araç Fotoğraf Sayısı Limiti Aşıldı";
        internal static readonly string CarImageCouldNotAdded = "Araç Fotğrafı Eklenemedi";
        internal static readonly string CarImagesAdded = "Araç Fotoğrafları Eklendi";
        internal static readonly string CarImageCouldNotUpdated = "Araç Fotoğrafı Güncellenemedi";
    }
}
