# Dependency Inversion

## TR

Bu prensibi araştırdığımda, karşıma şu tanım çıktı:
**Yüksek Seviye Modüller, Düşük Seviye Modüllere Bağımlı Olmamalıdır.**
Tanımın anlatmak istediğine baktığımda, bir sınıfın metodunun veya
özelliklerinin (alt seviye) başka bir sınıf (üst seviye) tarafından kullanılması
durumunda, üst seviyedeki sınıfın alt seviyedeki sınıfın özellik veya metoduna
erişmek için ne kadar az bağımlı olması gerektiğini anlıyorum. Gerçek hayat
örneğini düşündüğümde, bir sınıfın bir metodunu birçok yerde kullandığımızı
varsayalım ve bu metodu kullanmak için bu sınıftan yeni bir nesne yaratıp
duruyoruz. Eğer bu sınıf artık yapıcı metodundan bir parametre almaya karar
verirse, her yerde gidip bu parametreyi ona vermemiz gerekecek. Eğer bu
parametre başka bir sınıfa aitse ne olacak? Çık işin içinden çıkabilirsen :)

## Eng

When I researched this principle, I came across the following definition:
**High-Level Modules Should Not Depend on Low-Level Modules.** Looking at what
this definition is trying to convey, it explains how a class's method or
properties (low-level) should be as little dependent as possible when used by
another class (high-level). Considering a real-life example, let's assume we are
using a method from a class in many places and constantly creating a new
instance of this class to use the method. If this class later decides to require
a parameter in its constructor, we will need to provide this parameter
everywhere. What if this parameter belongs to another class? Good luck trying to
sort that out! :)
