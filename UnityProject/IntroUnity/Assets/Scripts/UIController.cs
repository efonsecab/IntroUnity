using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour
{
    #region Player 1 Elements
    public RaceCarController _raceCarController_Player1 = null;
    public UnityEngine.UI.Text lblSpeedValueUI_Player1 = null;
    public UnityEngine.UI.Text lblLapValueUI_Player1 = null;
    public UnityEngine.UI.Slider sldEnergyUI_Player1 = null;
    #endregion
    #region Player 2 Elements
    public RaceCarController _raceCarController_Player2 = null;
    public UnityEngine.UI.Text lblSpeedValueUI_Player2 = null;
    public UnityEngine.UI.Text lblLapValueUI_Player2 = null;
    public UnityEngine.UI.Slider sldEnergyUI_Player2 = null;
    #endregion
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnGUI()
    {
        //Player 1
        this.lblSpeedValueUI_Player1.text = this._raceCarController_Player1.CurrentSpeed.ToString();
        this.lblLapValueUI_Player1.text = this._raceCarController_Player1.Lap.ToString();
        this.sldEnergyUI_Player1.value = ((float)this._raceCarController_Player1.Energy / 100);
        //Player 2
        this.lblSpeedValueUI_Player2.text = this._raceCarController_Player2.CurrentSpeed.ToString();
        this.lblLapValueUI_Player2.text = this._raceCarController_Player2.Lap.ToString();
        this.sldEnergyUI_Player2.value = ((float)this._raceCarController_Player2.Energy / 100);
        //Debug.LogFormat("Lap: {0}", this.Lap);
    }
}
