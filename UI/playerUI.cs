using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerUI : MonoBehaviour
{
    public TextMeshProUGUI ammoReadText;
    public TextMeshProUGUI clipReadText;
    public TextMeshProUGUI clipCapacityText;
    public Slider healthSlider;
    public void SetHealthUI(float percentage)
    {
        healthSlider.value = percentage;
    }
    public void SetAmmoUI(int amount)
    {
       ammoReadText.text = amount.ToString();
    }
    public void SetClipUI(int amount, int Capacity)
    {
       clipReadText.text = amount.ToString();
       clipCapacityText.text = Capacity.ToString();
    }
}
