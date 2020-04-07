using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static int health = 3;
    public GameObject Shoot;
    public GameObject Gun;
    public GameObject PlayingPanel;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Boss;

    public GameObject Health;

    Vector2 startPos;
    Vector2 inputVector;
    SpriteRenderer render;
    Vector3 lastMousePos = Vector3.zero;
    Vector3 touchDelta = new Vector3(0f, 0f, 0f);

    int color = 1;

    float newShoot;
    public float pauseShoot;
    float nextNlo;
    public float pauseNlo;
    float nextEn4;
    public float pauseEn4;
    float nextEn2;
    public float pauseEn2;
    float nextEn3;
    public float pauseEn3;
    float nextBoss;
    public float pauseBoss;
    bool isScrolling = false;
    void Start()
    {
        color = 1;
        PlayerPrefs.SetString("Boss", "off");
        nextEn4 = Time.time+ pauseEn4;
        nextEn3 = Time.time+ pauseEn3;
        nextEn2 = Time.time+ pauseEn2;
        nextBoss = Time.time + pauseBoss;
        health = 3;
        PlayerPrefs.SetString("Mode", "Menu");
    }


    void Update()
    {
        if (PlayerPrefs.GetString("Mode") == "Playing")
        {
            if (health <= 0)
            {
                GameObject.Find("PlayerDeath").GetComponent<AudioSource>().Play();
                PlayerPrefs.SetString("Mode", "Death");
            }




            PlayingPanel.SetActive(true); // движение  за пальцем
        if (Input.GetMouseButtonDown(0))
        {
            {
                isScrolling = true;
                lastMousePos = Input.mousePosition;
                touchDelta = Vector3.zero;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isScrolling = false;
            touchDelta = Vector3.zero;
            lastMousePos = Vector3.zero;
        }

        Vector3 newMousePos = Input.mousePosition;
        if (isScrolling)
        {
            touchDelta = newMousePos - lastMousePos;
            lastMousePos = newMousePos;
        }
            transform.position += new Vector3(touchDelta.x * 0.007f, touchDelta.y * 0.007f, 0f);




          float newX=  Mathf.Clamp(transform.position.x, -2.7f, 2.7f); //ограничение движения
            float newY = Mathf.Clamp(transform.position.y, -4.47f, -1.27f);
            transform.position= new Vector3 (newX,newY, transform.position.z);




            if (newShoot < Time.time)   //спавн пулек
            {

                Instantiate(Shoot, new Vector3(Gun.transform.position.x, Gun.transform.position.y,0), Quaternion.identity);
               
                newShoot = Time.time + pauseShoot;
                GameObject.Find("PlayerAttack").GetComponent<AudioSource>().Play();
            }

            if (nextNlo < Time.time )   //спавн нло
            {
                Instantiate(Enemy1, new Vector3(Random.Range(-2.4f,2.5f),Random.Range(1.15f, 2.5f),0), Quaternion.identity);
                nextNlo = Time.time + pauseNlo;
            }
            if (nextEn4 < Time.time)   //спавн нло
            {
                Instantiate(Enemy4, new Vector3(Random.Range(-2f, 2f), Random.Range(3f,3.9f),0), Quaternion.identity);
                nextEn4 = Time.time + pauseEn4;
            }

            if (nextEn2 < Time.time )   //спавн нло
            {
                Instantiate(Enemy2, new Vector3(Random.Range(-2f, 2f), Random.Range(3f, 3.9f),0), Quaternion.identity);
                nextEn2 = Time.time + pauseEn2;
            }

            if (nextEn3 < Time.time)   //спавн нло
            {
                Instantiate(Enemy3, new Vector3(Random.Range(-2f, 2f), Random.Range(3f, 3.9f),0), Quaternion.identity);
                nextEn3 = Time.time + pauseEn3;
            }

            if (nextBoss < Time.time )   //спавн нло
            {
                Instantiate(Boss, new Vector3(0, 2.6f,0), Quaternion.identity);
                nextBoss = Time.time + pauseBoss;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            health--;
            Health.transform.localScale = new Vector3(Mathf.Lerp(Health.transform.localScale.x * 0.5f, Health.transform.localScale.x, Time.deltaTime * 10), Health.transform.localScale.y, Health.transform.localScale.z);
        }
    }
}
