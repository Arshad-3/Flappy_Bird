using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Bird : MonoBehaviour
{
    [SerializeField] private float speed=0.2f;
    [SerializeField] private float jumpforce = 5.5f;
    public static bool isAlive = true;
    private Rigidbody2D rb;
    private Animator ar;
    [SerializeField] private Image go, sb;
    [SerializeField] private Button play,menu;
    [SerializeField] private Text txt;



    void Start()
    {
        
        isAlive = true;
        rb=GetComponent<Rigidbody2D>();
        ar=GetComponent<Animator>();
        
        go.gameObject.SetActive(false);
        sb.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + speed, transform.position.y),0.1f);  works
        // transform.Translate(Vector2.right * Time.deltaTime*speed); work
        //rb.velocity = Vector2.right*speed;  doesnt work
        if(isAlive)
            //rb.velocity = new Vector2(speed,rb.velocity.y);

        Birdmovement();
        txt.text = GameManager.instance.Score.ToString();

    }

    void Birdmovement()
    {
        //rb.bodyType = RigidbodyType2D.Dynamic;
        if (Input.GetButtonDown("Jump") && isAlive)
            rb.velocity=new Vector2(0,jumpforce);
        
        Vector2 var = new Vector2(speed,rb.velocity.y);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0, Mathf.Atan2(var.y, var.x) * Mathf.Rad2Deg * 0.8f), Time.deltaTime*7f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("column"))
        {
            ar.SetBool("dead", true);
            isAlive = false;
            
            if (GameManager.instance.Score > GameManager.instance.HighScore)
            {
                GameManager.instance.HighScore = GameManager.instance.Score;
            }
            gameover();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreCounter"))
        {
            GameManager.instance.Score+=1;
        }
    }

    public void gameover()
    {
        go.gameObject.SetActive(true);
        sb.gameObject.SetActive(true);
        play.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        txt.gameObject.SetActive(false);
        Debug.Log(GameManager.instance.HighScore);
        StartCoroutine(StopTime());
    }
    
    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(0.5f);

        Time.timeScale = 0;
    }
}
