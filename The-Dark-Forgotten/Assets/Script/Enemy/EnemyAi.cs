using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.AI;

using UnityEngine.SceneManagement;



public class EnemyAI : MonoBehaviour

{

    public NavMeshAgent ai;

    public List<Transform> destinations;

    public Animator aiAnim;

    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime;

    public bool walking, chasing;

    public Transform player;

    Transform currentDest;

    Vector3 dest;

    int randNum;

    public int destinationAmount;

    public float rayCastOffset;

    public LayerMask layerMask;

    public AudioSource Monster;




    void Start()

    {

        walking = true;

        randNum = Random.Range(0, destinations.Count);

        currentDest = destinations[randNum];

    }

    void Update()

    {

        Vector3 direction = (player.position - transform.position).normalized;

        RaycastHit hit;
        
        if (Physics.SphereCast(transform.position, rayCastOffset, direction, out hit, sightDistance, layerMask))

        {

            if (hit.collider.gameObject.tag == "Player")

            {
                
                walking = false;

                StopCoroutine("stayIdle");

                StopCoroutine("chaseRoutine");

                StartCoroutine(Delay());

            }

        }

        if (chasing == true)

        {

            dest = player.position;

            ai.destination = dest;

            ai.speed = chaseSpeed;

            aiAnim.SetBool("running", true);

            float distance = Vector3.Distance(player.position, ai.transform.position);

            if (distance <= catchDistance)

            {

                player.gameObject.SetActive(false);

                chasing = false;

            }

        }

        if (walking == true)

        {

            dest = currentDest.position;

            ai.destination = dest;

            ai.speed = walkSpeed;

            aiAnim.SetBool("walking", true);

            if (ai.remainingDistance <= ai.stoppingDistance)

            {
                aiAnim.SetBool("walking", false);

                ai.speed = 0;

                StopCoroutine("stayIdle");

                StartCoroutine("stayIdle");

                walking = false;

            }

        }

    }

    IEnumerator stayIdle()

    {

        idleTime = Random.Range(minIdleTime, maxIdleTime);

        yield return new WaitForSeconds(idleTime);

        walking = true;

        randNum = Random.Range(0, destinations.Count);

        currentDest = destinations[randNum];

    }

    IEnumerator chaseRoutine()

    {

        chaseTime = Random.Range(minChaseTime, maxChaseTime);

        yield return new WaitForSeconds(chaseTime);

        walking = true;

        chasing = false;

        randNum = Random.Range(0, destinations.Count);

        currentDest = destinations[randNum];

    }  

    private IEnumerator Delay()
    {
        aiAnim.SetBool("Scare", true);
        Monster.enabled = true;
        yield return new WaitForSeconds(2);
        aiAnim.SetBool("Scare", false);
        Monster.enabled = false;
        StartCoroutine("chaseRoutine");

        chasing = true;
    }

}