using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainGame : MonoBehaviour {

    public SoundController soundController;
    public GameObject winPanelPopup;
    public GameObject preViewPanelPopup;
    public GameObject startButton;
    public GameObject closeButton;

    public Image previewImage;
    public Image previewButtonImage;

    public Text stepText;
    public Text puzzleSizeText;
    public Text totalStepText;
    public Text highestStepText;

    public string[] puzzleEnglishSize;
    private string[] puzzleBanglaSize= { "৩*৩", "৩*৩", "৩*৩", "৪*৪", "৪*৪", "৪*৪", "৪*৪", "৫*৫", "৫*৫", "৫*৫" };

   

    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
        if (UtilityManeger.isEnglish)
            stepText.text = "Step: " + UtilityManeger.currentStep;       
        else 
            stepText.text = "ধাপ : " + WordCoverterIntegerToString( UtilityManeger.currentStep);
        
    }

    void Init() {


       if(UtilityManeger.isEnglish)
        puzzleSizeText.text = puzzleEnglishSize[UtilityManeger.currentLevel];
       else
            puzzleSizeText.text = puzzleBanglaSize[UtilityManeger.currentLevel];

        winPanelPopup.SetActive(false);
        preViewPanelPopup.SetActive(true);
        startButton.SetActive(true);
        closeButton.SetActive(false);

        if (UtilityManeger.isSound)       
            soundController.OnPlay();
            
        else        
            soundController.OnMute();
        


    }

    

    public void WinPanelPopUpOpen() {
        soundController.WinSound();
        if (UtilityManeger.currentStep > UtilityManeger.highestStep)
        {
            UtilityManeger.highestStep = UtilityManeger.currentStep;
            UtilityManeger.SaveHighestScore();
        }

        if (UtilityManeger.isEnglish)
        {
            totalStepText.text = "Total Step : " + UtilityManeger.currentStep;
            highestStepText.text = "Top Step : " + UtilityManeger.highestStep;
        }
        else {
            totalStepText.text = "মোট ধাপ : " + WordCoverterIntegerToString( UtilityManeger.currentStep);
            highestStepText.text = "সর্বাধিক ধাপ : " + WordCoverterIntegerToString( UtilityManeger.highestStep);
        }
        winPanelPopup.SetActive(true);
    }

    public void WinPanelPopUpClose() {
        winPanelPopup.SetActive(false);
    }

    public void HomeAndBackButtonClick() {
        soundController.ButtonClick();
        SceneManager.LoadScene(0);
    }

    public void NextButtonClick() {

        soundController.ButtonClick();
        UtilityManeger.currentLevel++;
        if (UtilityManeger.currentLevel==UtilityManeger.levelTotal) 
            UtilityManeger.currentLevel = 0;
        
        UtilityManeger.SaveCurrentLevel();

        UtilityManeger.unlockLevel++;
        if (UtilityManeger.unlockLevel > UtilityManeger.levelTotal)
            UtilityManeger.unlockLevel = UtilityManeger.levelTotal;

        UtilityManeger.SaveUnlockLevel();

        SceneManager.LoadScene(1);
    }

   

    public void PreViewButtonClick() {
        soundController.ButtonClick();
        preViewPanelPopup.SetActive(true);
        startButton.SetActive(false);
        closeButton.SetActive(true);
    }

    public void StartAndButtonClick() {
        soundController.ButtonClick();
        preViewPanelPopup.SetActive(false);
        startButton.SetActive(false);
        closeButton.SetActive(false);
    }

    public string WordCoverterIntegerToString(int num)
    {
        string result = "";
        while (num > 0) //do till num greater than  0
        {
            int mod = num % 10;  //split last digit from number
            num = num / 10;    //divide num by 10. num /= 10 also a valid one

           
           result =  BanglaCover(mod)+ result ;


        }

        return result;
    }


    public string BanglaCover(int mod) {

        switch (mod)
        {
            case 1:
                return "১";
               
            case 2:
                return "২";
                
            case 3:
                return "৩";
                
            case 4:
                return "৪";
                
            case 5:
                return "৫";
                
            case 6:
                return "৬";
                
            case 7:
                return "৭";
                
            case 8:
                return "৮";
                
            case 9:
                return "৯";

            default:
                return "০";
                
           

        }
    }
}
