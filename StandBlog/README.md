# StandBlog

Modern bir ASP.NET Core MVC blog uygulaması. Kullanıcıların blog yazıları oluşturabileceği, kategorilere ayırabileceği ve etiketleyebileceği tam özellikli bir blog platformu.

## 🚀 Özellikler

### Genel Özellikler
- **Modern Blog Sistemi**: Kullanıcı dostu arayüz ile blog yazıları
- **Kategori Yönetimi**: Blog yazılarını kategorilere ayırma
- **Etiket Sistemi**: Blog yazılarını etiketlerle organize etme
- **Yorum Sistemi**: Okuyucuların blog yazılarına yorum yapabilmesi
- **İletişim Formu**: Ziyaretçilerin site sahibiyle iletişim kurabilmesi
- **Responsive Tasarım**: Mobil ve masaüstü uyumlu modern arayüz

### Yönetim Paneli (Dashboard)
- **Admin Paneli**: Blog içeriklerini yönetme
- **Blog Yönetimi**: Blog yazıları oluşturma, düzenleme, silme
- **Kategori Yönetimi**: Kategorileri yönetme
- **Etiket Yönetimi**: Etiketleri yönetme
- **Yorum Yönetimi**: Yorumları moderasyon
- **İletişim Mesajları**: Gelen iletişim mesajlarını görüntüleme
- **Kullanıcı Yönetimi**: Kullanıcı kayıt ve giriş işlemleri

## 🛠️ Teknolojiler

- **.NET 9.0**: En güncel .NET framework
- **ASP.NET Core MVC**: Web uygulaması framework'ü
- **Entity Framework Core**: ORM (Object-Relational Mapping)
- **SQL Server**: Veritabanı
- **ASP.NET Core Identity**: Kullanıcı kimlik doğrulama ve yetkilendirme
- **FluentValidation**: Model doğrulama
- **Bootstrap**: Frontend CSS framework'ü
- **jQuery**: JavaScript kütüphanesi

## 📁 Proje Yapısı

```
StandBlog/
├── Areas/
│   └── Dashboard/                 # Admin paneli
│       ├── Controllers/          # Dashboard controller'ları
│       ├── Models/              # View model'ları
│       ├── Validators/          # View model validatörleri
│       └── Views/               # Dashboard view'ları
├── Controllers/                  # Ana sayfa controller'ları
├── Data/
│   └── ApplicationDbContext.cs  # Entity Framework DbContext
├── Models/
│   ├── Entities/                # Veritabanı entity'leri
│   ├── Mappings/                # Entity konfigürasyonları
│   └── Validators/              # Entity validatörleri
├── Migrations/                   # Entity Framework migration'ları
├── ViewComponents/              # Yeniden kullanılabilir view component'ları
├── Views/                       # Ana sayfa view'ları
└── wwwroot/                     # Statik dosyalar (CSS, JS, resimler)
```

## 🗄️ Veritabanı Yapısı

### Ana Entity'ler
- **Blog**: Blog yazıları
- **Category**: Kategoriler
- **Tag**: Etiketler
- **Comment**: Yorumlar
- **Contact**: İletişim mesajları
- **ApplicationUser**: Kullanıcılar (ASP.NET Identity)

### İlişkiler
- Blog → Category (Many-to-One)
- Blog → Comments (One-to-Many)
- Blog → BlogTags (One-to-Many)
- BlogTag → Tag (Many-to-One)

## 🚀 Kurulum

### Gereksinimler
- .NET 9.0 SDK
- SQL Server (LocalDB veya SQL Server)
- Visual Studio 2022 veya VS Code

### Adımlar

1. **Projeyi klonlayın**
   ```bash
   git clone [repository-url]
   cd StandBlog
   ```

2. **Veritabanı bağlantı string'ini yapılandırın**
   `appsettings.json` dosyasında `DefaultConnection` string'ini güncelleyin:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StandBlogDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Migration'ları çalıştırın**
   ```bash
   dotnet ef database update
   ```

4. **Uygulamayı çalıştırın**
   ```bash
   dotnet run
   ```

5. **Tarayıcıda açın**
   ```
   https://localhost:5001
   ```

## 👤 Varsayılan Kullanıcılar

Sistem kurulumunda otomatik olarak oluşturulan roller:
- **Admin**: Tam yetki
- **User**: Sınırlı yetki

## 📝 Kullanım

### Genel Kullanıcılar
- Ana sayfada blog yazılarını görüntüleyebilir
- Kategori ve etiket bazında filtreleme yapabilir
- Blog yazılarına yorum yapabilir
- İletişim formu ile mesaj gönderebilir

### Admin Kullanıcılar
- `/Dashboard` adresinden yönetim paneline erişebilir
- Blog yazıları, kategoriler, etiketler yönetebilir
- Yorumları moderasyon edebilir
- İletişim mesajlarını görüntüleyebilir

## 🎨 Özelleştirme

### Tema Değiştirme
- `wwwroot/assets/css/` klasöründeki CSS dosyalarını düzenleyin
- `Views/Shared/_Layout.cshtml` dosyasından ana layout'u özelleştirin

### Yeni Özellik Ekleme
- Yeni entity'ler için `Models/Entities/` klasörüne ekleyin
- Controller'ları `Controllers/` veya `Areas/Dashboard/Controllers/` klasörüne ekleyin
- View'ları ilgili klasörlere ekleyin

## 🔧 Geliştirme

### Migration Oluşturma
```bash
dotnet ef migrations add MigrationName
```

### Veritabanını Güncelleme
```bash
dotnet ef database update
```

### Validator Ekleme
FluentValidation kullanarak yeni validatörler ekleyebilirsiniz:
```csharp
public class MyModelValidator : AbstractValidator<MyModel>
{
    public MyModelValidator()
    {
        RuleFor(x => x.Property).NotEmpty();
    }
}
```

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır.

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Commit yapın (`git commit -m 'Add some AmazingFeature'`)
4. Push yapın (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📞 İletişim

Proje hakkında sorularınız için iletişim formunu kullanabilir veya issue oluşturabilirsiniz.

---

**StandBlog** - Modern, kullanıcı dostu blog platformu 🚀