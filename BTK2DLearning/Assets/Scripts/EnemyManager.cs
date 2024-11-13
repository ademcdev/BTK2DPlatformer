using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TerrainUtils;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;
    public float damage;

    bool isColliderBusy = false;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Player") && !isColliderBusy)
        {
            isColliderBusy = true;
            collidedObject.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (collidedObject.CompareTag("Projectile"))
        {
            GetDamage(collidedObject.GetComponent<ProjectileManager>().projectileDamage);
            Destroy(collidedObject.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Player"))
        {
            isColliderBusy = false;
        }
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }

        slider.value = health;
        IsEnemyDead();
    }

    void IsEnemyDead()
    {
        if (health <= 0)
        {
            DataManager.instance.EnemyKilled++;
            SoundManager.instance.PlaySoundEnemyKill();
            Destroy(gameObject);
        }
    }
}
