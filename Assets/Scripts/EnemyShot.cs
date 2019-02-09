using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType {
    None,
    Random,
    Follow
}

public class EnemyShot : MonoBehaviour
{
    public AttackType AttackType;
    public int Damage;
    public int Speed;
    public float Delay;
    float delayChecker;
    public Vector2 Direction;
    Transform player;
    public GameObject Bullet;

    void Shot() {
        var newBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Bullet>().Speed = Speed;
        newBullet.GetComponent<Bullet>().Damage = Damage;

        if (AttackType == AttackType.Follow) {
            var normalizedVector = (player.position - transform.position).normalized;
            newBullet.GetComponent<Bullet>().Direction = normalizedVector;
        }
        else if (AttackType == AttackType.Random) {
            var newDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            newBullet.GetComponent<Bullet>().Direction = newDirection;
        }
        else {
            newBullet.GetComponent<Bullet>().Direction = Direction;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHp>().transform;
        delayChecker = Delay + 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 너무 멀면 쏘지 않음
        if ((player.position - transform.position).magnitude > 40) return;

        delayChecker += Time.deltaTime;

        if (delayChecker > Delay) {
            Shot();
            delayChecker = 0;
        }
    }
}
