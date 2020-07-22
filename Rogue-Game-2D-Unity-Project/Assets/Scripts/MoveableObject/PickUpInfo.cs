using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;
using Light2D = UnityEngine.Experimental.Rendering.Universal.Light2D;

public class PickUpInfo : MonoBehaviour
{
    public int healthAmount;
    public Transform healthPos;
    public LayerMask whatIsPlayer;
    public Vector2 healingRange;


    private void Update()
    {
        Collider2D[] Player = Physics2D.OverlapBoxAll(this.healthPos.position, this.healingRange, this.whatIsPlayer);
        for (int i = 0; i < Player.Length; i++)
        {
            if (Player[i] != null && Player[i].GetComponent<PlayerInfo>() != null && Player[i].GetComponent<PlayerInfo>().CurrentHealth < 100)
            {
                Player[i].GetComponent<PlayerInfo>().GainHealth(this.healthAmount);
                Destroy(this.gameObject);
            }

        }

    }

    private void OnDrawGizmosSelected()
    //Visualizes the attack for testing
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.healthPos.position, (Vector3)this.healingRange);

    }
}
