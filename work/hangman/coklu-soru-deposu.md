# Çoklu Soru Deposu

Sorular birden fazla kaynaktan gelebilir olsun.

## Özellikler

- Kaynak 1: Mevcut kaynak olan dosyadan yükleme
- Kaynak 2: Yeni kaynak olan web'den yükleme
  `hangman --file english.json --source web --web-url http://hangman.github.io/sources`
  Bu durumda;
  `hangman --file english.json`
  dendiğinde bu aşağıdakinin kısa hali olmuş olur;
  `hangman --file english.json --source local --local-folder ./`
- `--web-url` degeri zorunlu olmasın, varsayılan bir değeri olsun
- Kaynaklardan veri yüklenirken, hata olursa varsayılan kaynağa dönmeli
- Kullanıcı ana menü/ayarlar üzerinden kaynağı ve kaynak ayarlarını
  değiştirebilmeli
 - ayarlar/kaynak değiştir dendiğinde web mi, local mi diye sormalı, sonra da
   web'se url, local'se folder sormalı, ve kaydetmeli
