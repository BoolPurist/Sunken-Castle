using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInfo : MonoBehaviour
{
    private bool isActivated = false;
    public Animator animator;

    // Update is called once per frame
    private void Update()
    {
        this.isActivated = isActivated == false && GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
        if(isActivated == true)
        {
            animator.SetTrigger("isActivated");
        }

    }

    public void OnTriggerStay2D(Collider2D other)
    {

        if (this.isActivated == true && other.CompareTag("Player") && other.isTrigger == false)
        {
            this.GetComponent<ChooseRandomScene>().ChooseNextRandomScene();
        }
    }
}
