using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private int speed = 2;
    // Update is called once per frame
    void Update()
    {
            transform.Translate(-Vector2.left *  speed * Time.deltaTime);

    }
}
