using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType {
    None,
    Random,
    Follow,
    Away
}

public class EnemyMove : MonoBehaviour
{
    public MoveType MoveType;
    public int Speed;
    public int Delay = 2;
    float delayChecker;
    Vector2 direction;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHp>().transform;
        delayChecker = Delay + 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 너무 멀면 움직이지 않음
        if ((player.position - transform.position).magnitude > 20) return;

        delayChecker += Time.deltaTime;

        if (delayChecker > Delay) {
            if (MoveType == MoveType.Random) {
                direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                direction *= Random.Range(0, 1f);
            }
            delayChecker = 0;
        }
        else if (MoveType == MoveType.Follow || MoveType == MoveType.Away) {
            var playerPos = FindObjectOfType<PlayerHp>().transform.position;
            direction = (playerPos - transform.position).normalized;
            if (MoveType == MoveType.Away) {
                direction *= -1;
            }
        }

        transform.position += (Vector3)direction * Speed * Time.deltaTime;
    }
}
