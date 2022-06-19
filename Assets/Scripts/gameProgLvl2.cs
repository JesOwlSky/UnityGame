using UnityEngine;
using UnityEngine.UI;

public class gameProgLvl2 : MonoBehaviour
{
    public Enemy policeman1;
    public Enemy policeman2;
    public Enemy jakuza1;
    public Enemy jakuza2;
    public Enemy jakuza3;
    public Dialog dialogWindow; 
    public Image endJakuza;
    public Image endPolice;
    public Image endWin;
    public Transform target;
    public Transform targetEnd;
    public Transform player;
    public float showTime = 5f; 
    public float timer = 0f; 
    private string preview = "City";
    private string policeText = "- Hey! You!\nSo, here you are again.\nI warned you not to come here, dude.\nNow, I'm gonna have to arrest you";
    private string playerText = "- Ohhh - shi";
    private string help = "* RUN! *";
    private bool startState = true;
    private bool talkPoliceState = false;



    private void Update()
    {
        timer += Time.deltaTime; 
        if (startState && timer < showTime)
        {
            dialogWindow.ShowText(preview);
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
                policeman1.SetTarget(player); 
                policeman1.isHunt = true; 
                talkPoliceState = false;
            }
        }

        if (timer > 5f && !policeman1.gameObject.activeSelf)
        {
            SpawnPoliceman(); 
        }

    }

    public void SpawnPoliceman() 
    {
        policeman1.gameObject.SetActive(true);
        policeman2.gameObject.SetActive(true);
        policeman1.SetTarget(target);
        policeman2.SetTarget(policeman1.transform);
    }

    public void SpawnJakuza() 
    {
        jakuza1.gameObject.SetActive(true);
        jakuza2.gameObject.SetActive(true);
        jakuza3.gameObject.SetActive(true);
        jakuza1.SetTarget(player);
        jakuza2.SetTarget(player);
        jakuza3.SetTarget(player);
        policeman1.isHunt = false;
        policeman2.isHunt = false;
        policeman1.SetTarget(targetEnd);
        policeman2.SetTarget(targetEnd);

    }

    public void Talk(string name) 
    {
        if (name == "Police")
        {
            timer = 0f;
            talkPoliceState = true;
        }
        if (name == "jakuza1" || name == "jakuza2" || name == "jakuza3") 
        {
            jakuza1.isHunt = true;
            jakuza2.isHunt = true;
            jakuza3.isHunt = true;
        }
    }

    public void GameOver(string name) 
    {
        if (name == "jakuza1" || name == "jakuza2" || name == "jakuza3")
            endJakuza.gameObject.SetActive(true);
        if (name == "Police")
            endPolice.gameObject.SetActive(true);
    }

    public void YouWin() 
    {
        endWin.gameObject.SetActive(true);
    }
}
