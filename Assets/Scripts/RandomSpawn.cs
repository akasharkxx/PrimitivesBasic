using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject spawnItemPrefab;

    public int minItems = 3;

    private bool[] isUsed;
    private int index, limit;

    private void Start()
    {
        isUsed = new bool[spawnPoints.Length];
        MakeEveryPositionFree();

        limit = minItems + Random.Range(0, isUsed.Length - minItems);

        for(int i = 0; i < limit; i++)
        {
            GetNextRandomPosition();
            GameObject newSpawnItem = Instantiate(spawnItemPrefab, spawnPoints[index].position, spawnPoints[i].rotation);
            newSpawnItem.transform.SetParent(this.transform);
        }
    }

    private void GetNextRandomPosition()
    {
        index = Random.Range(0, isUsed.Length);
        while(isUsed[index] == true)
        {
            index = Random.Range(0, isUsed.Length);
        }
        isUsed[index] = true;
    }

    private void MakeEveryPositionFree()
    {
        for (int i = 0; i < isUsed.Length; i++)
        {
            isUsed[i] = false;
        }
    }
}
