# Open Closed

## TR

Nedir bu open closed principle diye bakarken ilk gördüğüm tanımlama
"Software entities (classes, modules, functions, etc.) should be open for
extension, but closed for modification." bu oluyor. Eh extension'a açık olması
normal zaten de, modification'a kapalı olmasını biraz sorgularım.
Kapalıdan kasıt nedir? Ne kadar kapalı? Her class için mi bunu düşüneceğiz? Gibi
sorular hemen aklıma geliyor. Önce bu sorulara cevap bularak başlıyorum.

**Soru:** Kapalıdan kasıt nedir?
**Cevap:** Mevcut kodu değiştirme demek.

**Soru:** Ne kadar kapalı?
**Cevap:** Baktığımda net bir şey söylenmemiş. Eğer mevcut kodu değiştiriyorsan
bu prensibe ters düşüyorsun deniyor. Burada şu aklıma geliyor. Gömülü sitemler
aklıma geliyor. Bir kere yaz cihaz bozulana kadar devam etsin. Güzel bir hedef.
Yazarken öyle yazmalıyımki mükemmel çalışsın bir daha değiştirmeme gerek
kalmasın.

## Eng

What is this open closed principle, the first definition I see is "Software
entities (classes, modules, functions, etc.) should be open for extension, but
closed for modification." Well, it is normal for it to be open for extension,
but I question it a bit for it to be closed for modification.
What do you mean closed? How closed? Do we think this for every class? Questions
like this immediately come to my mind. I start by finding answers to these
questions first.

**Question:** What do you mean by closed?
**Answer:** It means changing the current code.

**Question:** How closed?
**Answer:** When I looked, nothing clear was said. It says that if you change
the existing code you are going against this principle. Here's what comes to
mind. I think of embedded systems. Write once and keep going until the device
breaks. That's a nice goal. I should write it in such a way that it works
perfectly and I don't need to change it again.
