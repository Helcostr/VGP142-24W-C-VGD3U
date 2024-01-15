using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnd : MonoBehaviour {
    GameManager gameManager;
    // Start is called before the first frame update
    void Start() {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) gameManager.Finish();
    }
}