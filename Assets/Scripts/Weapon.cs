using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // 총 이름
    public string WeaponName;
    // 이미지
    public Sprite WeaponImage;
    // 총알
    public GameObject Bullet;
    // 발당 데미지
    public int Damage;
    // 총알 속도
    public int Speed;
    // 탄창 수 (-1 이면 무한)
    public int BulletCount;
}
