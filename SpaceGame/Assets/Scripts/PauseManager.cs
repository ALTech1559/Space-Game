using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
	public GameObject PausePanel;
	bool pause = false;
	public void Pause()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		if (pause == false)
		{
			PausePanel.SetActive(true);
			pause = true;
			PlayerPrefs.SetString("Mode", "Pause");
		}
		else
		{
			PausePanel.SetActive(false);
			pause = false;
			PlayerPrefs.SetString("Mode", "Playing");
		}

	}
	public void Exit()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		Application.Quit();
	}
	public void Restart()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		SceneManager.LoadScene("SampleScene");
		PlayerPrefs.SetString("Mode", "Menu");
	}
	public void Shop()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		PlayerPrefs.SetString("Mode", "Shop");
	}
	public void Resume()
	{
		GameObject.Find("Tap").GetComponent<AudioSource>().Play();
		pause = false;
		PausePanel.SetActive(false);
		PlayerPrefs.SetString("Mode", "Playing"); 
	}

}
