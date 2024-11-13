using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, projectileSpeed;
    public bool dead = false;

    Transform muzzle;
    public Transform projectile, floatingNumber, bloodParticle;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
        SoundManager.instance.PlaySoundGameBegin();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver || GameManager.instance.isPaused) return;

        if (Input.GetMouseButtonDown(0) && !IsClickOnUI())
        {
            ShootProjectile();
        }
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingNumber, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();

        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;

        if (health <= 0)
        {
            IsDead();
        }
    }

    void IsDead()
    {
        dead = true;
        Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity).gameObject, 3f);
        GameManager.instance.LoseProcess();
        Destroy(gameObject);
    }

    void ShootProjectile()
    {
        Transform tempProjectile;
        tempProjectile = Instantiate(projectile, muzzle.position, Quaternion.identity);
        tempProjectile.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * projectileSpeed);
        DataManager.instance.ThrowedProjectile++;
    }

    bool IsClickOnUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("DeadZone") && !dead)
        {
            IsDead();
        }
    }
}
