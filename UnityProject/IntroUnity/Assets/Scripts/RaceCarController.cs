using UnityEngine;
using System.Collections;

public class RaceCarController : MonoBehaviour {
    public int CurrentSpeed = 0;
    public int CurrentGear = 1;
    private int TotalGears = 5;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            int newSpeed = CurrentSpeed + 1;
            var maxSpeedForCurrentGear = CurrentGear * 20;
            if (newSpeed > maxSpeedForCurrentGear && CurrentGear < TotalGears)
                CurrentGear += 1;
            if (newSpeed <= maxSpeedForCurrentGear)
                CurrentSpeed = newSpeed;
        }
        else
        {
            if (CurrentSpeed > 0 )
                CurrentSpeed = CurrentSpeed-1;
        }
        if (CurrentSpeed > 0)
        {
            var step = CurrentSpeed * Time.deltaTime;
            var forward = this.transform.right;
            //Debug.Log(forward);
            var newTarget = this.transform.position + forward;
            //Debug.Log("New Position: " + newTarget);
            this.transform.position = Vector3.MoveTowards(this.transform.position, newTarget, step);
        }
        var h = Input.GetAxis("Horizontal");
        if (h != 0)
        {
            this.transform.Rotate(new Vector3(0,h,0));
        }
    }
}
