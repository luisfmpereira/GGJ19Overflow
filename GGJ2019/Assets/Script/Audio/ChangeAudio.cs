using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour {



	#region Variables
	private AudioManager manager; 
#endregion 
//[SPACE]
//[HEADER()]

#region Unity Methods

void Start () 
	{
		manager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}
	

	void Update () 
	{
		
	}
	
	public void MuteAudio()
	{
		AudioListener.pause = true;
	}
	public void UnmuteAudio()
	{
		AudioListener.pause = false;
	}
}
#endregion
