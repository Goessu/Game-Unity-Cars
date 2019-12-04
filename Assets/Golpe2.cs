using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe2 : MonoBehaviour
{
    public float knockback;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        knockback = Random.Range(-1.0f, -1.4f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = new Vector2(other.transform.position.x + knockback, other.transform.position.y);
        }
    }
}