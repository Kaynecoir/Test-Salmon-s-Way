using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPlayerView : MonoBehaviour
{
    public Vector3 mousePos;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private SpriteRenderer playerSpriteRender;
    void Start()
    {
        Player = gameObject;
        if(playerSpriteRender == null)  playerSpriteRender = Player.GetComponent<SpriteRenderer>();
        if(anim == null)    anim = Player.GetComponent<Animator>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        mousePos.y = 0.0f;

        playerSpriteRender.flipX = mousePos.x < 0;
        anim.SetBool("BackLook", mousePos.z > 0);
        anim.SetBool("isRun", Player.GetComponent<UPlayerController>().velocity.sqrMagnitude > 0.1f);
    }
}
