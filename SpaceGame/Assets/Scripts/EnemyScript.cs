using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{
    float speed=0.01f;
    public Text Money;
    int health = 3;
    public GameObject Shoot;
    public GameObject Gun;
    float newShoot;
    public float pauseShoot;
    void Start()
    {
  
        Money.text = PlayerPrefs.GetInt("Money").ToString();
    }


    void Update()
    {
        if (PlayerPrefs.GetString("Mode") == "Playing")
        {
   
            transform.position = new Vector3(transform.position.x+speed, transform.position.y, transform.position.z);

            if (transform.position.x >= 2.7f || transform.position.x <= -2.7f)
            {
     speed *= -1;
            }
           
            if (newShoot < Time.time)   //спавн пулек
            {
                Instantiate(Shoot, Gun.transform.position, Quaternion.identity);
                newShoot = Time.time + pauseShoot;
                if (transform.position.x >= -3f)
                {
  GameObject.Find("EnemyAttack").GetComponent<AudioSource>().Play();
                }
                  
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
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
