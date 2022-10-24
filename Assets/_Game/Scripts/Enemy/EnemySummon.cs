using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float cooldown = 10f;

    private float cooldownLeft;

    // Start is called before the first frame update
    void Start()
    {
        cooldownLeft = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SetCooldownLeft();
    }

    private void SetCooldownLeft()
    {
        cooldownLeft -= Time.deltaTime;
    }

    public void SummonEnemy()
    {
        if (cooldownLeft <= 0)
        {
            Instantiate(enemyPrefab, transform.position + transform.right, transform.rotation);
            cooldownLeft = cooldown;
            Debug.Log("sum");
        }
    }
}
