using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject PlayingCanvas;
    public GameObject ShopCanvas;
    public GameObject DeathCanvas;
    public GameObject Player;
    int i = 0;
    public List<GameObject> ships = new List<GameObject>();
    public List<Sprite> ships2 = new List<Sprite>();
    public List<GameObject> blockers = new List<GameObject>();
    public void Start()
    {
        PlayerPrefs.SetInt("Pick", 0);
        PlayerPrefs.SetString("Mode", "Menu");
        if (PlayerPrefs.GetString("ship2") == "on")
        {
            blockers[0].SetActive(false);
        }
        if (PlayerPrefs.GetString("ship3") == "on")
        {
            blockers[1].SetActive(false);
        }
        if (PlayerPrefs.GetString("ship4") == "on")
        {
            blockers[2].SetActive(false);
        }
        if (PlayerPrefs.GetString("ship5") == "on")
        {
            blockers[3].SetActive(false);
        }
        if (PlayerPrefs.GetString("ship6") == "on")
        {
            blockers[4].SetActive(false);
        }

    }
    private void Update()
    {
        if (PlayerPrefs.GetString("Mode") == "Menu")
        {
            MenuCanvas.SetActive(true);
            PlayingCanvas.SetActive(false);
            ShopCanvas.SetActive(false);
            DeathCanvas.SetActive(false);
        }
        if (PlayerPrefs.GetString("Mode") == "Shop")
        {
            MenuCanvas.SetActive(false);
            PlayingCanvas.SetActive(false);
            ShopCanvas.SetActive(true);
            DeathCanvas.SetActive(false);
        }
        if (PlayerPrefs.GetString("Mode") == "Death")
        {
            MenuCanvas.SetActive(false);
            PlayingCanvas.SetActive(false);
            ShopCanvas.SetActive(false);
            DeathCanvas.SetActive(true);
        }
        if (PlayerPrefs.GetString("Mode") == "Playing")
        {
            MenuCanvas.SetActive(false);
            PlayingCanvas.SetActive(true);
            ShopCanvas.SetActive(false);
            DeathCanvas.SetActive(false);
        }
    }
    public void Exit()
    {
        GameObject.Find("Tap").GetComponent<AudioSource>().Play();
        Application.Quit();
    }
    public void Shop()
    {
        GameObject.Find("Tap").GetComponent<AudioSource>().Play();
        ShopCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
        PlayingCanvas.SetActive(false);
        PlayerPrefs.SetString("Mode", "Shop");
    }
    public void Play()
    {
        GameObject.Find("Tap").GetComponent<AudioSource>().Play();
        ShopCanvas.SetActive(false);
        MenuCanvas.SetActive(false);
        PlayingCanvas.SetActive(true);
        PlayerPrefs.SetString("Mode", "Playing");
        switch (PlayerPrefs.GetInt("Pick"))
        {
            case 0:
             Player.GetComponent<SpriteRenderer>().sprite = ships2[PlayerPrefs.GetInt("Pick")];
                break;
            case 1:
                if (PlayerPrefs.GetString("ship2") == "on")
                {
               Player.GetComponent<SpriteRenderer>().sprite = ships2[PlayerPrefs.GetInt("Pick")];
                }
                else
                {
                    Player.GetComponent<SpriteRenderer>().sprite = ships2[0];
                }
                break;
            case 2:
                if (PlayerPrefs.GetString("ship3") == "on")
                {
                    Player.GetComponent<SpriteRenderer>().sprite = ships2[PlayerPrefs.GetInt("Pick")];
                }
                else
                {
                    Player.GetComponent<SpriteRenderer>().sprite = ships2[0];
                }
                break;
            case 3:
                if (PlayerPrefs.GetString("ship4") == "on")
                {
                    Player.GetComponent<SpriteRenderer>().sprite = ships2[PlayerPrefs.GetInt("Pick")];
                }
                else
                {
                    Player.GetComponent<SpriteRenderer>().sprite = ships2[0];
                }
                break;
            case 4:
                if (PlayerPrefs.GetString("ship5") == "on")
                {
                    Player.GetComponent<SpriteRenderer>().sprite = ships2[PlayerPrefs.GetInt("Pick")];
                }
                else
                {
                    Player.GetComponent<SpriteRenderer>().sprite = ships2[0];
                }
                break;
            case 5:
                if (PlayerPrefs.GetString("ship6") == "on")
                {
                    Player.GetComponent<SpriteRenderer>().sprite = ships2[PlayerPrefs.GetInt("Pick")];
                }
                else
                {
                    Player.GetComponent<SpriteRenderer>().sprite = ships2[0];
                }
                break;
        }
       
    }
    public void Right()
    {
        GameObject.Find("Tap").GetComponent<AudioSource>().Play();
        ships[0].SetActive(false);
        ships[1].SetActive(false);
        ships[2].SetActive(false);
        ships[3].SetActive(false);
        ships[4].SetActive(false);
        ships[5].SetActive(false);


        PlayerPrefs.SetInt("Pick", PlayerPrefs.GetInt("Pick") + 1);
        if (PlayerPrefs.GetInt("Pick") == 6)
        {
            PlayerPrefs.SetInt("Pick",0);
        }
        ships[PlayerPrefs.GetInt("Pick")].SetActive(true);
    }
        
   
       public void Left()
     {
        GameObject.Find("Tap").GetComponent<AudioSource>().Play();
        ships[0].SetActive(false);
    ships[1].SetActive(false);
    ships[2].SetActive(false);
    ships[3].SetActive(false);
    ships[4].SetActive(false);
    ships[5].SetActive(false);

    PlayerPrefs.SetInt("Pick", PlayerPrefs.GetInt("Pick") - 1);
        if (PlayerPrefs.GetInt("Pick") == -1)
        {
            PlayerPrefs.SetInt("Pick", 5);
        }
        ships[PlayerPrefs.GetInt("Pick")].SetActive(true);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Mode", "Pause");
    }
}
