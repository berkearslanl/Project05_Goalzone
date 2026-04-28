# ⚽ GoalZone — Premier League Maç Takip Platformu

GoalZone, Premier League maçlarını takip edebileceğiniz, fikstür, puan durumu ve maç detaylarını dinamik olarak sunan ASP.NET Core tabanlı tam yığın (full-stack) bir web uygulamasıdır.

---

## 🛠 Mimari Yapı

Proje iki katmandan oluşmaktadır:

- **GoalZoneProject.WebApi** → ASP.NET Core Web API (veri ve iş katmanı)
- **GoalZoneProject.WebUI** → ASP.NET Core MVC (kullanıcı arayüzü)

WebUI, API ile doğrudan veritabanı bağlantısı kurmaz. Tüm veri iletişimi **IHttpClientFactory** üzerinden HTTP tabanlı olarak sağlanır.

---

## 🗄 Veri Modeli

Temel entity yapısı:

- **Team** → Takım bilgileri
- **Fixture** → Maç bilgisi, skor ve hafta
- **MatchEvent** → Gol, kart ve oyuncu değişiklikleri
- **MatchStats** → Maç istatistikleri

---

## ✨ Temel Özellikler

### 📅 Fikstür & Maç Takibi
- Haftaya göre maç listeleme
- Canlı, tamamlanmış ve yaklaşan maç ayrımı
- Maç detay sayfası ve zaman sıralı olay akışı

### 📊 Dinamik Puan Durumu
- Puan tablosu veritabanında tutulmaz
- Tüm hesaplamalar tamamlanan maçlardan LINQ ile yapılır
- Averaj ve form (son 5 maç) dinamik olarak oluşturulur

### 🎯 Maç Detayları
- Gol, kart ve değişikliklerin timeline görünümü
- Karşılaştırmalı maç istatistikleri (progress bar)
- Oynanmamış maçlar için koşullu görünüm kontrolü

### ⚙️ Admin Panel
- Maç, olay ve istatistik ekleme/silme işlemleri
- API üzerinden veri yönetimi

---

## 🧰 Kullanılan Teknolojiler

- ASP.NET Core 6 (Web API & MVC)
- Entity Framework Core (Code First)
- MS SQL Server
- IHttpClientFactory
- Swagger
- Bootstrap 5

---

## 📸 Ekran Görüntüleri
> Ana Sayfa
> <img width="1920" height="2902" alt="home" src="https://github.com/user-attachments/assets/3f6d9107-5412-4c34-baf8-849a7a18e66a" />
> Hafta Seçimi
> <img width="1909" height="909" alt="home2" src="https://github.com/user-attachments/assets/93a0ca7d-49e3-4aa5-8baa-d9740e5dab47" />
> Fikstür
> <img width="1920" height="2348" alt="fikstür" src="https://github.com/user-attachments/assets/86723a3f-694f-4f69-be30-70fa72652cae" />
> Puan Durumu
> <img width="1899" height="908" alt="scoreboard" src="https://github.com/user-attachments/assets/146448ba-0abd-426b-ae24-d610d68b4093" />
> İstatistikler
> <img width="1920" height="2891" alt="statistics" src="https://github.com/user-attachments/assets/8e22307c-59fd-45b0-ad49-983d4a8708d7" />
> Maç Olayı Ekleme
> <img width="1913" height="907" alt="matchevent" src="https://github.com/user-attachments/assets/a254b9d3-8113-4639-9744-06a17f6dc759" />
