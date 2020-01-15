
##### ABOUT THE PROJECT #####

Nowadays, many people communicate with each other via online messages on many platforms in line with the opportunities provided by the Internet. Through this widespread communication, many mobile and web applications are needed. AGM is one of the applications that will meet these needs. It lets its users communicate via online messages through groups that users establish. In this way, users can send messages, share advertisements, announcements through groups established by users. One of the most important features of AGM is to provide communication by keeping all private information such as telephone numbers and e-mail addresses confidential, based on the fact that users only know each other's user names. The application is implemented with ASP .Net MVC web technology in order to increase the communication quality of the users and enable them to communicate with each other through the privacy framework.

Introduction video url of the project : https://www.youtube.com/watch?v=Umh5fdy-hBc&t=314s

[![image](https://i.hizliresim.com/Xb19kR.jpg)](https://hizliresim.com/Xb19kR)

##### KURULUM HAKKINDA #####

1-) Masaüstüne veya herhangi bir yere klasör açın. Ve aşağıda bahsettiğim metodların 1 tanesini kullanarak kurulum işlemlerini yapın.

--- Proje İndirme Method 1 ---

2.1) Klasörü oluşturduktan sonra cmd (windows tuşu => çalıştır => cmd ile girebilirsiniz.) kullanarak cd komutu ile klasöre erişim sağlayın. Örnek masaüstü uzantımı verdim.

    cd [dosya local uzantı]
    cd C:\Users\EmreSert\Desktop\Agm 

2.2-) Resmi sitesinden Git versiyon sistemini indirin. (https://git-scm.com/)
    Aşağıdaki komutu command ekranına yazıp enter tuşu ile indirmeyi başlatın.

    git clone https://github.com/emresert/Anonymous-Group-Message.git

--- Proje İndirme Method 2 ---

2.3-) Eğer Github'dan zip olarak indirdiyseniz klasörünüze gelen .rar dosyasına sağ tıklayıp buraya çıkart seçeneği ile oluşturduğunuz klasörün içine proje dosyalarını çıkarın.

3-) Bilgisayarınızda mutlaka database işlemlerini kullanmanız için Ms SQL olması gerek.Ben bu projeyi yaparken Mictosoft SQL Server 2014 Management Studio kullandım.

--- Agm Database Oluşturma Method 1 ---

4.1-) Anonymous-Group-Message\DataBase klasörüne girin. Agm.mdf ve Agm_log database dosyalarını SQL Server'inize import etmeniz gerekecek.(Sql Db Attach)

Attach Nasıl Yapılır : https://www.youtube.com/watch?v=fUpc9cwbmFw

Bu linkdeki videoyu izleyip adımları tek tek yapın. Bu dosyaları videodaki gibi bu şekilde çalıştırmanız gerekecek.

--- Agm Database  Oluşturma Method 2 ---

4.2-) Sql bilgisi biraz daha iyi olanlar Anonymous-Group-Message\DataBase klasöründeki AgmDbScript'i çalıştırabilir. Scriptin 1. satırında aşağıdaki adımlara dikkat edin.

     Use [Agm] 	            -> komutunu sil
     Create Database [Agm]  -> komutunu ekle 

5-) Bilgisayarınızda projeyi çalıştırabilmeniz için Microsoft Visual Studio olması gerekir. Yoksa yükleyin (https://azure.microsoft.com/tr-tr/products/visual-studio/). Daha sonra Anonymous-Group-Message klasörüne girip Agm.sln uzantılı dosyaya çift tıklayıp çalıştırın. Visual Studio'nun projeyi yüklemesini bekleyin. Ayrıca açıldıktan sonra kodlara da ulaşabilirsiniz. Error List'de sarı renk türünde uyarılar olabilir. Muhtemelen referansını verdiğim eklentilerin güncel versiyonları için bilgilendirme gelebilir.

6-) Solution Explorer'daki Web.Config dosyasında ayarlar yapmanız gerekiyor. Bu ayar database bağlantısı için gerekli.
Yapmanız gereken tek şey Web.config dosyasına girip belirttiğim kısma kendi Sql Server adınızı yazmanız gerekiyor. Çünkü projeyi ben geliştirdiğim için benim bilgisayarımdaki Sql Server adı orada yer alıyor. Sql server adını bilmeyenler bu linki incelesin.(https://sqlserveregitimleri.com/sql-serverda-server-adini-ogrenmek)

Dipnot: Server adınızı yıldızların içine yazmayın onları belirtmek için kullandım. Yıldızları kaldırın yani unutmayın! :)

Değişecek Kısım => connectionString="Data Source=DESKTOP-9SG6I3G\SQLEXPRESS;Initial Catalog=Agm;Integrated Security=True"

 <connectionStrings>
    <add name="MsgConnection" connectionString="Data Source=  **Kendi SQL Server Adınız** ;Initial Catalog=Agm;Integrated Security=True"         providerName="System.Data.SqlClient" />
 </connectionStrings>

7-) Son adım olarak bazılarınız SQL Service Broker hatası alabilir. Bu hatayı önlemek için Sql komutu yazmamız gerekli. Bu hatayı alanlar resimde gösterdiğim komutu Sql komutu olarak yazmayı unutmasın.

** Agm database'i seçip aşağıdaki komutu yazıp execute(F5) edin.

komut :   ALTER DATABASE [Agm] SET ENABLE_BROKER

Komut Resim link : https://i.hizliresim.com/bvNDMG.jpg

Çözüm sayfasını merak edenler : https://social.msdn.microsoft.com/Forums/sqlserver/en-US/742aa595-45f0-41d9-9fd0-8be9a85c8903/service-broker-is-disabled-in-msdb-or-msdb-failed-to-start?forum=sqlservicebroker

8-) Artık Visual Studioya tekrar girip projeyi ister F5 ile isterseniz Debug Sekmesi altındaki Start Debugging yaparak çalıştırabilirisiniz. Bu arada Login ekranı gelince kullanıcı adına yönetici parola kısmınada asd yazarak giriş yapıp projenin çalıştığını test edebilirsiniz. Son olarak IIS ayarlarına ihtiyaç duyan bazı kullanıcılar olabilir. IIS Açma linkinide size bıraktım.

    IIS Nasıl Açılır : https://www.youtube.com/watch?v=9i7JIkVjv3E

9-) Sizlere faydalı olabildiysem ne mutlu bana. Hepinize başarılar dilerim.







