using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DemoManager : MonoBehaviour {

	public GameObject[] sportsCars;

	int index;

	public Image[] colorButtons;

	public float rotationSpeed;
	bool toggle;
	public MouseOrbit mouseOrbit;
	Quaternion lastCarRot;
	void Start () {
		for (int i = 0; i < sportsCars.Length; i++) {
			sportsCars [i].SetActive (false);
		}
		sportsCars [0].SetActive (true);
	
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			toggle = !toggle;
			if(!toggle)
				mouseOrbit.enabled = true;
			else
				mouseOrbit.enabled = false;
		}

			if(toggle){
				sportsCars[index].transform.Rotate(transform.up*rotationSpeed);
			}

	}


	public void showNextCar(){
		lastCarRot = sportsCars [index].transform.rotation;
		sportsCars [index].SetActive (false);
		if (index >= sportsCars.Length - 1)
			index = 0;
		else
		index++;
		sportsCars [index].SetActive (true);
		sportsCars [index].transform.rotation=lastCarRot ;

	}


	public void showPreviousCar(){
		lastCarRot = sportsCars [index].transform.rotation;
		sportsCars [index].SetActive (false);
		if (index <= 0)
			index = sportsCars.Length-1;
		else
			index--;
		sportsCars [index].SetActive (true);
		sportsCars [index].transform.rotation=lastCarRot ;
	
	}

	public void changeColor(int no){
		sportsCars [index].transform.FindChild("body").GetComponent<MeshRenderer> ().materials [0].color = colorButtons[no].color;
	
	
	}
}
