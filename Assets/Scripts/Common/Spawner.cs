using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform[] spawnPoints;

    private WaitForSeconds waitForSeconds;
    
    private IEnumerator Start()
    {
        waitForSeconds = new WaitForSeconds(1f);
        while (true)
        {
            yield return waitForSeconds;
            for (int i = 0; i < prefabs.Length; i++)
            {
                Instantiate(prefabs[i], spawnPoints[i].position, spawnPoints[i].rotation);
            }
        }
    }
}
