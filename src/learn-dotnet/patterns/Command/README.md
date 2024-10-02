# Command

## Tr

İlk defa `Agile Software Development` kitabını okurken denk geldiğim bu patterni
incelediğimde mantığını şöyle anladım: Bir işlemin ya da işlemlerin
gerçekleşmeden önce yapılması gereken bazı işlemler olduğunda (validasyon gibi),
bu patterni kullanarak önce o işlemleri gerçekleştiriyoruz. Daha sonra esas
işlemi execute ediyoruz. Yani araya koyduğumuz bu katman ile `command`
patternini uygulamış oluyoruz.

Burada gözden kaçmaması gereken bazı noktalar var. `Alıcı` ile `Müşteri`
arasındaki bağımlılığı azaltmayı hedeflemeliyiz. Ne demek istiyorum? `Müşteri`,
`Alıcı`lardan birçoğunu kendi bünyesinde bir dizi kontrol ve raporlamadan sonra
çalıştırıyor. Bu, `Müşteri` üzerinde bir dizi yük ve karmaşıklık oluşturuyor.
Ayrıca bu `Alıcı`ların zamanla çoğalmasını da muhtemeller arasında görüyoruz. Bu
durumda `command` pattern bize göz kırpıyor :)

## Eng

When I first encountered this pattern while reading the
`Agile Software Development` book, I understood its logic as follows: When there
are certain operations that need to be performed before the main operation (such
as validation), we use this pattern to first perform those operations. Then we
execute the main operation. In other words, by inserting this layer, we
implement the `command` pattern.

There are some points here that shouldn't be overlooked. We should aim to reduce
the dependency between the `Receiver` and the `Client`. What do I mean? The
`Client` executes many of the `Receivers` within itself after a series of checks
and reporting. This creates a series of burdens and complexities on the
`Client`. We also consider it likely that these `Receivers` will increase in
number over time. In this case, the `command` pattern winks at us :)