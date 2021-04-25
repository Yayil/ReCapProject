using Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç eklendi";
        public static string CarAddFailed = "Ekleme yapılırken bir hata meydana geldi.";
        public static string CarUpdated = "Araç Güncellendi";
        public static string CarUpdateFailed = "Araç Günceleme Başarısız";
        public static string CarListed = "Arabalar listelendi";

        public static string RentalAdded = "Araba kiralama başarılı";
        public static string RentalAddFailed = "Araba kiralama başarısız. Araba henüz teslim edilmedi.";
        public static string RentalListed = "Uygun araçlar listelendi";
        public static string RentalDeleted = "Araba kiralama silindi.";

        public static string UserAdded = "Kullanıcı ekleme başarılı";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserListed = "Kullanıcı listelendi.";


        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerListed = "Müşteriler listelendi.";



        public static string MaintenanceTime = "Bakım saati";

        public static string AuthorizationDenied = "Yetkilendirme hatası";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string ErrorGetByUserMail { get; internal set; }
        public static string SuccessGetByUserMail { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }
    }
}
