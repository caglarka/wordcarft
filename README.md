# **Wordcraft**

**Wordcraft**, kullanıcıların İngilizce kelimeleri etkili bir şekilde öğrenmelerine ve hafızalarında tutmalarına yardımcı olan bir uygulamadır. Uygulama, kelime bilgisi geliştirme sürecini eğlenceli ve etkileşimli hale getirir.

## **Özellikler**

- **Kelime Saklama ve Görüntüleme**:
  - Öğrendiğiniz kelimeleri kaydedin ve kaydettiğiniz kelimelerin listesini görüntüleyin.
  - Kelime başına İngilizce anlamını, kullanım örneklerini ve diğer detayları ekleyin.

- **Örnek Cümleler Oluşturma**:
  - Her kelime için birden fazla örnek cümle oluşturun.
  - Yapay zeka destekli algoritma ile cümlelerin dil bilgisi, kelime kullanımı ve anlam doğruluğu değerlendirilir.

- **Otomatik Puanlama**:
  - Oluşturduğunuz cümlelerin kalitesi 1'den 10'a kadar puanlanır.
  - Gerçek zamanlı geri bildirim alarak cümlelerinizi geliştirin.

- **İngilizce Anlamlar**:
  - Her kelimenin İngilizce anlamını ekleyin ve bu anlamları detaylandırın.

- **İstatistik ve Analiz**:
  - Öğrenme sürecinizi takip edin. Kişiselleştirilmiş raporlar ve öneriler sunarak hangi kelimelerde zorlandığınızı ve hangi konularda daha fazla pratik yapmanız gerektiğini gösterir.

## **Kurulum**

### **Backend - .NET Core**
1. **.NET Core SDK**'yı [indirin ve yükleyin](https://dotnet.microsoft.com/download).
2. Proje dizininde `dotnet restore` komutunu çalıştırarak bağımlılıkları yükleyin.
3. `appsettings.json` dosyasında gerekli veritabanı bağlantı ayarlarını yapın.
4. `dotnet run` komutunu kullanarak backend'i başlatın.

### **Frontend - React**
1. [Node.js](https://nodejs.org/) ve [npm](https://www.npmjs.com/) yüklü olduğundan emin olun.
2. Proje dizininde `npm install` komutunu çalıştırarak bağımlılıkları yükleyin.
3. `npm start` komutunu kullanarak frontend'i başlatın.

## **Kullanım**

1. Uygulamayı başlattıktan sonra, giriş yaparak kelime öğrenme sürecinizi başlatabilirsiniz.
2. Yeni kelimeler ekleyin, anlamlarını girin ve örnek cümleler oluşturun.
3. Öğrenme sürecinizi geliştirmek için AI tabanlı geri bildirimleri ve puanlamaları kullanın.
4. İlerleyişinizi takip edin ve öğrenme istatistiklerinizi inceleyin.

## **Teknolojiler**

- **Backend**: .NET Core
- **Frontend**: React
- **Veritabanı**: SQL Server veya PostgreSQL (kullanıma bağlı)
- **Yapay Zeka**: Python tabanlı NLP kütüphaneleri (örneğin, SpaCy) veya Azure Cognitive Services

## **Katkıda Bulunma**

Katkıda bulunmak isterseniz, lütfen bir pull request gönderin veya bir sorun (issue) açın. Her türlü katkı ve geri bildirime açığız!

## **Lisans**

Bu proje MIT lisansı altında lisanslanmıştır. Daha fazla bilgi için [LICENSE](LICENSE) dosyasına göz atabilirsiniz.
