using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI finalSkorTexti;
   Score score;

    // Update is called once per frame
    void Awake()
    {
        score=FindObjectOfType<Score>();
    }
    void Update()
    {
        
    }
    void Start()
    {
        FinalSkoruGoster();
    }

    public void FinalSkoruGoster()
    {
        finalSkorTexti.text="Tebrikler!\nBasari Yuzdeniz "+score.SkorHesaplama()+" %";
    }
}
