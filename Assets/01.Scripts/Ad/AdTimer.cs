using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdTimer : MonoBehaviour
{
    public bool canAd = false;
    public float adTimer;
    public bool canTime = true;

    void Update()
    {
        if (canTime)
            adTimer += Time.deltaTime;

        if (adTimer >= 90)
        {
            canAd = true;
            canTime = false;
            adTimer = 0;
        }
    }
}
