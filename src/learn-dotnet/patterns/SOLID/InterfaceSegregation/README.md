# Interface Segregation

## TR

Bu prensibi incelediğimde, bizden beklenenin arayüzlerin (interface'lerin)
bağlamının basit tutulması yönünde olduğunu görüyorum. Amaç, sınıflarda tek
sorumluluk prensibi (Single Responsibility Principle) ile uygulamaya
çalıştığımız şeyi arayüzlerde de uygulamak. Bu sayede, arayüzü sınıflara
uyguladığımızda, sınıfta kullanılmayacak olan ya da aslında sınıfın bağlamı
dışında kalan fazladan metotların veya özelliklerin (property'lerin) gelmesini
önlemek oluyor.

## Eng

When I examined this principle, I realized that what is expected of us is to
keep the context of interfaces simple. The goal is to apply the same principle
we strive to implement in classes with the Single Responsibility Principle to
interfaces as well. This way, when we apply the interface to classes, we prevent
unnecessary methods or properties that won't be used in the class or that are
beyond the class's context from being included.
