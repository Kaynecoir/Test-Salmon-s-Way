using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public GameObject follow;
    public UGameData GameData;

    [SerializeField]
    private Transform movePositionTransform;
    [SerializeField]
    private Wait bornWait;
    [SerializeField]
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private SpriteRenderer botSpriteRender;
    [SerializeField]
    private Animator anim;

    void Start()
    {
        botSpriteRender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (follow == null) follow = GameObject.Find("Player");
        movePositionTransform = follow.transform;
        
        bornWait = new Wait(GameData.BotWaitTime);
    }


    void Update()
    {
        bool c = bornWait.Cycle();
        if (!c && !bornWait.isStop) return;
        else if(c && !bornWait.isStop)
		{
            anim.SetTrigger("find");
            bornWait.Stop();
		}
		else
		{
			//navMeshAgent.destination = movePositionTransform.position;
			if (Vector3.Distance(follow.transform.position, transform.position) > GameData.SafeRadius)
			{
				velocity = new Vector3(follow.transform.position.x - transform.position.x, 0.0f, follow.transform.position.z - transform.position.z).normalized * GameData.BotSpeed;

				transform.position += velocity * Time.deltaTime;
				botSpriteRender.flipX = velocity.x < 0;
			}
			else
			{
				velocity = Vector3.zero;
			}
		}
    }
}
