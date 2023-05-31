using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " New GameData", menuName = "Game Data", order = 51)]
public class UGameData : ScriptableObject
{
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float botSpeed;
    [SerializeField]
    private float botWaitTime;
    [SerializeField]
    private float safeRadius;
    [SerializeField]
    private float messageWaitSec;
    [SerializeField]
    private string message;

    public float PlayerSpeed { get { return playerSpeed; } }
    public float BotSpeed { get { return botSpeed; } }
    public float BotWaitTime { get { return botWaitTime; } }
    public float SafeRadius { get { return safeRadius; } }
    public float MessageWaitSec { get { return messageWaitSec; } }
    public string Message { get { return message; } }
}
