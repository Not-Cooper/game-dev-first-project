using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdscript : MonoBehaviour
{
    public Rigidbody2D birdBody;
    public float flapStrength = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "test";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            birdBody.velocity = Vector2.up * flapStrength;
        }
    }
}
