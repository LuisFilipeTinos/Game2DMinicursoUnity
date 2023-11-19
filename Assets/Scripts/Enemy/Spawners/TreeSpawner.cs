using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField] GameObject treePrefab;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 7)
        {
            var tree = (GameObject)Instantiate(treePrefab);
            tree.transform.position = this.transform.position;
            time = 0;
        }
    }
}
