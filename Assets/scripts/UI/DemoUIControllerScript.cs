using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DemoUIControllerScript : MonoBehaviour
{
    [SerializeField]
    int limitTime = 60;
    [SerializeField]
    Text txtTime;
    [SerializeField]
    Button btnPause;
    [SerializeField]
    Image healthBarFill;

    Text btnPauseText;
    private bool isRunning;
    float time = 0;

    float damage;
    // Start is called before the first frame update
    void Start()
    {
        txtTime.text = "Time: " + limitTime.ToString();
        btnPauseText = btnPause.GetComponentInChildren<Text>();
        btnPauseText.text = "PAUSE";
        isRunning = true;
        healthBarFill.fillAmount = 1;
        damage = 1.0f / limitTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Count down time
        time += Time.deltaTime;
        if (time > 1)
        {
            limitTime -= 1;
            time = 0;
            txtTime.text = "Time: " + limitTime.ToString();
            //Health bar
            healthBarFill.fillAmount -= damage;
        }
        if (limitTime == 0)
        {
            Time.timeScale = 0;
        }

        

    }
    public void BtnReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BtnPause()
    {
        if (isRunning) PauseGame(); else ResumeGame();
    }
    void PauseGame()
    {
        isRunning = false;
        btnPauseText.text = "CONTINUE";
        Time.timeScale = 0;
        
    }
    void ResumeGame()
    {
        isRunning = true;
        Time.timeScale = 1;
        btnPauseText.text = "PAUSE";
    }
}
