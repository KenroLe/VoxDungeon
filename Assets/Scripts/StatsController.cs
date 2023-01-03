using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    public float hp;
    public float damageMod;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Damage(float damage)
    {
        hp = hp - damage*damageMod;
    }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
