using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public float spellDamage = 10f;
    public float spellMoveSpeed = 5f;
    public float spellRange = 10f;
    public float spellCooldown = 1f;
    public GameObject spellBallPrefab;
    public Transform originPoint;

    private float cooldownLeft;

    // Start is called before the first frame update
    void Start()
    {
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cooldownLeft <= 0)
            {
                Vector3 originPosition = originPoint.position + originPoint.forward * 0.5f;
                GameObject spellBall = Instantiate(spellBallPrefab, originPosition, transform.rotation);
                spellBall.GetComponent<SpellBall>().originGameObject = gameObject;
                spellBall.GetComponent<SpellBall>().spellDamage = spellDamage;
                spellBall.GetComponent<SpellBall>().spellMoveSpeed = spellMoveSpeed;
                spellBall.GetComponent<SpellBall>().spellRange = spellRange;

                cooldownLeft = spellCooldown;
            }
        }
    }
}