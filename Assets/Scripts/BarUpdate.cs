using UnityEngine;
using UnityEngine.UI;

public class BarUpdate : MonoBehaviour
{
    public PlayerCombat player; 
    public float barLength = 250f; 
    public float barHeight = 12f;  
    public Image bar; 
    Vector2 delta = Vector2.zero; 
    void Start()
    {
        delta.x = barLength * player.currentHealth / 100; 
        delta.y = barHeight;
        bar.rectTransform.sizeDelta = delta; 
        player.onHealthChangedCallback += UpdateBar;
    }

    void UpdateBar()
    {
        delta.x = barLength * player.currentHealth / 100; 
        bar.rectTransform.sizeDelta = delta;
    }
}