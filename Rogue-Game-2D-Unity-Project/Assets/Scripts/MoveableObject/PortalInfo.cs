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
        this.isActivated = this.isActivated == false && GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
        if(this.isActivated == true)
        {
            this.animator.SetTrigger("isActivated");
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
