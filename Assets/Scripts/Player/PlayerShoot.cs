using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Object bulletRef;

    private Object bulletUpRef;
    private Object bulletDownRef;
    private Object bulletLeftRef;
    private Object bulletRightRef;

    private bool canPressZ;

    // Start is called before the first frame update
    void Start()
    {
        canPressZ = true;
        bulletRef = Resources.Load("Bullet");
        bulletUpRef = Resources.Load("BulletUp");
        bulletDownRef = Resources.Load("BulletDown");
        bulletLeftRef = Resources.Load("BulletLeft");
        bulletRightRef = Resources.Load("BulletRight");
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) & canPressZ)
        {
            canPressZ = false;
            var bullet = (GameObject)Instantiate(bulletRef);
            bullet.transform.position = this.transform.position;
            await WaitToShootAgain();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            var bulletUp = (GameObject)Instantiate(bulletUpRef);
            bulletUp.transform.position = this.transform.position;

            var bulletDown = (GameObject)Instantiate(bulletDownRef);
            bulletDown.transform.position = this.transform.position;

            var bulletLeft = (GameObject)Instantiate(bulletLeftRef);
            bulletLeft.transform.position = this.transform.position;

            var bulletRight = (GameObject)Instantiate(bulletRightRef);
            bulletRight.transform.position = this.transform.position;

            await WaitToContinueShooting();
        }
    }

    private async Task WaitToShootAgain()
    {
        await Task.Delay(150);
        canPressZ = true;
    }

    private async Task WaitToContinueShooting()
    {
        await Task.Delay(100);
    }
}
