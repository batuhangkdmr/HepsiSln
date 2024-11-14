
# HepsiSln - Ürün Yönetim API Projesi

Bu proje, ürünler, markalar ve kategoriler için CRUD işlemleri sağlayan bir RESTful API mimarisi sunmaktadır. 
.NET Core ile geliştirilmiş ve Clean Architecture (Temiz Mimari) prensiplerine uygun olarak yapılandırılmıştır.

## Özellikler

- Ürün, marka ve kategori bazında CRUD (Oluşturma, Okuma, Güncelleme, Silme) işlemleri
- Çok katmanlı mimari (Application, Domain, Infrastructure, Presentation)
- Entity Framework Core ile veri yönetimi
- Unit of Work ve Repository Pattern entegrasyonu
- Swagger ile API dökümantasyonu

## Kurulum ve Çalıştırma

1. Projeyi bilgisayarınıza klonlayın:
   ```bash
   git clone https://github.com/batuhangkdmr/HepsiSln
   ```

2. Proje dizinine gidin ve bağımlılıkları yükleyin.

3. `appsettings.json` dosyasındaki veri tabanı bağlantı ayarlarını kendi ortamınıza göre yapılandırın.

4. Migrationları oluşturun ve veri tabanını güncelleyin:
   ```bash
   dotnet ef database update --project Infrastructure/Persistence
   ```

5. API uygulamasını çalıştırın:
   ```bash
   dotnet run --project Presentation/HepsiAPI.Api
   ```

## API Özellikleri

- `/api/products` - Ürünler için CRUD işlemleri
- `/api/brands` - Markalar için CRUD işlemleri
- `/api/categories` - Kategoriler için CRUD işlemleri

Swagger dokümantasyonuna göz atarak tüm endpoint'leri ve detaylarını inceleyebilirsiniz.

## Proje Katmanları

- **Core/Domain**: Temel domain sınıfları ve soyutlamalar
- **Core/Application**: İş mantığı ve servislerin tanımlandığı katman
- **Infrastructure/Persistence**: Veri tabanı işlemleri ve Entity Framework ayarları
- **Presentation/HepsiAPI.Api**: API katmanı, controller sınıflarını içerir

## Katkıda Bulunanlar

Bu proje açık kaynak olarak geliştirilmektedir ve katkılara açıktır.

## Lisans

Bu proje MIT lisansı ile lisanslanmıştır. Detaylı bilgi için [LİSANS](LICENSE) dosyasına göz atabilirsiniz.
