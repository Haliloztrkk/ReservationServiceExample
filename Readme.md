# Reservation Servie Example

## Proje Tanımı

Bu proje, Domain Driven Design (DDD) prensiplerine dayalı olarak geliştirilmiş bir C# .NET 7 uygulamasını içermektedir. Proje, restoran sektörüne özel bir rezervasyon yönetim sistemi geliştirmeyi hedeflemektedir. Temel amacımız, müşterilere kolay ve etkili bir şekilde rezervasyon yapma imkanı sunarak, restoranın rezervasyon süreçlerini daha verimli hale getirmektir. Bu sistem, clean code ve SOLID prensiplerine uygun bir kod yapısıyla geliştirilecek olup, yazılımın sürdürülebilirliği ve bakımı gözetilecektir.

## Teknolojiler

* [ASP.NET Core 7](https://learn.microsoft.com/tr-tr/aspnet/core/release-notes/aspnetcore-7.0?view=aspnetcore-7.0)
* [Entity Framework Core 7](https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-7.0/whatsnew)
* [Microsoft DI](https://learn.microsoft.com/tr-tr/dotnet/core/extensions/dependency-injection)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/)
* [Moq](https://github.com/moq)
* [FluentAssertions](https://fluentassertions.com/)
* [EntityFramework InMemoryDatabase](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli#supported-database-engines)

## Proje Yapısı

Proje, temel olarak şu ana bileşenleri içermektedir:

- **Domain:** İş domain'ini temsil eden varlıklar, değer nesneleri, servisler ve diğer domain katmanı bileşenleri burada bulunur.
- **Infrastructure:** Alt yapı ve dışa bağımlılıkları yöneten katmandır. Veritabanı bağlantısı, dış servis çağrıları ve diğer alt yapı işlemleri burada gerçekleştirilir.
- **Application:** Uygulama katmanı, domain mantığını kullanarak iş süreçlerini yönetir ve sunar.
- **Presentation:** Gerekirse, kullanıcı arayüzü ve sunum katmanı burada bulunur. Bu projede bu katman **Api** katmanıdır.

## Nasıl Çalıştırılır

1. **Gereksinimler:**
   - [.NET 7 SDK](https://dotnet.microsoft.com/download)

2. **Uygulamayı Çalıştırma:**
   - Terminal veya komut istemcisinde proje dizininde bulunun.
   - `dotnet run` komutunu kullanarak uygulamayı başlatın.
