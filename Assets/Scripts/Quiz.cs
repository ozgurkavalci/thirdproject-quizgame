using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Sorular")]
    
    //[SerializeField] List<SorularSO> sorular=new List<SorularSO>();
    [SerializeField] TextMeshProUGUI quizSoru;
    [SerializeField] List<SorularSO> soruListesi=new List<SorularSO>();
    SorularSO mevcutSoru; // araci olacak

    [Header("Cevaplar")]
    [SerializeField] GameObject[] cevapButonlari;
    int dogruSecenekIndexi;
    
    public bool erkenCevapVerdi=true;

    [Header("Buton Renkleri")]
    [SerializeField] Sprite varsayilanCevapSprite;
    [SerializeField] Sprite secilenCevapSprite;
    [SerializeField] Sprite dogruCevapSprite;
    [SerializeField] Sprite yanlisCevapSprite;


    [Header("Sure Araclari")]
    [SerializeField] Image sureImage;
    Timer timer;

    

    [Header("Sure Araclari")]
    [SerializeField] TextMeshProUGUI skorTexti;

    Score score;


    [Header("Ilerleme Bari")]
    [SerializeField] Slider progressBar;

    public bool quizTamamlandi;


   void Awake() 
   {
      timer=FindObjectOfType<Timer>();  
      score=FindObjectOfType<Score>();
   }
   
    void Start()
    {
        progressBar.maxValue=soruListesi.Count;
        progressBar.value=0;
    }

    void Update() 
    {
       sureImage.fillAmount=timer.sureDolulukMiktari;
       if(timer.sonrakiSoruyuYukle)
       {
          if(progressBar.value==progressBar.maxValue)
          {
             quizTamamlandi=true;
             return;
          }
          erkenCevapVerdi=false;
          BirSonrakiSoruyuAl();

          timer.sonrakiSoruyuYukle=false;
          
       }
       else if(!erkenCevapVerdi && timer.soruyaCevapVeriyor)
       {
         int i=mevcutSoru.DogruCevapIndexi();
              
         Image buttonImage2=cevapButonlari[i].GetComponent<Image>();


             
         string araciCevapText=mevcutSoru.CevapAl(i);
             

         quizSoru.text="Uzgunum.Dogru Cevap Suydu: "+araciCevapText;
         buttonImage2.sprite=dogruCevapSprite;

         ButtonSecimSonrasiKilit(false);


       }
       

    }

    public void SoruGoruntule()
    {

       quizSoru.text=mevcutSoru.SoruCek();
       

        for(int i=0; i< cevapButonlari.Length; i++)
       {
            
            TextMeshProUGUI displayOptions=cevapButonlari[i].GetComponentInChildren<TextMeshProUGUI>();

            displayOptions.text=mevcutSoru.CevapAl(i);

       }

    }
    public void BirSonrakiSoruyuAl()
    {
        if(soruListesi.Count>0)
        {ButtonSecimSonrasiKilit(true);
         ButtonVarsayilanSprite();
         RastgeleSoruCek();
         SoruGoruntule();
         progressBar.value++;
         score.GoruntulenenSoruSayisiniArttir();
         
         
         
         
        }


    }

    public void RastgeleSoruCek()
    {

       int i=Random.Range(0, soruListesi.Count);
       mevcutSoru=soruListesi[i];
       if(soruListesi.Contains(mevcutSoru))
       {
          soruListesi.Remove(mevcutSoru);
       }
    }

    public void SecilenCevap(int index)
    {
       StartCoroutine(Deneme(index));
       
       timer.ZamanIptal();
       
       
      
       
       
    }

    IEnumerator  Deneme(int index)
    {
         erkenCevapVerdi=true;
         Image buttonImage=cevapButonlari[index].GetComponent<Image>();
         buttonImage.sprite=secilenCevapSprite;
         ButtonSecimSonrasiKilit(false);

         yield return new WaitForSeconds(2);
     
            if(index==mevcutSoru.DogruCevapIndexi())
            {
              
              quizSoru.text="Bravo.Dogru Cevap!";
              buttonImage.sprite=dogruCevapSprite;
              score.DogruCevapSayisiniArttir();
              
              
           
            }

            else
            {
              int i=mevcutSoru.DogruCevapIndexi();
              
              Image buttonImage2=cevapButonlari[i].GetComponent<Image>();


             
             string araciCevapText=mevcutSoru.CevapAl(i);
             

             quizSoru.text="Uzgunum.Dogru Cevap Suydu: "+araciCevapText;

             buttonImage.sprite=yanlisCevapSprite;
             buttonImage2.sprite=dogruCevapSprite;


            }
            skorTexti.text="Basari Yuzdesi: "+score.SkorHesaplama()+" %";

            /*if(progressBar.value==progressBar.maxValue)
            {

               quizTamamlandi=true;
            }*/





    }

    public void ButtonSecimSonrasiKilit(bool buttonstate)
    {
       
       Button button;

       for(int i = 0; i< cevapButonlari.Length; i++)
       {

          button=cevapButonlari[i].GetComponent<Button>();
          button.interactable=buttonstate;
       }

    }

    public void ButtonVarsayilanSprite()
    {
        
        for(int i=0;  i<cevapButonlari.Length; i++)
        {

           Image buttonImage=cevapButonlari[i].GetComponent<Image>();
           buttonImage.sprite=varsayilanCevapSprite;

        }


    }

    

    

    
    


  
    
}
