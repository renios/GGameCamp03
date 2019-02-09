using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public int Hp = 10;
    int currentHp;
    public Image HpBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = Hp;
        HpBar.fillAmount = currentHp / (float)Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp == 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentHp > 0)
            {
                currentHp = currentHp - 1;
                HpBar.fillAmount = currentHp / (float)Hp;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Bullet")
        {
            currentHp = currentHp - other.GetComponent<Bullet>().Damage;
            Destroy(other.gameObject);
            HpBar.fillAmount = currentHp / (float)Hp;
        }
    }
}

