using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdscript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D birdBody;
    [SerializeField] private float flapStrength = 0;
    [SerializeField] private LogicScript logic;
    private bool birdIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -7.9 || transform.position.y >= 7.9)
        {
            if (birdIsAlive)
            {
                Die();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            birdBody.velocity = Vector2.up * flapStrength;
        }

        birdBody.rotation = -(birdBody.velocity.magnitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void Die()
    {
        FindAnyObjectByType<AudioManager>().Stop("Theme");
        FindAnyObjectByType<AudioManager>().Play("Dead");
        birdIsAlive = false;
        logic.gameOver();
        Time.timeScale = 0;
    }
}
