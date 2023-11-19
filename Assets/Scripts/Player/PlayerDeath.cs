using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Object explosionRef;

    private void Start()
    {
        explosionRef = Resources.Load("EnemyExplosion");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MoleEnemy") ||
            collision.gameObject.CompareTag("TreeEnemy") ||
            collision.gameObject.CompareTag("ModifiedTreeEnemy"))
        {
            var explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = this.transform.position;

            var spawners = GameObject.FindGameObjectsWithTag("Spawner");

            var moleEnemies = GameObject.FindGameObjectsWithTag("MoleEnemy");
            var treeEnemies = GameObject.FindGameObjectsWithTag("TreeEnemy");
            var modifiedTreeEnemies = GameObject.FindGameObjectsWithTag("ModifiedTreeEnemy");

            foreach (var spawner in spawners)
                Destroy(spawner.gameObject);

            foreach (var enemy in moleEnemies)
                Destroy(enemy.gameObject);

            foreach (var enemy in treeEnemies)
                Destroy(enemy.gameObject);

            foreach (var enemy in modifiedTreeEnemies)
                Destroy(enemy.gameObject);

            Destroy(this.gameObject);

            //Carregar menu de game over.
        }
    }
}
