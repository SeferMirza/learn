# Soru Deposu

Sorular dosyadan gelebilir olsun.

## Özellikler

- Kaynaktaki sorulardan birini rastgele sormalı.
- Dosya formatında her satır bir soru olacak şekilde kabul edelim.

  Örnek;
  ```
  i am ironman
  who is batman
  ```
- Sorular yüklendiğinde oyuna uygun hale otomatik olarak gelmeli;
  - küçük harf, büyük harf fark etmemeli
  - boş satırlar yok sayılmalı
  - kelimeler arasında birden fazla boşluk varsa tolere edilmeli
  - noktalama işaretleri yoksayılmalı

  Örnek: `Who  is batman!!!` -> `WHO IS BATMAN`
