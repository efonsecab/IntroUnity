using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    public RaceCarController _raceCarController = null;
    public UnityEngine.UI.Text lblSpeedValueUI = null;
    public UnityEngine.UI.Text lblLapValueUI = null;
    public UnityEngine.UI.Slider sldEnergyUI = null;
    // Use this for initialization
    void Start()
    {
        this._raceCarController = FindObjectOfType<RaceCarController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnGUI()
    {
        this.lblSpeedValueUI.text = this._raceCarController.CurrentSpeed.ToString();
        this.lblLapValueUI.text = this._raceCarController.Lap.ToString();
        this.sldEnergyUI.value = ((float)this._raceCarController.Energy / 100);
        //Debug.LogFormat("Lap: {0}", this.Lap);
    }
}
