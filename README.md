# 🎮 RunControl Mobil Oyunu Projesi

Bu depo, Unity ile geliştirilmiş bir mobil koşu/hayatta kalma (Endless Runner) türündeki oyunun kaynak kodlarını içermektedir.

## 👥 Proje Rolümüz ve Takım Katkıları

**RunControl** projesinin geliştirme sürecinde, oyunun **sıfırdan tamamlanma aşamasına kadar** ekip olarak kritik ve çok yönlü sorumluluklar üstlenilmiştir. Projenin kalitesini ve oynanışını doğrudan etkileyen **QA Testing, Bug Hunting, Game Development** ve **Level Designing** gibi temel alanlarda kapsamlı katkılar sağlanmıştır.

#### 1. Oyun Geliştirme (Game Development)

* Oyunun temel mekaniklerini, karakter hareketlerini (`Karakter.cs`) ve düşman/engel etkileşimlerini (`Dusman.cs`, `DusenAgacEngel.cs`) C# ile kodlandı.
* `GameManager.cs`, `AnaMenu_Manager.cs` ve `MarketManager.cs` gibi merkezi sistemlerin entegrasyonunu ve sürdürülebilirliğini sağlandı.
* Kod tabanını temizleyerek ve kritik scriptleri (örneğin reklam kodlarından arındırarak) optimize ederek projenin kalitesini arttırıldı.

#### 2. Bölüm Tasarımı (Level Designing)

* Oynanış akışını (pacing) ve zorluk eğrisini belirleyerek oyuncu deneyimini optimize edildi.
* `Level_Manager.cs` bileşenlerini kullanarak dinamik veya sabit bölüm yapılarının oluşturulması ve engellerin stratejik yerleşimini tasarlandı.

#### 3. Kalite Güvence ve Hata Ayıklama (QA Testing & Bug Hunting)

* Geliştirme süreci boyunca sürekli kalite kontrolü sağlayarak, oyunun baştan sona (End-to-End) titizlikle test edilmesini sağlandı.
* Karşılaşılan tüm collision hataları, mantık sorunları ve performans aksaklıklarını hızlıca tespit edip giderdik.

---

### 🔧 Kullanılan Teknolojiler

* **Oyun Motoru:** Unity 3D
* **Programlama Dili:** C#

* Oyun içi görsel:
* <img width="649" height="593" alt="arthur" src="https://github.com/user-attachments/assets/26b78240-6400-48f3-ba58-5ba744f1303a" />
