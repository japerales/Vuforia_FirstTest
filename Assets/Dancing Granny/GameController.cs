using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject HSPanel;
    public Text HSText;
    private Animator HSPanelanim;
    public AudioClip clip;
    private AudioSource Audio;
    public static GameController Instance;

    private float TimeLeft = 10f;
    public Text TimerTextbox;
    public GameObject flashButton;

    public bool gameFinished = false;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start () {
        //if (SceneManager.GetActiveScene().name.Equals("UDT_Main"))
          //  TimeLeft = clip.length;
        
        HSText.text = PlayerPrefs.HasKey("HighScore")? GetHighScore() :"0" ;
        
        HSPanelanim = HSPanel.GetComponent<Animator>();

        Audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name.Equals("UDT_Main"))
        {
            if (SpawnerScript.Instance.isGamePlaying && TimeLeft > 0f)
            {
                TimeLeft -= Time.deltaTime;
                //TimerTextbox.text = TimeLeft.ToString("f2");
                int minutes = Mathf.FloorToInt(TimeLeft / 60f);
                int seconds = Mathf.FloorToInt(TimeLeft - minutes * 60);
                TimerTextbox.text = string.Format("{0:0}:{1:00}", minutes, seconds);
                flashButton.SetActive(false);
            }
            else if (!SpawnerScript.Instance.isGamePlaying)
            {
                flashButton.SetActive(true);
            }

            if (TimeLeft < 0f)
            {
                GameOver();

            }
        }
        
	}

    public void PlayMusic()
    {
        Audio.Play();
    }

    public void StopMusic()
    {
        Audio.Stop();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("UDT_Main");
    }

    public void BackToIntro()
    {
        SceneManager.LoadScene("UDT_Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayHSPanel()
    {
        HSPanelanim.SetTrigger("PlayHSAnim");
    }

    public void CloseHSPanel()
    {
        HSPanelanim.SetTrigger("GoBack");
    }

    public string GetHighScore()
    {
        string text =  PlayerPrefs.GetString("HighScore");
        return text;
    }


    public void GameOver()
    {
        TimerTextbox.text = "0";
        StopMusic();
        gameFinished = true;
        SpawnerScript.Instance.CancelInvoke(); //dejamos de spawnear textboxs
        PlayHSPanel();
        HSText.text = ScoreManager.instance.ScoreText.text;
        setNewHighScore(HSText.text);
    }

    public void setNewHighScore(string currentScore)
    {
        string currentHS = GetHighScore();
        int hs = int.Parse(currentHS);
        int score = int.Parse(currentScore);

        if (score > hs)
        {
            PlayerPrefs.SetString("HighScore", HSText.text);
            PlayerPrefs.Save();
        }
    }

}
