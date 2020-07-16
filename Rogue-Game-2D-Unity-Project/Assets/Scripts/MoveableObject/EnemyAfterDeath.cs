using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAfterDeath : MonoBehaviour
{

    public Animator animator;


    // Start is called before the first frame update
    private void Start()
    {
        this.animator.SetTrigger("Dies");
    }

    
}
