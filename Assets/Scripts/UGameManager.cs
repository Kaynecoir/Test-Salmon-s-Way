using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGameManager : MonoBehaviour
{
    public GameObject origin;
    
    public int countBot = 0;

    [SerializeField]
    UGameData GameData;
    [SerializeField]
    List<GameObject> botsList;
    [SerializeField]
    private float ableCreateBot;
    [SerializeField]
    private GameObject botsGroup;
    [SerializeField]
    private MessageBox dialogWindow;
    private Wait dialogWindowWait;

    void Start()
    {
        ableCreateBot = Time.time;
        botsList = new List<GameObject>();
        dialogWindowWait = new Wait(GameData.MessageWaitSec);
        Debug.Log(dialogWindowWait.ToString());
        dialogWindowWait.Stop();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && Time.time - ableCreateBot > 0.2f)
		{
            var position = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
            CreateBot(position);
            ableCreateBot = Time.time;
        }
        //if (dialogWindowWait == null) Debug.Log("Нет Wait");
        if(countBot != 0 && countBot % 10 == 0)
		{
            dialogWindowWait.Play();
            dialogWindow.gameObject.SetActive(true);
            dialogWindow.Message(GameData.Message + botsList.Count.ToString());   // Тут немножко доделать надо
		}
        if(dialogWindowWait != null && dialogWindowWait.Cycle() && countBot % 10 != 0)
		{
            dialogWindow.gameObject.SetActive(false);
            dialogWindowWait.Reset();
            dialogWindowWait.Stop();
		}
    }
    private void CreateBot(Vector3 position)
	{
        botsList.Add(Instantiate(origin, position, Quaternion.Euler(90,0,0), botsGroup.transform));
        countBot++;
	}
    public void ClearBots()
	{
        foreach(GameObject b in botsList)
		{
            
            Destroy(b);
		}
        botsList.Clear();
	}
}
