using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damagable : MonoBehaviour
{
    public int MaxHealth = 100;

    [SerializeField]
    private int health;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;

    private Vector3 respawnPosition; // Vị trí hồi sinh

    private void Start()
    {
        Health = MaxHealth;
        respawnPosition = transform.position; // Lưu vị trí hiện tại là vị trí hồi sinh
    }

    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if (Health <= 0)
        {
            Die();
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    private void Die()
    {
        // Xử lý khi nhân vật chết
        // Gọi sự kiện OnDead để thông báo rằng nhân vật đã chết
        OnDead?.Invoke();

        // Sau đó hồi sinh lại nhân vật
        Respawn();
    }

    private void Respawn()
    {
        // Thiết lập lại sức khỏe và vị trí hồi sinh
        Health = MaxHealth;
        transform.position = respawnPosition;

        // Thêm bất kỳ xử lý nào khác bạn cần khi hồi sinh
    }

    public void Heal(int healthBoost)
    {
        Health += healthBoost;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }
}
