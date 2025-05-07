using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;

    public Transform hpBar; // อ้างถึงแถบ HP 
    public GameObject hpBarRoot;  // กรอบ HP ทั้งชุด (พ่อของ hpBar)

    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        UpdateHPBar();

        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHPBar()
    {
        if (hpBar != null)
        {
            float scaleX = (float)currentHP / maxHP;
            hpBar.localScale = new Vector3(scaleX, hpBar.localScale.y, hpBar.localScale.z); 
            Debug.Log(hpBar.localScale);
        }

        if (hpBarRoot != null)
        {
            // ถ้า HP เต็ม → ซ่อนกรอบทั้งชุด
            hpBarRoot.SetActive(currentHP < maxHP);
        }
    }
}
