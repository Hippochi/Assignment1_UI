//PlayerBehaviour by Alex Dine
//101264627 on Sept 26th
//Moves player, tracks lives and creates audio + bomb placement
//v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float playerSpeed = 3f;

    public bool isRight;
    public bool isLeft;
    public bool isUp;
    public bool isDown;
    public int lives;

    public GameObject BombPref;

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public AudioClip HurtAudios;
    public AudioClip pickupAudios;
    public Animator animator;


    private void Start()
    {
        isRight = false;
        isLeft = false;
        isUp = false;
        isDown = false;
        lives = 3;
        life1.SetActive(true);
        life2.SetActive(true);
        life3.SetActive(true);
    }

    void Update()
    { 

        if (isRight)
        {
            transform.position = new Vector2(transform.position.x + playerSpeed * Time.deltaTime, transform.position.y);
            animator.SetFloat("Speed", 1);
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
        }

        else if (isLeft)
        {
            transform.position = new Vector2(transform.position.x + -1 * playerSpeed * Time.deltaTime, transform.position.y);
            animator.SetFloat("Speed", 1);
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);
        }

        if (isUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + playerSpeed * Time.deltaTime);
            animator.SetFloat("Speed", 1);
            animator.SetFloat("Vertical", 1);
        }

        else if (isDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + -1 * playerSpeed * Time.deltaTime);
            animator.SetFloat("Speed", 1);
            animator.SetFloat("Vertical", -1);
        }
        
        if (lives < 3 )
        {
            life3.SetActive(false);
        }

        if (lives <2)
        {
            life2.SetActive(false);
        }

        if (lives < 1)
        {
            life1.SetActive(false);
        }

        if (!isDown && !isLeft && !isRight && !isUp) { animator.SetFloat("Speed", 0); }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            lives--;
            AudioSource.PlayClipAtPoint(HurtAudios, Camera.main.transform.position);
        }

        //if (col.gameObject.tag == "Box")
        //{
            
        //    ScoreCounter.instance.curScore += 5;
        //    Destroy(col.gameObject);
        //}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            lives--;
            AudioSource.PlayClipAtPoint(HurtAudios, Camera.main.transform.position);
        }

        if (col.gameObject.tag == "Box")
        {
            ScoreCounter.instance.curScore += 5;
            Destroy(col.gameObject);
            AudioSource.PlayClipAtPoint(pickupAudios, Camera.main.transform.position);

        }
    }


    public void moveRight() { isRight = true; }
    public void stopRight() { isRight = false; }

    public void moveLeft() { isLeft = true; }
    public void stopLeft() { isLeft = false; }

    public void moveUp() { isUp = true; }
    public void stopUp() { isUp = false; }

    public void moveDown() { isDown = true; }
    public void stopDown() { isDown = false; }

    public void dropBomb()
    {
        GameObject kaBoom = Instantiate(
            BombPref, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
}
