using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public int Hp = 10;
    int currentHp;
    public Text HpText;
    public Image HpBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = Hp;
        HpText.text = currentHp + "/" + Hp;
        HpBar.fillAmount = currentHp / (float)Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp == 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentHp > 0)
            {
                currentHp = currentHp - 1;
                HpText.text = currentHp + "/" + Hp;
                HpBar.fillAmount = currentHp / (float)Hp;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentHp = currentHp - 1;
            HpText.text = currentHp + "/" + Hp;
            HpBar.fillAmount = currentHp / (float)Hp;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "EnemyBullet")
        {
            currentHp = currentHp - other.GetComponent<Bullet>().Damage;
            Destroy(other.gameObject);
            HpText.text = currentHp + "/" + Hp;
            HpBar.fillAmount = currentHp / (float)Hp;
        }
    }
}

