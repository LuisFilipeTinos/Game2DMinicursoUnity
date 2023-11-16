using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    async void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        await WaitToSetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    private async Task WaitToSetSpeed()
    {
        await Task.Delay(150);
    }
}
