# ReCapProject
Bu proje SOLID prensiblerine bağlı kalarak ama overdesing yani aşırı tasarıma kaçılmadan OOP, AOP ve IoC teknikleriyle geliştirilmiştir.
Proje katmanlı mimariye uygun olarak geliştirilmiş ve bağımlılık düzeyi en aza indirilmiştir ve altı adet katmandan oluşmaktadır bunlar;
- Bussiness
- ConsoleUI
- Core
- DataAccess
- Entities
- WebApı

# Bussiness Katmanı
Bu katmanda projemizde manager sınıfları ve bunların abstract halleri, doğrulama kuralları, proje sabitleri, kısmi bağımlılıklar (dependency resolvers) ve metodlara erişim
yönetim ve düzenleme için role atama yapılmıştır. Dosyalama dizini ve kullanılan nuget package lar aşağıdaki gibidir.
- Bussiness
  - Abstract
  - BussinessAspect
  - Concrete
  - Constans
  - DependencyResolvers
  - ValidationRules
  
### Nuget Package
- "Autofac" Version="6.1.0" 
- "Autofac.Extensions.DependencyInjection" Version="7.1.0"
- "Autofac.Extras.DynamicProxy" Version="6.0.0"
- "FluentValidation" Version="9.5.1"
- "Microsoft.AspNetCore.Http" Version="2.2.2"
- "Microsoft.AspNetCore.Http.Abstractions" Version="2.2.0"

# ConsoleUI
Bu katman tamamen test amaçlı WebApı kısmından önce yazdığımız metodların çalışıp çalışmadığını kontrol amaçlı oluşturulmuş olup her hangi bir bağlayıcılığı bulunmamaktadır.

# Core
Bu katman projenin çatısını oluşturmaktadır bütün katmanlar core katmanına bağlıdır lakin core katmanı diğer hiç bir katmana bağlı değildir. Core katmanında projede kullandığımız
Aspect, CrossCuttingConcers gibi yapıların çatıları oluşturulup gereklş olan katmanlara referans verilerek kullanımılmıştır. 
Dosya dizini ve kullanılan nuget package ler aşağıdaki gibidir.

- Core
  - Aspects
  - CrossCuttingConcers
  - DataAccess
  - DependencyResolvers
  - Entities
  - Extensions
  - Utilities
  
### Nuget Package
- "Autofac" Version="6.1.0"
- "Autofac.Extensions.DependencyInjection" Version="7.1.0"
- "Autofac.Extras.DynamicProxy" Version="6.0.0"
- "FluentValidation" Version="9.5.1"
- "Microsoft.AspNetCore.Http" Version="2.2.2"
- "Microsoft.AspNetCore.Http.Abstractions" Version="2.2.0"
- "Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.11"
- "Microsoft.IdentityModel.Tokens" Version="6.8.0"
- "Newtonsoft.Json" Version="10.0.1"
- "System.IdentityModel.Tokens.Jwt" Version="6.8.0"

# DataAccess
Bu katmanda veri tabanına bağlantı veri ekleme, silme, güncelleme, verileri çekme, birden fazla tabloyu birleştirme (DTO) gibi işlemler yapılmıştır.
Sorgular için Microsoftun EntityFramework kütüphanesinden yararlanılmıştır.
Dosya dizini ve nuget package ler aşağıdaki gibidir.

- DataAccess
  - Abstract
  - Concrete
  
### Nuget Package
- "Microsoft.EntityFrameworkCore.SqlServer"

# Entities
Bu katmanda veri tabanında oluşturmuş olduğumuz tabloları entitiy olarak tanımlıyoruz.
DTO yapmak istediğimiz tabloların özelliklerini dto klasörü içine ekleyip Data Access katmanında bunların sorgularını yazdık.
Dosya Dizini Aşağıdaki Gibidir.

- Entities
  - Concrete
  - DTOs

# WebApı
Bu katman projedeki tüm operasyonları iş kuralları, doğrulama kuralları ve güvenlik kurallarına uygun olarak test ettiğimiz web servisimizdir.
Projede FrontEnd kısmına geçiş yaptığımızda BackEnd ile anlaşmamızı sağlayan kısım burasıdır. Bu katmanda tarayıcalar üzerinden sorgu yapmamızı ve projemizi test etmek için
her bir entity için controller ve bu controller içinde requestler yazdık. Dosyalama dizini ve nuget package ler aşağıdaki gibidir.

- WebApı
  - Properties
  - wwwroot
  - Controllers
  - appsettings.json
  - startup.cs
  
 ### Nuget Package
 
- "Autofac.Extensions.DependencyInjection" Version="7.1.0"
- "Microsoft.AspNetCore.Authentication.JwtBearer" Version="3.1.12"


















  
  
  
