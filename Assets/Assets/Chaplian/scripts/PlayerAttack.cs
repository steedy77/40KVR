using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    PlayerInput plInput;
    PlayerMovement plMovement;
    Animator anim;

    public float comboRate = .5f;

    WaitForSeconds comboR;
    public GameObject damageCollider;

    void Start ()
    {
        plInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
        plMovement = GetComponent<PlayerMovement>();

        comboR = new WaitForSeconds(comboRate);

        damageCollider.SetActive(false);
    }

    void FixedUpdate()
    {
        if (plInput.fire1)
        {
            anim.SetBool("Attack", true);
            plMovement.canMove = false;
            StartCoroutine("CloseAttack");
        }
    }

    IEnumerator CloseAttack()
    {
        yield return comboR;
        anim.SetBool("Attack", false);
    }

    public void OpenDamageCollider()
    {
        damageCollider.SetActive(true);
    }

    public void CloseDamageCollider()
    {
        damageCollider.SetActive(false);
    }

}

