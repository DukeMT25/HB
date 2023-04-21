using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] protected CombatText CombatTextPrefab;

    private float hp;
    private string currentAnimName;

    public bool IsDead => hp <= 0;

    private void Start()
    {
        OnInit();
    }

    public virtual void OnInit()
    {
        hp = 100;
        healthBar.OnInit(100, transform);
    }

    public virtual void OnDespawn()
    {

    }
    protected virtual void OnDeath()
    {
        ChangeAnim("Die");

        Invoke(nameof(OnDespawn), 2f);
    }

    protected void ChangeAnim(string aniName)
    {
        if (currentAnimName != aniName)
        {
            anim.ResetTrigger(aniName);
            currentAnimName = aniName;
            anim.SetTrigger(currentAnimName);
        }
    }

    public void OnHit(float damage)
    {
        if (!IsDead)
        {
            hp -= damage;

            if (!IsDead)
            {
                hp = 0;
                OnDeath();
            }

            healthBar.SetNewHP(hp);
            Instantiate(CombatTextPrefab, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
        }
    }

    
}
