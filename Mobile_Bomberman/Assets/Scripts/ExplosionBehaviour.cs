//ExplosionBehaviour by Alex Dine
//101264627 on Sept 26th
//controls the explosion VFX
//v1.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float poofTime = 1f;

    void Start()
    {
        StartCoroutine(boomGoPoof());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator boomGoPoof()
    {
        yield return new WaitForSeconds(poofTime);

        Destroy(this.gameObject);
    }
}
