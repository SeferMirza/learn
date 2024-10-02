# State

## Tr

Bir sınıfta kullandığımız metotlarda farklı durumlar için if/else, switch/case
kullanmak yerine bir soyut sınıftan türettiğimiz sınıfları state olarak
tutuyoruz ve farklı davranışları o nesnelerde yazıyoruz. Böylece koşullarda
kaybolmuyor ve Open/Closed prensibini de ihlal etmemiş oluyoruz.

## Eng

Instead of using if/else or switch/case for different situations in the methods
we use in a class, we keep classes derived from an abstract class as states and
write different behaviors in those objects. This way, we don't get lost in
conditions and we don't violate the Open/Closed principle.
