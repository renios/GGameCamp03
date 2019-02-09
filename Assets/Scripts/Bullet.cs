using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 Direction;
    public float Speed = 10;
    public int Damage = 1;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHp>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)Direction * Speed * Time.deltaTime;

        if ((player.position - transform.position).magnitude > 20) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag != "Player" && other.tag != "Enemy") {
            if (other.tag == "Item") return;
            Destroy(gameObject);
        }
    }
}
