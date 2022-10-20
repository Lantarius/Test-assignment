using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private GameObject spawn;
    public float speed;
    public float distance;
    private GameManager gameManager;
    float DistanceToSpawn()
    {
        spawn = GameObject.Find("Spawn");
        float DistanceToSpawn = Vector3.Distance(spawn.transform.position, transform.position);
        return DistanceToSpawn;
    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        transform.Translate(Vector3.forward * gameManager.speed * Time.deltaTime);
        if (DistanceToSpawn() > gameManager.distance)
        {
            Destroy(gameObject);
        }
    }
}

