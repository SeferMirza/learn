# Observer

## Tr

`Observer Design Pattern`, bir nesnenin (Subject) durumundaki değişiklikleri,
ona bağımlı diğer nesnelere (Observers) otomatik olarak bildirmesini sağlar.
Subject, Observers'ların bir listesini tutar ve durumu değiştiğinde tüm kayıtlı
Observers'ları bilgilendirir. Observers, genellikle ortak bir arayüzü uygular ve
Subject'e dinamik olarak eklenip çıkarılabilir.

## Eng

`The Observer Design Pattern` allows an object (Subject) to automatically notify
other objects (Observers) that depend on it about changes in its state. The
Subject maintains a list of Observers and notifies all registered Observers when
its state changes. Observers typically implement a common interface and can be
dynamically added to or removed from the Subject.
