# Single Responsibility

## TR

Nedir bu single responsibility diye düşünmeye başladım. Önce anlamak için
internet araştırması yaptığımda "Bir sınıfın veya fonksiyonun sorumluluğunu
azalt" cümlesinin tekrar ettiğini görüyorum. Ancak çoğu makalede basit örneklere
örneklendirilip bırakılıyor. Okununca fikir tam anlaşılmıyor, sadece
ezberleniyor. Hal böyle olunca gerçek hayatta kod yazarken insanın(en azından
benim) aklına gelmiyor. Gelse dahi fikri tam anlamayınca ne yapacağını
bilemiyor.

Okuduğum makalelerde bazı sorularım cevapsız kalıyordu. Aşağıya önce o soruları
yazıp daha sonra onların cevaplarını arayacağım. Tabi burasının bitmiş hali
okunduğunda soruları cevaplarıyla görünür olacak ancak benim için süreç adım
adım gidiyor olacak.

**Soru:** Nedir single responsibility?
**Cevap:** Bir sınıfın veya metotun yalnızca bir sorumluluğu olması gerektiğini
sınıfın veya metotun tek bir işi yapması, kodun anlaşılır ve bakımı kolay
olmasını sağlar.

**Soru:** God class yada god method'u savunmuyorum ama neden bir class yada
methodun tek sorumluluğu olmak zorunda?
**Cevap:** İyi isimlendirilmiş class/yada methodlarda aradığını bulmak kolay
oluyor. Eğer bir class/method iyi isimlendirilmezse ve içerisinde ekstra bir
işlem gizlenmişse aradığımızı bulmak çok zor olacaktır.

**Soru:** Peki iyi isimlendirme yapılırsa?
**Cevap:** İyi isimlendirme yapılırsa bence aradığını bulmak zor olmayacaktır.
Örneğin basit bir mail ve sms bilgilendirmesi yapılacak. Ne zaman bir
bilgilendirme yapılacak olsa sms ve mail beraber yapılıyor. İçeriye fazla logic
koyulmamış. Developer Bilgilendirme classı adı altında tek method ile
bilgilendirme işlemini yapıyor. Bakıldığında basit bir işlem, sayfayı bile
doldurmayan kod, aradığında bulması kolay olacak.

**Soru:** O zaman olay kodun ne kadar karmaşıklaştığı mı?
**Cevap:** Galiba bir noktada evet. Amaç kodu daha az karmaşık tutmakta. Ancak
şöyle bir durum var eğer kod basit diyip bırakıyorsak ve ileride koda bir şeyler
eklemeye devam edersek gittikçe kodu refactor etmek zorlaşacaktır. Önden önlem
almak daha yararlı gibi gözüküyor.

**Soru:** Test tarafında ne gibi avantaj sağlıyor?
**Cevap:** Az önceki senaryoyu düşündüğümüzde ayrı test etmek zorlaşacaktır.
Yani testi bilgilendirme olarak yapmak gerekecektir. Mail'i ayrı bir senaryo ile
test etmek zor olur çünkü sms çalışmadığında mail testide çalışmayacaktır. Mock
gibi kütüphaneler ile bir şekilde ayrı testler yapılsada extra efor gösterilmesi
bu süreci karmaşıklaştırdığını göstermekte.

**Soru:** Sonuç?
**Cevap:** Basit projelerde dahi var olan dosya sayısını arttıracak olsa bile
single responsibility presibine bağlı kalmak mantıklı olacaktır. Çünkü kodun
anlaşılabilirliğini sağladığımızı idda edip single responsibility'den
kaçındığımız noktada kodun test edilebilirliğini düşürüyoruz. Kodun test
edilebilirliğini sağladığımızı idda ettiğimiz noktada kodun sürdürülebilirliğini
kaybediyoruz. Ayrıca kodlama yaparken oluşturduğumuz modeller genelde gerçek
hayattan soyut şeyler olduğu için gerçek hayatta olduğu gibi her eşyanın kendini
görevini yerine getirdiği düşünüldüğünde kodtada böyle davranması gerekiyor.

## Eng

I started to think about what single responsibility means. When I researched it
on the internet, I often saw the phrase "Reduce the responsibility of a class or
function" repeated. However, in many articles, it is illustrated with simple
examples and left at that. When read, the idea is not fully understood; it is
just memorized. As a result, when writing code in real life, at least in my
case, it doesn’t come to mind. Even if it does, without fully understanding the
concept, I don't know what to do.

In the articles I read, some of my questions remained unanswered. Below, I will
first write down those questions and then look for their answers. Of course,
when this is read as a finished product, the questions and their answers will be
visible, but for me, the process will go step by step.

**Question:** What is single responsibility?
**Answer:** A class or method should have only one responsibility. It means that
a class or method should do only one thing, making the code understandable and
easy to maintain.

**Question:** I'm not defending the god class or god method, but why must a
class or method have only one responsibility?
**Answer:** In well-named classes or methods, finding what you are looking for
is easy. If a class/method is not well-named and an extra operation is hidden
inside, finding what you are looking for will be very difficult.

**Question:** What if good naming is done?
**Answer:** If good naming is done, I think finding what you are looking for
will not be difficult. For example, a simple mail and SMS notification is to be
made. Whenever a notification is to be made, SMS and mail are done together. No
extra logic is put inside. The developer performs the notification process with
a single method under the Notification class. It looks like a simple operation,
code that doesn't even fill a page, and it will be easy to find when searched
for.

**Question:** Then is it a matter of how complex the code is?
**Answer:** I guess at some point, yes. The goal is to keep the code less
complex. However, there is a situation like this: if we leave the code as simple
and continue to add something to the code in the future, it will become
increasingly difficult to refactor the code. It seems more beneficial to take
precautions in advance.

**Question:** What advantages does it provide on the testing side?
**Answer:** Considering the scenario mentioned earlier, it will be difficult to
test separately. That is, it will be necessary to test as a notification. It
would be difficult to test the mail with a separate scenario because if the SMS
fails, the mail test will also fail. Although separate tests can be done with
libraries like Mock, the extra effort shown indicates that this process is
becoming complicated.

**Question:** Conclusion?
**Answer:** Even if it increases the number of existing files in simple
projects, it makes sense to adhere to the single responsibility principle.
Because when we claim to ensure the understandability of the code and avoid
single responsibility, we reduce the testability of the code. When we claim to
ensure the testability of the code, we lose the sustainability of the code.
Moreover, since the models we create while coding are usually abstract things
from real life, just as every object performs its task in real life, it should
behave the same way in code.
