using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour {
    // Start is called before the first frame update

    [SerializeField]
    private string spawnTagString = "test_spawnpoint";
    private string spawnTag => gameObject.tag != "Untagged" ? gameObject.tag : spawnTagString;
    private List<GameObject> spawnPoints = new List<GameObject>();
    private List<GameObject> existingGameObjects = new List<GameObject>();
    [SerializeField]
    private List<GameObject> prefabs = new List<GameObject>();

    void Start() {
        updateSpawns();
        spawnWave();
    }

    // Update is called once per frame
    void spawnWave() {
        int prefabCount = prefabs.Count;
        if (prefabCount == 0) return;
        int i = 0;
        try {
            while (true) {
                GameObject spawnPoint = spawnPoints[i++];
                Instantiate(prefabs[UnityEngine.Random.Range(0, prefabCount)], spawnPoint.transform.position, spawnPoint.transform.rotation);
            }
        } catch (IndexOutOfRangeException e) {
            Debug.Log("We found all the spawners!" + e);
        }
    }

    void updateSpawns() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(spawnTag);
        if (spawnPoints.Count != 0)
            spawnPoints.Clear();
        int i = 0;
        try {
            while (true) {
                if (objs[i++] == gameObject) continue;
                spawnPoints.Add(objs[i]);
            }
        } catch (IndexOutOfRangeException e) {
            Debug.Log("We found all the spawners!" + e);
        }
    }
}
