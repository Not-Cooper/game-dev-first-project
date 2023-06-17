using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject pipe;
    [SerializeField] private float spawnRate = 2;
    [SerializeField] private float offSet = 0;
    [SerializeField] private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - offSet;
        float highestPoint = transform.position.y + offSet;
        float yPosition = Random.Range(lowestPoint, highestPoint);
        Instantiate(pipe, new Vector3(transform.position.x, yPosition, 0), transform.rotation);
    }
}
