using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedTreeeSpawner : MonoBehaviour
{
    [SerializeField] GameObject modifiedTreePrefab;

    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 15)
        {
            var modifiedTree = (GameObject)Instantiate(modifiedTreePrefab);
            modifiedTree.transform.position = this.transform.position;
            time = 0;
        }
    }
}
