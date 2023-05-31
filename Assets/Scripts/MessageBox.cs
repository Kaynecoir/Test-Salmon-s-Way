using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
	
	public string message = "New Text";

    [SerializeField]
    private Text textComp;

	//public MessageBox(string message = "New Text")
	//{
	//	this.Message = message;
	//	textComp.text = this.Message;
	//}
	
	private void Start()
	{
		textComp = GetComponentInChildren<Text>();
		Debug.Log(textComp.ToString());
	}
	public void Message(string value)
	{
		textComp.text = value;
	}

}
