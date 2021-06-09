using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : IEnemyState
{
    private Enemy enemy;

    private float attackTimer;
    private float attackCooldown = 1;
    public bool canAttack = true;

    public void Enter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Execute()
    {
        SwordAttack();
        if (enemy.Target == null && !enemy.InMeleeRange)
        {
            enemy.ChangeState(new IdleState());
        }

    }

    public void Exit()
    {
        
    }

    public void OntriggerEnter(Collider2D other)
    {
        
    }

    private void SwordAttack()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown)
        {
            canAttack = true;
            attackTimer = 0;
        }

        if (canAttack)
        {
            canAttack = false;
            enemy.MyAnimator.SetTrigger("Attack");
        }
    }
}
