using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    private GameObject spawn;
    private float spawnRate;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void SpawningCube()
    {
        StartCoroutine(Spawn());
    }
    public void StopSpawningCube()
    {
        StopAllCoroutines();
    }
    IEnumerator Spawn()
    {
        Instantiate(cube, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(gameManager.spawnRate);
        StartCoroutine(Spawn());
    }

}
