using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplode : MonoBehaviour
{
    private Object bulletExplosionRef;

    // Start is called before the first frame update
    void Start()
    {
        bulletExplosionRef = Resources.Load("BulletExplosion");    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collider") || collision.gameObject.CompareTag("MoleEnemy") || 
            collision.gameObject.CompareTag("TreeEnemy") || collision.gameObject.CompareTag("ModifiedTreeEnemy"))
        {
            var bulletExplosion = (GameObject)Instantiate(bulletExplosionRef);
            bulletExplosion.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -7);
            Destroy(this.gameObject);
        }
    }
}
