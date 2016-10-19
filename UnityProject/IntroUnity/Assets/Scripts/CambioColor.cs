using UnityEngine;
using System.Collections;

public class CambioColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (this.tag != "EjemploColor")
            return;
        if (Input.GetKeyUp(KeyCode.Y))
        {
            this.GetComponent<Renderer>().material.color = Color.yellow;
            Debug.Log("Cambiando color: Amarillo");
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            this.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Cambiando color: Verde");
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            this.GetComponent<Renderer>().material.color = Color.blue;
            Debug.Log("Cambiando color: Azul");
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            this.GetComponent<Renderer>().material.color = Color.black;
            Debug.Log("Cambiando color: Negro");
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            this.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("Cambiando color: Rojo");
        }
    }
}
