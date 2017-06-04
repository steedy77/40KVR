using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStatsEnemy : MonoBehaviour {

    public float health = 100;
    bool dealDamage;
    bool substractOnce;
    bool dead;

    public float damageTimer = .4f;
    WaitForSeconds damageT;

    Animator anim;

    public GameObject sliderPrefab;

    Slider healthSlider;
    RectTransform healthTrans;

    void Start ()
    {
        damageT = new WaitForSeconds(damageTimer);
        anim = GetComponent<Animator>();

        GameObject slid = Instantiate(sliderPrefab, transform.position, Quaternion.identity) as GameObject;
        slid.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        healthSlider = slid.GetComponentInChildren<Slider>();
        healthTrans = slid.GetComponent<RectTransform>();
    }
    
    void Update()
    {
        healthSlider.value = health/100;

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        healthTrans.transform.position = screenPoint;

        if(dealDamage)
        {
            if(!substractOnce)
            {
                health -= 30;
                anim.SetTrigger("Hit");
                substractOnce = true;
            }

            StartCoroutine("CloseDamage");
        }

        if(health < 0)
        {
            if (!dead)
            {
                anim.SetBool("dead", true);
                anim.CrossFade("deathChaos", 0.5f);
                healthTrans.gameObject.SetActive(false);
                dealDamage = true;

                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;

                if(GetComponent<EnemyAI>())
                {
                    GetComponent<EnemyAI>().enabled = false;
                    GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

                }
                else
                {
                    GetComponent<PlayerInput>().enabled = false;
                    GetComponent<PlayerMovement>().enabled = false;
                    GetComponent<PlayerAttack>().enabled = false;
                }

                dead = true;
            }
        }
    }

    public void checkToApplyDamage()
    {
        if(!dealDamage)
        {
            dealDamage = true;
        }
    }
    
    IEnumerator CloseDamage()
    {
        yield return damageT;
        dealDamage = false;
        substractOnce = false;

    }

}
