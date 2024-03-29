using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public static healthbar instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
