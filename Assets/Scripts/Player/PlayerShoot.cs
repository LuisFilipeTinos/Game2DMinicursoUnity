using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Object bulletRef;
    private bool canPressSpace;

    // Start is called before the first frame update
    void Start()
    {
        canPressSpace = true;
        bulletRef = Resources.Load("Bullet");
    }

    // Update is called once per frame
    async void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & canPressSpace)
        {
            canPressSpace = false;
            var bullet = (GameObject)Instantiate(bulletRef);
            bullet.transform.position = this.transform.position;
            await WaitToShootAgain();
        }
    }

    private async Task WaitToShootAgain()
    {
        await Task.Delay(150);
        canPressSpace = true;
    }
}
