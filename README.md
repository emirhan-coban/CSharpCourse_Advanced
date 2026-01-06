# 🚀 C# Advanced Course - Eğitim Kampı 301

N-Tier Architecture (Katmanlı Mimari) kullanarak Entity Framework ile modern C# uygulaması geliştirme projesi.

## 📋 İçindekiler

- [Proje Hakkında](#-proje-hakkında)
- [Özellikler](#-özellikler)
- [Teknolojiler](#-teknolojiler)
- [Kurulum](#-kurulum)
- [Proje Mimarisi](#-proje-mimarisi)
- [Katmanlar](#-katmanlar)
- [Kullanım](#-kullanım)
- [Katkıda Bulunma](#-katkıda-bulunma)

## 🎯 Proje Hakkında

Bu proje, N-Tier (Katmanlı) mimari yapısını ve Entity Framework Core kullanımını öğretmek amacıyla geliştirilmiştir. Proje, gerçek dünya uygulamalarında kullanılan best practice'leri ve temiz kod prensiplerini içerir.

## ✨ Özellikler

- ✅ N-Tier Architecture (Katmanlı Mimari)
- ✅ Entity Framework Core
- ✅ Code First yaklaşımı
- ✅ Repository Pattern
- ✅ Generic Repository
- ✅ Dependency Injection
- ✅ Business Logic Layer
- ✅ Data Access Layer
- ✅ Windows Forms UI

## 🛠 Teknolojiler

| Teknoloji | Açıklama |
|-----------|----------|
| **C# .NET** | Ana programlama dili |
| **Entity Framework Core** | ORM framework |
| **SQL Server** | Veritabanı |
| **Windows Forms** | UI katmanı |

## 📦 Kurulum

### Gereksinimler

- Visual Studio 2022
- .NET 6.0 veya üzeri
- SQL Server

### Adımlar

1. Projeyi klonlayın:
```bash
git clone https://github.com/emirhan-coban/CSharpCourse_Advanced.git
```

2. Solution'ı Visual Studio ile açın

3. NuGet paketlerini restore edin:
```bash
dotnet restore
```

4. Connection string'i düzenleyin (DataAccessLayer > Context > CampContext.cs)

5. Migration oluşturun:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

6. Projeyi çalıştırın

## 🏗 Proje Mimarisi

```
CSharpCourse_Advanced/
│
├── EntityLayer/              # Veri modelleri
├── DataAccessLayer/          # Veritabanı işlemleri
├── BusinessLayer/            # İş mantığı
├── PresentationLayer/        # UI katmanı
└── EFProject/               # Entity Framework yapılandırması
```

## 📁 Katmanlar

### 1️⃣ Entity Layer (Varlık Katmanı)

Domain modelleri ve entity sınıfları bulunur.

```csharp
public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    
    public virtual Category Category { get; set; }
}
```

### 2️⃣ Data Access Layer (Veri Erişim Katmanı)

Veritabanı işlemleri ve repository pattern implementasyonu.

```csharp
public interface IRepository<T> where T : class
{
    List<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
}

public class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly CampContext _context;
    private readonly DbSet<T> _dbSet;
    
    public GenericRepository(CampContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    // Implementation...
}
```

### 3️⃣ Business Layer (İş Mantığı Katmanı)

İş kuralları ve validasyonlar bu katmanda yer alır.

```csharp
public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    
    public void AddProduct(Product product)
    {
        if (product.Price <= 0)
            throw new Exception("Ürün fiyatı 0'dan büyük olmalıdır!");
            
        _productDal.Add(product);
    }
}
```

### 4️⃣ Presentation Layer (Sunum Katmanı)

Windows Forms UI ve kullanıcı etkileşimi.

```csharp
public partial class FrmProduct : Form
{
    private readonly IProductService _productService;
    
    public FrmProduct()
    {
        InitializeComponent();
        _productService = new ProductManager(new ProductDal());
    }
    
    private void LoadProducts()
    {
        var products = _productService.GetAllProducts();
        dataGridView1.DataSource = products;
    }
}
```

## 💡 Kullanım

### CRUD İşlemleri

```csharp
// Ekleme
var product = new Product 
{ 
    ProductName = "Laptop", 
    Price = 15000, 
    Stock = 10 
};
productService.AddProduct(product);

// Listeleme
var products = productService.GetAllProducts();

// Güncelleme
product.Price = 14000;
productService.UpdateProduct(product);

// Silme
productService.DeleteProduct(productId);
```

### Entity Framework Migration

```bash
# Migration oluşturma
dotnet ef migrations add MigrationName

# Veritabanını güncelleme
dotnet ef database update

# Migration'ı geri alma
dotnet ef migrations remove
```

## 📚 Öğrenilenler

- N-Tier Architecture prensipleri
- Entity Framework Core kullanımı
- Repository Pattern implementasyonu
- Dependency Injection
- Code First yaklaşımı
- CRUD operasyonları
- Windows Forms ile UI geliştirme
- Katmanlar arası iletişim

## 🔗 Kaynaklar

- [Entity Framework Core Docs](https://docs.microsoft.com/en-us/ef/core/)
- [N-Tier Architecture](https://docs.microsoft.com/en-us/azure/architecture/guide/architecture-styles/n-tier)
- [Repository Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)

## 🤝 Katkıda Bulunma

1. Fork yapın
2. Feature branch oluşturun (`git checkout -b feature/amazing`)
3. Commit edin (`git commit -m 'feat: Add feature'`)
4. Push edin (`git push origin feature/amazing`)
5. Pull Request açın

## 📄 Lisans

Bu proje eğitim amaçlıdır.

## 👨‍💻 Geliştirici

**Emirhan ÇOBAN**
- GitHub: [@emirhan-coban](https://github.com/emirhan-coban)

---

⭐ Faydalı bulduysanız yıldız vermeyi unutmayın!

**Happy Coding! 🚀**
