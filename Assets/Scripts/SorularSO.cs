using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Soru",menuName="Soru Yarat",order=0)]

public class SorularSO : ScriptableObject
{
    [TextArea(2,5)]

    [SerializeField] string soru="Lutfen soruyu giriniz:";

    [SerializeField] string[] secenekler=new string[4];  

    [SerializeField] int dogruSecenekIndexi;


    public string SoruCek()
    {
          return soru;
    }

    public string CevapAl(int i)
    {
        return secenekler[i];
    }
    
    public int DogruCevapIndexi()
    {

        return dogruSecenekIndexi;
    }



}
