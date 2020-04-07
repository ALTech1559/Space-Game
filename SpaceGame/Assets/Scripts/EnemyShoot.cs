using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public int damage;
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
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
          
            Health.transform.localScale = new Vector3(Mathf.Lerp(Health.transform.localScale.x*0.5f, Health.transform.localScale.x ,Time.deltaTime*10), Health.transform.localScale.y, Health.transform.localScale.z);
            PlayerScript.health-=damage;
            Destroy(this.gameObject);
        }
    }
}
