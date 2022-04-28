using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_generator : MonoBehaviour
{
    int nextStep = 10;

    public Transform Player;
    public Transform Map_Parent;
    public Transform garbage_Parent;
    public Transform Obstacle_Parent;
    public GameObject[] Tiles;
    [SerializeField] GameObject[] garbagePrefab;

    [SerializeField] GameObject[] ObstaclePrefab;

    [SerializeField]
    int TilesNum = 10;

    private List<GameObject> activeRoad;

    [SerializeField] float[] laneOffset;

    private void Start()
    {
        activeRoad = new List<GameObject>();
        Time.timeScale = 1.0f;

        for (int i = 0; i < TilesNum; i++)
        {
            SpawnPrefab();

        }
        StartCoroutine(StartSpawning());
        StartCoroutine(startSpawningObstacle());
    }
    void Update()
    {
        if (Player.position.z - 10 > nextStep - (TilesNum*10))
        {
            SpawnPrefab();
            RemovePrefab();
        }

    }
    void SpawnPrefab()
    {
        GameObject Go;
        Go = Instantiate(Tiles[Random.Range(0, Tiles.Length)], new Vector3(0, 0, transform.position.z + nextStep), Quaternion.identity, Map_Parent);
        nextStep += 10;
        activeRoad.Add(Go);
    }
    void RemovePrefab()
    {
        Destroy(activeRoad[0]);
        activeRoad.RemoveAt(0);
    }

    IEnumerator StartSpawning()
    {
      //  yield return new WaitForSeconds(1);
        while(true)
        {
            SpawnGarbage();
            yield return new WaitForSeconds(2f);
        }
    }
    private void SpawnGarbage()
    {
        GameObject go;
        go = Instantiate(garbagePrefab[Random.Range(0,garbagePrefab.Length)], new Vector3(laneOffset[Random.Range(1,laneOffset.Length)],1, transform.position.z+nextStep), Quaternion.identity,garbage_Parent);
        Destroy(go, 20f);
    }

    IEnumerator startSpawningObstacle()
    {
        yield return new WaitForSeconds(5f);

        while(true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(1.5f);
        }
    }
    private void SpawnObstacle()
    {
        GameObject go;
        go = Instantiate(ObstaclePrefab[Random.Range(0, ObstaclePrefab.Length)], new Vector3(laneOffset[Random.Range(1, laneOffset.Length)], 0, transform.position.z + nextStep), Quaternion.identity,Obstacle_Parent);
        Destroy(go, 20f);
    }
}
