using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;
    MainMenu mainMenu;
    Timer timer;

    
    void Awake() 
    {
        quiz=FindObjectOfType<Quiz>();
        endScreen=FindObjectOfType<EndScreen>();
        mainMenu=FindObjectOfType<MainMenu>();
        timer=FindObjectOfType<Timer>();
        
    }
    void Start()
    {
        mainMenu.gameObject.SetActive(true);
        quiz.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(false);
        timer.gameObject.SetActive(false);
    }

    void Update() 
    {
        if(quiz.quizTamamlandi)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            timer.gameObject.SetActive(false);
            endScreen.FinalSkoruGoster();

        }
    }

    public void onClickReplay()
    {
        mainMenu.gameObject.SetActive(false);
        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
        timer.gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void onClickPlay()
    {
        mainMenu.gameObject.SetActive(false);
        quiz.gameObject.SetActive(true);
        timer.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);


    }

  
}
