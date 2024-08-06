# Liskov Substitution

## TR

Bu prensibi incelediğimde anladığım şey: Bir sınıf başka bir sınıftan/arayüzden
türediğinde, üst sınıfın/arayüzün bütün özellikleri kendisini temsil
edebilmelidir. Neden diye kendime hiç sormadım aslında, çünkü aklımda bir an da
bunun aksi halde doğurabileceği sorunları hemen canlandırdım. Örneğin, bir oyun
geliştirdiğimizi ve sahnede kullanılan birçok nesnenin çizilmeden önce
konfigürasyonlarını yaptığınız bir ana sınıfı olduğunu düşünelim. Siz bu sınıfta
haliyle oyun içi nesnelerin/sınıfların adlarıyla tek tek bunları almazsınız. Bir
üst arayüz olur, siz bu oyun içi nesneleri o arayüzden türetildiği için bu ana
sınıfa verirsiniz. Ancak, düşünsenize bir oyun içi nesnenin sırf o arayüzdeki
birkaç özelliği işe yaradığı için kullandığınızı ama o arayüz tarafından tam
temsil edilmediğini ve sonra konfigürasyon tarafında patladığını. Devamında ne
yapacaksınız? If bloğu ile "O sınıftansa bunu yap" mı diyeceksiniz? İyi
olmazdı bence :)

## Eng

When I examined this principle, what I understood is: When a class inherits from
another class/interface, all the features of the superclass/interface should be
able to represent it. I never asked myself why, actually, because I immediately
visualized in my mind the problems that could arise otherwise. For example, in a
scene where you are developing a game, there is a main class where you
configured many objects before they are drawn. In this class, naturally, you
wouldn't take the names of the in-game objects/classes one by one. There would
be a parent interface, and you would give these in-game objects to this main
class because they are derived from that interface. However, imagine using an
in-game object just because a few features from that interface are useful, but
it is not fully represented by that interface and then it fails on the
configuration side. What will you do next? Will you say "Do this if it's that
class" with an if block? I don't think that would be good :)
