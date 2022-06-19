using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text text; 
    public Image back; 

    public void Show()
    {
        this.gameObject.SetActive(true); 
    }

    public void Hide() 
    {
        this.gameObject.SetActive(false); 
    }

    public void ShowText(string dialog) 
    {
        this.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
        text.text = dialog; 
    }
}