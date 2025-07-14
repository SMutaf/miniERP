# **ERP Son Güncellemler**

Windows form uygulaması (.NET FRAMEWORK) ile yapıldı

### **Açıklama**
Uygulama içerisinde bir Ayarlar Sayfası yer almaktadır. Bu sayfa üzerinden:

SQL bağlantı bilgilerinizi girerek, bağlantınızı test edebilir,

Bağlantı başarılı olduktan sonra, firma ismini belirtebilir ve bu firmayı kaydedebilirsiniz.

Kaydet butonu ile:

Firma bilgisi, hem belirttiğiniz veritabanına kaydedilir,

Hem de Windows kayıt defterinde (Registry) CurrentUser\SOFTWARE\Test altında saklanır.

Eğer bu kayıt defteri anahtarı daha önce oluşturulmamışsa, uygulama başlatıldığında sizi bilgilendirerek otomatik olarak oluşturur.

Ayarlar sayfasının sağ alt tarafında ise, uygulamanın o an kullandığı SQL sunucusu ve veritabanı bilgisi anlık olarak gösterilir.

Ayrıca sayfanın sağ üst kısmından hangi server ve veri tabanında işlem yapacağınızı kolayca seçebilirsiniz.

Uygulamanın giriş ekranında, kayıt defterinden çekilen firmalar gösterilir. Giriş için kullanılan kullanıcı adı ve şifre, ayarlar kısmında firmayı eklerken kullandığınız sql username ve sql passworddur.

Kontrol sayfasında ise firmaya ait çalışanların bilgileri gösterilir.

İlerleyen zamanda Çalışan ekleme silme ve kod optimizasonu ile uğraşmayı düşünüyorum.
![SettingPageSS](/img/settingPage.png)
![LoginScreenSS](/img/logIn.png)
![ControlPageSS](/img/controlPage.png)

