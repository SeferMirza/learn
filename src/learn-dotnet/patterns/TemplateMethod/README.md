# Template Method

## TR

Bu prensibi incelediğimde karşıma "yazılım tasarımında bir algoritmanın
iskeletini tanımlayan, ancak adımlarının bazılarını alt sınıflara bırakmayı
sağlayan bir davranışsal tasarım desenidir" tanımı çıkıyor. Bu tanımdan ve
örneklerden anladığım kadarıyla, birden fazla yerde aynı süreç ve adımlar takip
ediliyorsa, bu süreç üst sınıfta metotlara bölünür ve sırayla çağrılır. Metotlar
alt sınıflarda özelleştirilir. Bu sayede, farklı durumlarda aynı sürecin takip
edildiğinden emin oluruz.

## Eng

When I examine this principle, I come across the definition "a behavioral design
pattern that defines the skeleton of an algorithm, but allows some of its steps
to be implemented by subclasses." From this definition and examples, what I
understand is that if the same process and steps are followed in several places,
this process is divided into methods in a superclass and called sequentially.
The methods are customized in the subclasses. This ensures that the same process
is followed in different situations.
