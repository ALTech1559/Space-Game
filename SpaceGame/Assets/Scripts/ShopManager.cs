using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

	public Text Money;
	void Start()
	{
		Money.text = PlayerPrefs.GetInt("Money").ToString();
	}

	public void S2()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		if (PlayerPrefs.GetInt("Money") >= 3000)
		{
	PlayerPrefs.SetString("ship2", "on");
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 3000);
			Money.text = PlayerPrefs.GetInt("Money").ToString();
		}
	
	}
	public void S3()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		if (PlayerPrefs.GetInt("Money") >= 3500)
		{
			PlayerPrefs.SetString("ship3", "on");
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 3500);
			Money.text = PlayerPrefs.GetInt("Money").ToString();
		}
	
	}
	public void S4()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		if (PlayerPrefs.GetInt("Money") >= 3750)
		{
			PlayerPrefs.SetString("ship4", "on");
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 3750);
			Money.text = PlayerPrefs.GetInt("Money").ToString();
		}
	
	}
	public void S5()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		if (PlayerPrefs.GetInt("Money") >= 4300)
		{
			PlayerPrefs.SetString("ship5", "on");
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 4300);
			Money.text = PlayerPrefs.GetInt("Money").ToString();
		}
		
	}
	public void S6()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		if (PlayerPrefs.GetInt("Money") >= 5300)
		{
			PlayerPrefs.SetString("ship6", "on");
			PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 5300);
			Money.text = PlayerPrefs.GetInt("Money").ToString();
		}
		
	}
	public void Exit()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		PlayerPrefs.SetString("Mode", "Menu");
	}
}
