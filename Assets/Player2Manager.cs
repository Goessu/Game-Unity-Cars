﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player2Manager : MonoBehaviour
{
    public bool ischaozasso2 = false;
    public bool morte;
    public bool hit;
    public float Timer;
    public float Count;
    public bool atacando = true;
    public float speed;
    public float knockback;
    Rigidbody2D body;
    [SerializeField]
    public GameObject golpe;
    [SerializeField]
    public GameObject P1win;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        Count = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        Pulo();
        Timer = Time.deltaTime;
        float move = Input.GetAxis("Horizontal2");

        body.velocity = new Vector2(move * speed, body.velocity.y);

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal2") < 0)
        {
            characterScale.x = 10;   
        }
        if (Input.GetAxis("Horizontal2") > 0)
        {
            characterScale.x = -10;
        }
        transform.localScale = characterScale;

        if (atacando == true && Count >= 0)
        {
            
            Count -= 1.0f * Timer;

            if (Count <= 0)
            {
                atacando = false;
            }
        }
        else if (atacando == false)
        {
            Count = 1.2f;
        }

















        if (Input.GetKeyDown(KeyCode.U))
        {

            if (atacando == true && Count >= 0)
            {
                golpe.SetActive(false);
                atacando = false;
                
            }
            else if (atacando == false)
            {
                golpe.SetActive(true);
                atacando = true;
                
            }
        }
        if (morte == true)
        {
            P1win.SetActive(true);
        }
    }
    void Pulo()
    {
        if (Input.GetButtonDown("Jump2") && ischaozasso2 == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "end")
        {
            morte = true;
        }
    }
}
