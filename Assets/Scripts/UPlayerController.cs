using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPlayerController : MonoBehaviour
{
    public float maxSpeed;
    public Vector3 mousePos;
    public Vector3 velocity;

    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject Arrow;
    private CharacterController charControll;
    void Start()
    {
        Player = gameObject;
        charControll = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        velocity = new Vector3(horizontal, 0.0f, vertical).normalized * maxSpeed;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Player.transform.position;
        mousePos.y = 0.0f;

        Arrow.transform.right = mousePos;

        Player.transform.position += velocity * Time.deltaTime;


    }
}
