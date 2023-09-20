using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BarData : MonoBehaviour
{
	public Slider slider;
	public Image fill;
	//public TextMeshProUGUI currentValueText;

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		//currentValueText.text = currentValueText.ToString();
	}

	public void SetHealth(int health)
	{
		slider.value = health;
		//currentValueText.text = currentValueText.ToString();
	}

	public int getHealth()
	{
		return (int)slider.value;
	}
}