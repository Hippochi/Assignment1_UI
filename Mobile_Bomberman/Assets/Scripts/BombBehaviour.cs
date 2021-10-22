//BombBehaviour by Alex Dine
//101264627 on Sept 26th
//Controls bomb explosion placement
//v1.0
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public float boomTime = 1.5f;

    public BombBlockerBehaviour upDetector;
    public BombBlockerBehaviour downDetector;
    public BombBlockerBehaviour leftDetector;
    public BombBlockerBehaviour rightDetector;
    public BombBlockerBehaviour upFarDetector;
    public BombBlockerBehaviour downFarDetector;
    public BombBlockerBehaviour leftFarDetector;
    public BombBlockerBehaviour rightFarDetector;
    public AudioClip boomAudios;

    public GameObject vertExp;
    public GameObject horiExp;

    void Start()
    {
        StartCoroutine(goKaboom());
    }

    IEnumerator goKaboom()
    {
        yield return new WaitForSeconds(boomTime);
        makeExp();
        AudioSource.PlayClipAtPoint(boomAudios, Camera.main.transform.position);

        Destroy(this.gameObject);
    }

    void makeExp()
    {
        GameObject vertOne = Instantiate(vertExp, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        GameObject horiOne = Instantiate(horiExp, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;

        if (upDetector.getBlocked() == false)
        {
            GameObject vertPosOne = Instantiate(vertExp, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.Euler(0, 0, 0)) as GameObject;
            if (upFarDetector.getBlocked() == false)
            {
                GameObject vertPosTwo = Instantiate(vertExp, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }

        if (downDetector.getBlocked() == false)
        {
            GameObject vertNegOne = Instantiate(vertExp, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.Euler(0, 0, 0)) as GameObject;
            if (downFarDetector.getBlocked() == false)
            {
                GameObject vertNegTwo = Instantiate(vertExp, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }

        if (rightDetector.getBlocked() == false)
        {
            GameObject horiPosOne = Instantiate(horiExp, new Vector2(transform.position.x + 0.5f, transform.position.y), Quaternion.Euler(0, 0, 0)) as GameObject;
            if (rightFarDetector.getBlocked() == false)
            {
                GameObject horiPosTwo = Instantiate(horiExp, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }

        if (leftDetector.getBlocked() == false)
        {
            GameObject horiNegOne = Instantiate(horiExp, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.Euler(0, 0, 0)) as GameObject;
            if (leftFarDetector.getBlocked() == false)
            {
                GameObject horiNegTwo = Instantiate(horiExp, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }

    }
}
