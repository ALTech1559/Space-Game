using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject Line;
    float speed = 0.01f;
    public Text Money;
    int health = 30;
    public GameObject Shoot;
    public GameObject Gun;
    float newShoot;
    public float pauseShoot;
    void Start()
    {
        Money.text = PlayerPrefs.GetInt("Money").ToString();
        PlayerPrefs.SetString("Boss", "on");
    }


    void Update()
    {
        if (PlayerPrefs.GetString("Mode") == "Playing")
        {

            if (newShoot < Time.time)   //спавн пулек
            {  
                if (transform.position.x >= -2.7f)
                {
                Instantiate(Shoot, new Vector3 (Random.Range(-2.4f, 2.5f), Gun.transform.position.y, Gun.transform.position.z), Quaternion.identity);
                newShoot = Time.time + pauseShoot;
           
                    GameObject.Find("BossAttack").GetComponent<AudioSource>().Play();
                }
              
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shoot"))
        {
          
            health--;
            Line.transform.localScale = new Vector3(Mathf.Lerp(Line.transform.localScale.x * 0.8f, Line.transform.localScale.x, Time.deltaTime * 10), Line.transform.localScale.y, Line.transform.localScale.z);
            if (health == 0)
            {
            
                PlayerPrefs.SetString("Boss", "off");
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 100);
                GameObject.Find("TakeCoin").GetComponent<AudioSource>().Play();
                Money.text = PlayerPrefs.GetInt("Money").ToString();
                Destroy(this.gameObject);
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
