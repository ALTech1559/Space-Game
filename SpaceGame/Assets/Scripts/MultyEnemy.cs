using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultyEnemy : MonoBehaviour
{
    int health = 3;
    public Text Money;
    public GameObject Health;
    void Update()
    {
        if (PlayerPrefs.GetString("Mode") == "Playing")
        {
            transform.position = transform.position + Vector3.down * 0.01f;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
    
            Health.transform.localScale = new Vector3(Mathf.Lerp(Health.transform.localScale.x * 0.5f, Health.transform.localScale.x, Time.deltaTime * 10), Health.transform.localScale.y, Health.transform.localScale.z);
            PlayerScript.health--;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Shoot"))
        {
            Destroy(collision.gameObject);
            health--;
            if (health == 0)
            {
                Destroy(this.gameObject);
                if (Random.Range(0, 100) >= 60)
                {
                    PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 20);
                    GameObject.Find("TakeCoin").GetComponent<AudioSource>().Play();
                    Money.text = PlayerPrefs.GetInt("Money").ToString();
                }
            }
        }
    }
}
