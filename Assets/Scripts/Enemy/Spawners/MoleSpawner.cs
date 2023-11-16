using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{

    [SerializeField] GameObject molePrefab;

    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 2)
        {
            var mole = (GameObject)Instantiate(molePrefab);
            mole.transform.position = this.transform.position;
            time = 0;
        }
    }
}
