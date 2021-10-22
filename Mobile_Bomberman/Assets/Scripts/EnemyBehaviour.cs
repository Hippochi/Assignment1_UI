//EnemyBehaviour by Alex Dine
//101264627 on Sept 26th
//controls enemies AI and movement
//v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private GameObject player;
    private string direction;
    private Transform transform;
    public int animating;
    private Transform pTransform;
    public int speed;
    public bool movable;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pTransform = player.GetComponent<Transform>();
        transform = this.GetComponent<Transform>();
        movable = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (movable == true)
        {
            if (pTransform.position.y > transform.position.y && Mathf.Abs(pTransform.position.y - transform.position.y) > 0.2f )
            {
                animator.SetFloat("speed", 1);
                animator.SetFloat("Vert", 1);
                direction = "up";
            }
            else if (pTransform.position.y < transform.position.y && Mathf.Abs(pTransform.position.y - transform.position.y) > 0.2f)
            {
                animator.SetFloat("speed", 1);
                animator.SetFloat("Vert", -1);
                direction = "down";
            }
            else if (pTransform.position.x > transform.position.x && Mathf.Abs(pTransform.position.x - transform.position.x) > 0.2f)
            {
                animator.SetFloat("speed", 1);
                animator.SetFloat("Hori", 1);
                animator.SetFloat("Vert", 0);
                direction = "right";
            }
            else if (pTransform.position.x < transform.position.x && Mathf.Abs(pTransform.position.x - transform.position.x) > 0.2f)
            {
                animator.SetFloat("speed", 1);
                animator.SetFloat("Hori", -1);
                animator.SetFloat("Vert", 0);
                direction = "left";
            }

            movable = false;
            StartCoroutine(DirectionDelay());
        }

       if (direction == "up")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        else if (direction == "down")
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + -1 * speed * Time.deltaTime);
        }
        else if (direction == "left")
        {
            transform.position = new Vector2(transform.position.x + -1 * speed * Time.deltaTime, transform.position.y);
        }
        else if (direction == "right")
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(transform.root.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            Destroy(transform.root.gameObject);
            ScoreCounter.instance.curScore += 10;
        }
    }

    private IEnumerator DirectionDelay()
    {
        yield return new WaitForSeconds(0.5f);
        movable = true;
    }
}
