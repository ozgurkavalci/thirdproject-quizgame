using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int goruntulenenSoruSayisi=0;
    public int dogruCevaplananSoruSayisi=0;

    public int DogruCevapSayisi()
    {
        return dogruCevaplananSoruSayisi;
    }

    public void DogruCevapSayisiniArttir()
    {
        dogruCevaplananSoruSayisi++;
    }

    public int GoruntulenenSoruSayisi()
    {
        return goruntulenenSoruSayisi;
    }

    public void GoruntulenenSoruSayisiniArttir()
    {
        goruntulenenSoruSayisi++;
    }

    public int SkorHesaplama()
    {
        return Mathf.RoundToInt(dogruCevaplananSoruSayisi/(float)goruntulenenSoruSayisi*100);
    }
}
