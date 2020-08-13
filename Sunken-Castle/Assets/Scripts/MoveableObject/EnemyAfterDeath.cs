using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAfterDeath : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        this.animator.SetTrigger("Dies");
    }
}
