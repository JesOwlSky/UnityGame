using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameProgress : MonoBehaviour
{
    public Enemy policeman;
    public Enemy bear;
    public Dialog dialogWindow;
    public Image endBear;
    public Image endPolice;
    public Image endJakuza;
    public Image endWin;
    public Button reload;
    public Button nextLvl;
    public Transform target;
    public Transform targetEnd;
    public Transform player;
    public float showTime = 5f;
    public float timer = 0f;
    private string policeText = "- Hey! You!\nSo, here you are again.\nI warned you not to come here, dude.\nNow, I'm gonna have to arrest you";
    private string playerText = "- Ohhh - shi";
    private string help = "* RUN! *";
    private bool startState = true;
    private bool talkPoliceState = false;
    private string _currentScene = "Level_1_Forest";


    private void Update()
    {
        
        timer += Time.deltaTime;
        if (startState && timer < showTime)
        {
            dialogWindow.Show();
        }
        else
        {
            dialogWindow.Hide();
            startState = false;
        }

        if (talkPoliceState)
        {
            if (timer < showTime)
            {
                dialogWindow.ShowText(policeText);
            }
            if (timer > showTime && timer < showTime * 2f)
            {
                dialogWindow.ShowText(playerText);
            }
            if (timer > showTime * 2f)
            {
                dialogWindow.ShowText(help);
            }
            if (timer > showTime * 3f)
            {
                dialogWindow.Hide();
                policeman.SetTarget(player);
                policeman.isHunt = true;
                talkPoliceState = false;
            }
        }

        if (timer > 5f  && !policeman.gameObject.activeSelf)
        {
            SpawnPoliceman();
        }

    }
    public void SpawnPoliceman()
    {
        policeman.gameObject.SetActive(true);
        policeman.SetTarget(target);
    }
    
    public void SpawnBear()
    {
        bear.gameObject.SetActive(true);
        bear.SetTarget(player);
        policeman.isHunt = false;
        policeman.SetTarget(targetEnd);

    }

    public void Talk(string name) 
    {
        if (name == "Police")
        {
            timer = 0f;
            talkPoliceState = true;
        }
        if (name == "Bear")
        {
            bear.isHunt = true;
        }
    }

    public void GameOver(string name) 
    {
        if (name == "Bear")
            endBear.gameObject.SetActive(true);
        if (name == "Police")
            endPolice.gameObject.SetActive(true);
        if (name == "Yakuza")
            endJakuza.gameObject.SetActive(true);
        reload.gameObject.SetActive(true); 
    }

    public void YouWin() 
    {
        if (_currentScene == "Level_1_Forest") 
        { 
            _currentScene = "Level_2_City"; 
            endWin.gameObject.SetActive(true); 
            nextLvl.gameObject.SetActive(true); 
        }
    }

    public void LoadScene() 
    {
        SceneManager.LoadScene(_currentScene);
    }
}
