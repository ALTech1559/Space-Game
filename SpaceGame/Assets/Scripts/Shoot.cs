using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
  public   List<Sprite> shoots = new List<Sprite>();
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = shoots[Random.Range(0, 5)];
    }
    void Update()
    {
        if (PlayerPrefs.GetString("Mode") == "Playing")
        {
 transform.position =transform.position+ Vector3.up * 0.03f;
        }
           
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Destroy"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);

        }
    }
}
