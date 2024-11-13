using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public float projectileDamage, projectileLifeSpan;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, projectileLifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
