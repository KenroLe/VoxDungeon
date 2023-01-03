using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    StatsController stats;
    void Start()
    {
        stats = GetComponentInParent<StatsController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(stats.hp * 0.01f, 0.1f, 0.1f); // should stats be updating this or should this be checking stats?
    }
}
