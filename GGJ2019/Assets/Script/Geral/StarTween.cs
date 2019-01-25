using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTween : MonoBehaviour {



	#region Variables
	Hashtable starScale = new Hashtable();
	Hashtable starRotate = new Hashtable();
#endregion 
//[SPACE]
//[HEADER()]

#region Unity Methods

void Start () 
	{
		starScale.Add("scale", new Vector3(0.3f, 0.3f, 0.3f));
		starScale.Add("easetype", iTween.EaseType.easeInOutBack);
		starScale.Add("time", 2.5f);
		starRotate.Add("z", 15);
		starRotate.Add("easetype", iTween.EaseType.easeInOutSine);
		starRotate.Add("looptype", iTween.LoopType.pingPong);
		iTween.ScaleTo(this.gameObject, starScale);
		iTween.RotateTo(this.gameObject, starRotate);
	}
	

	void Update () 
	{
		
	}
	
}
#endregion
