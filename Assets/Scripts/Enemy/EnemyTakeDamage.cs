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

    private int enemyLife;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.tag == "MoleEnemy")
            enemyLife = 3;

        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        sr = GetComponent<SpriteRenderer>();
        whiteFlashMaterial = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        defaultMaterial = sr.material;
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
                //Instancia a explosão;
                
                Destroy(this.gameObject);
            }
        }
    }

    private async Task FlashSprite()
    {
        sr.material = whiteFlashMaterial;
        await Task.Delay(150);
        sr.material = defaultMaterial;
    }
}
