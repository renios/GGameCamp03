using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
   
public class PlayerShot : MonoBehaviour
{
    public Weapon MainWeapon;
    public Weapon SubWeapon;
    public SpriteRenderer WeaponSR;

    public int BulletCount = 300;
    int currentBulletCount;

    public Image WeaponImage;
    public Text BulletText;
    public Image BulletBar;

    void Shot() {
        if (currentBulletCount <= 0) return;

        var focusPosition = FindObjectOfType<Focus>().transform.position;
        var normalizedVector = (focusPosition - transform.position).normalized;

        var newBullet = Instantiate(MainWeapon.Bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Bullet>().Direction = normalizedVector;
        newBullet.GetComponent<Bullet>().Speed = MainWeapon.Speed;
        newBullet.GetComponent<Bullet>().Damage = MainWeapon.Damage;

        currentBulletCount = currentBulletCount - 1;
        BulletText.text = currentBulletCount + "/" + BulletCount;
        BulletBar.fillAmount = currentBulletCount / (float)BulletCount;
    }

    void ChangeWeapon() {
        if (SubWeapon == null) return;

        var weapon = SubWeapon;
        SubWeapon = MainWeapon;
        MainWeapon = weapon;

        WeaponSR.sprite = MainWeapon.WeaponImage;
        WeaponImage.sprite = MainWeapon.WeaponImage;
    }

    // Start is called before the first frame update
    void Start()
    {
        WeaponSR.sprite = MainWeapon.WeaponImage;
        WeaponImage.sprite = MainWeapon.WeaponImage;

        currentBulletCount = BulletCount;
        BulletText.text = currentBulletCount + "/" + BulletCount;
        BulletBar.fillAmount = currentBulletCount / (float)BulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shot();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))
        {
            ChangeWeapon();
        }
    }
}
