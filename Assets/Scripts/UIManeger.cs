using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManeger : MonoBehaviour {

    public AudioSource audioSource;
   public GameObject levelPanel;
   public GameObject settingPanel;
   public Image soundButtonImage;
    public GameObject [] lockImage;
    public Image languageButtonImage;
    public Sprite [] languageButtonSprites;

    public Sprite[] soundSprites;

    // Use this for initialization
    void Start () {
        UtilityManeger.InitData();
        Init();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            // Quit the application
            Application.Quit();
        }

    }

    private void Init() {
        levelPanel.SetActive(false);
        settingPanel.SetActive(false);

        if (UtilityManeger.isSound)
        {
            audioSource.mute = false;
            soundButtonImage.sprite = soundSprites[1];
        }
        else
        {
            audioSource.mute = true;
            soundButtonImage.sprite = soundSprites[0];
        }

        if (UtilityManeger.isEnglish)
            languageButtonImage.sprite = languageButtonSprites[0];
        else
            languageButtonImage.sprite = languageButtonSprites[1];


        for (int i=0;i<UtilityManeger.unlockLevel;i++) {
            lockImage[i].SetActive(false);
        }
    }

    public void LevelButtonClick(int index)
    {

        if (UtilityManeger.unlockLevel - 1 >= index)
        {
            UtilityManeger.currentLevel = index;
            SceneManager.LoadScene(index+1);
        }
    }

    public void PlayButtonClick() {
        levelPanel.SetActive(true);
    }

    public void SettingButtonClick() {
        settingPanel.SetActive(true);
    }

    public void SettingCloseButtonClick() {
        settingPanel.SetActive(false);
    }

    public void ShareButtonClick() {
#if UNITY_ANDROID
        // Get the required Intent and UnityPlayer classes.
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        // Construct the intent.
        AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent");
        intent.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        intent.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Here's the text I want to share.");
        intent.Call<AndroidJavaObject>("setType", "text/plain");

        // Display the chooser.
        AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intent, "Share");
        currentActivity.Call("startActivity", chooser);
#endif
    }

    public void InAppPurChaseButtonClick() { }

    public void LanguageButtonClick() {
        UtilityManeger.isEnglish = !UtilityManeger.isEnglish;
        UtilityManeger.SaveLanguage();

        if (UtilityManeger.isEnglish)
            languageButtonImage.sprite = languageButtonSprites[0];
        else
            languageButtonImage.sprite = languageButtonSprites[1];
    }

    public void SoundButtonClick() {
        UtilityManeger.isSound = !UtilityManeger.isSound;
        UtilityManeger.SaveSound();
        if (UtilityManeger.isSound)
        {
            audioSource.mute = false;
            soundButtonImage.sprite = soundSprites[1];
        }
        else
        {
            audioSource.mute = true;
            soundButtonImage.sprite = soundSprites[0];
        }

    }

    



    


}
