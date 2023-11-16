using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    private Material whiteFlashMaterial;
    private Material defaultMaterial;
    private SpriteRenderer sr;

    CameraShake cameraShake;

    Object enemyExplosionRef;

    private int enemyLife;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "MoleEnemy")
            enemyLife = 2;

        if (this.gameObject.tag == "TreeEnemy")
            enemyLife = 6;

        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        sr = GetComponent<SpriteRenderer>();
        whiteFlashMaterial = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        defaultMaterial = sr.material;
        enemyExplosionRef = Resources.Load("EnemyExplosion");
    }

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (enemyLife > 0)
            {
                enemyLife--;
                cameraShake.Shake();
                await FlashSprite();
            }
            else
            {
                var enemyExplosion = (GameObject)Instantiate(enemyExplosionRef);
                enemyExplosion.transform.position = this.transform.position;
                Destroy(this.gameObject);
            }
        }
    }

    private async Task FlashSprite()
    {
        SetMaterial(whiteFlashMaterial);
        await Task.Delay(150);
        SetMaterial(defaultMaterial);
    }

    private void SetMaterial(Material material)
    {
        if (sr != null)
            sr.material = material;
    }

}
