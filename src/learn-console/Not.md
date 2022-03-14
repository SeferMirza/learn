## Kodlar

**MemberwiseClone()**


Object sınıfına ait bir metoddur.
Protected erişim belirleyicisine sahiptir bu yüzden türetme işlemi söz konusu olduğunuda kullanılabilir.
Ayrıca override edilebilir bir metod da değildir. 
MemberwiseClone metodu, kullanıldığı sınıfın nesne örneğinden bir kopya daha oluşturmaktır.

*Örnek kullanım*

    public ISettings Clone()
    {
         return MemberwiseClone() as ISettings;
    }
