using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Purchasing;
using TMPro;
using Hamza;
public class MarketManager : MonoBehaviour, IStoreListener
{
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_ExtensionProvider;
    //-----------------ÜRÜNLERİ BELİRLEDİK
    private static string Puan_250 = "puan250";//UrunID si eklenecek
    private static string Puan_500 = "puan500";
    private static string Puan_750 = "puan750";
    private static string Puan_1000 = "puan1000";
    //----------------------------------------
    [Header("---------DİL VERİLERİ")]
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();//Dil verilerini okur
    List<DilVerileriAnaObje> _DilOkunanVerileri = new List<DilVerileriAnaObje>();//İlgili olanı alır
    public TextMeshProUGUI TextObjesi;//
    VeriYonetimi _VeriYonetimi = new VeriYonetimi();
    BellekYonetimi _Bellekyonetim = new BellekYonetimi();

    void Start()
    {
        _VeriYonetimi.Dil_Load();
        _DilOkunanVerileri = _VeriYonetimi.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVerileri[3]);
        DilTercihYonetimi();

        if(m_StoreController == null)
        {
            InitializePurchasing();//Mağaza başlatılmadıysa başlatılmasını sağlıyoruz
        }
        
    }

    public void InitializePurchasing()
    {   
        if(IsInitialized())//Mağza altyapısı hazır mı kontrolü
        {
            return;
        }
        //Mağazanın standart olarak oluşturulmasını sağlıyor
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());//(builder oluşturuyoruz.Mağazamızın kurulumu tetikledik)

        //ÜRÜNLERİ MAĞAZAYA EKLEDİK
        builder.AddProduct(Puan_250,ProductType.Consumable);//ProductType. dan sonrası kaç kere satın alınabileceğini seçiyorsun.
        builder.AddProduct(Puan_500,ProductType.Consumable);
        builder.AddProduct(Puan_750,ProductType.Consumable);
        builder.AddProduct(Puan_1000,ProductType.Consumable);
        //SATIN ALMA İŞLEMİ İNŞA EDİLDİ
        UnityPurchasing.Initialize(this ,builder);


        //BU FONKSYİONU YAZINCA SİSTEM TETİKTE BEKLİYOR VE URUNAL() BEKLENİYOR
    }
    
    public void UrunAl_250()
    {//HERHANGİ BİR ÜRÜN SATIN ALINIRSA BUYPRODUCTID() ÇALIŞIYOR
        BuyProdcutID(Puan_250);
    }
    public void UrunAl_500()
    {
        BuyProdcutID(Puan_500);
    }
    public void UrunAl_750()
    {
        BuyProdcutID(Puan_750);
    }
    public void UrunAl_1000()
    {
        BuyProdcutID(Puan_1000);
    }

    void BuyProdcutID(string productId)
    {   
        if(IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);//Bana bu Idye sahip olan Ürünü getir.

            if(product != null && product.availableToPurchase )//Eğer ürün varsa  ve erişilebilirse
            {

                m_StoreController.InitiatePurchase(product);//ürün bilgisini vererek satın almayı başlatıyor

            }else
            {
                Debug.Log("Satın alırken hata oluştu");
            }
        }
        else
        {
            Debug.Log("Ürün çağırılamıyor.Sonra tekrar deneyin");
        }


    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        throw new System.NotImplementedException();
    }
    /*public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {                   //SATIN ALINMAK İSTENEN ÜRÜN ID'si , ŞUYSA , İÇERİ GİR
        if(String.Equals(purchaseEvent.purchasedProduct.definition.id,Puan_250,StringComparison.Ordinal))//Bu iki değer birbirine eşitse doğru ürünü almaya çalışıyorumdur.
            {
                _Bellekyonetim.VeriKaydet_int("Puan",_Bellekyonetim.VeriOku_i("Puan") + 250);
            }

        else if(String.Equals(purchaseEvent.purchasedProduct.definition.id,Puan_500,StringComparison.Ordinal))//Bu iki değer birbirine eşitse doğru ürünü almaya çalışıyorumdur.
            {
                _Bellekyonetim.VeriKaydet_int("Puan",_Bellekyonetim.VeriOku_i("Puan") + 500);
            }
        
        else if(String.Equals(purchaseEvent.purchasedProduct.definition.id,Puan_750,StringComparison.Ordinal))//Bu iki değer birbirine eşitse doğru ürünü almaya çalışıyorumdur.
            {
                _Bellekyonetim.VeriKaydet_int("Puan",_Bellekyonetim.VeriOku_i("Puan") + 750);
            }

        else if(String.Equals(purchaseEvent.purchasedProduct.definition.id,Puan_1000,StringComparison.Ordinal))//Bu iki değer birbirine eşitse doğru ürünü almaya çalışıyorumdur.
            {
                _Bellekyonetim.VeriKaydet_int("Puan",_Bellekyonetim.VeriOku_i("Puan") + 1000);
            }
            return PurchaseProcessingResult.Complete;
    }*/

    public void OnPurchaseFailed(Product product , PurchaseFailureReason failureReason)
    {
        throw new System.NotImplementedException();
    }
    

    public void OnInitialized(IStoreController controller , IExtensionProvider extensions)//MAĞAZA BAŞLATILDIĞINDA CONTROLLER VE EKLENTİ RETURN EDİYOR
    {
        m_StoreController = controller;
        m_ExtensionProvider = extensions;
    }
    
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        throw new System.NotImplementedException();
    }


    private bool IsInitialized()//bool varsa true veya false dönecek demektir fonksiyon
    {
        return m_StoreController != null && m_ExtensionProvider != null; //Eşit değilse null a ve eklenti paketleri tanımsıza eşit değilse fonksiyon true döndürür.
        //Gerekli altyapı sağlandıysa true dönecek.
    }

    void DilTercihYonetimi()
    {
        string dil = _Bellekyonetim.VeriOku_s("Dil");

        if(dil == "TR")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_TR[0].Metin;

        }else if(dil == "EN")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_EN[0].Metin;

        }else if(dil == "RS")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_RS[0].Metin;

        }else if(dil == "SP")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_SP[0].Metin;

        }else if(dil == "FR")
        {
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_FR[0].Metin;
        }
        else if(dil == "AR")
        {
           
            TextObjesi.text = _DilVerileriAnaObje[0]._DilVerileri_AR[0].Metin;
           
        }
        else
            Debug.Log("Something wrong.");
    }
    public void GeriButonu()
    {
       SceneManager.LoadScene(0); 
    }
}
