namespace SuperMarket.Business.Constants
{
    public static class Messages
    {

        #region AuthMessages

        public static string UserNameOrPaswordError = "Kullanıcı Adı veya Parola Hatalı";
        public static string UserNotFound = "Böyle bir kullanıcı Bulunamadı";
        public static string UserPasswordError = "Kullanıcı Parolası Hatalı";
        public static string LoginActionSuccess = "Giriş İşlemi Başarılı";

        #endregion

        #region BasketMessages

        public static string SuccessAddedToBasket = "Ürün Başarı İle Sepete Eklendi";
        public static string ErrorMessageForNullStock = "Stok Adedi 0 olduğu için eklenemedi";
        public static string RemoveProductFromBasket = "Ürün Sepetten Başarı İle Silinmiştir";
        public static string SuccessOrderCreated = "Siparişiniz Alınmıştır.Teşekkürler...";

        #endregion BasketMessages

        #region ProductMessages

        public static string SuccessProductAdded = "Ürün Başarı İle Kaydedildi";
        public static string SuccessProductRemoved = "Ürün Başarı İle Silindi";
        public static string ProductNameAlreadyExists = "Bu ürün Adından Daha Önce Mevcut";
        public static string ProductIdExistsForAdd = "Id'si Olan Ürün Eklenemez";
        public static string OnBasketDetailProductExists="Sepette bulunan veya daha öncesinde siparişi olan ürün Silinemez!!!";

        #endregion



    }
}