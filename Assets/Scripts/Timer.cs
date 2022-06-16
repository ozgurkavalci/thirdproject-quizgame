using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float  soruGoruntulemeSuresi=30f;
    [SerializeField] float  cevapGoruntulemeSuresi=5f;
    float sureDegeri;
    public float sureDolulukMiktari;
    public bool soruyaCevapVeriyor=true;
    public bool sonrakiSoruyuYukle=false;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ZamanMetodu();
    }

    public void ZamanIptal()
    {
       sureDegeri=0;

    }

    public void ZamanMetodu()
    {
       sureDegeri-=Time.deltaTime;
       if(!soruyaCevapVeriyor)
       {
           if(sureDegeri>0)
           {
               sureDolulukMiktari=sureDegeri/soruGoruntulemeSuresi;
           }
           else
           {
                 soruyaCevapVeriyor=true;
                 sureDegeri=cevapGoruntulemeSuresi;


           }

       }

       else
       {
            if(sureDegeri>0)
            {
                sureDolulukMiktari=sureDegeri/cevapGoruntulemeSuresi;
                
            }
            else
            {
               soruyaCevapVeriyor=false;
               sureDegeri=soruGoruntulemeSuresi;
               sonrakiSoruyuYukle=true;

            }

       }
       Debug.Log(sureDegeri);


    }
}
