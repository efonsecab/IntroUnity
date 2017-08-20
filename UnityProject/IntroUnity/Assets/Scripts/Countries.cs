using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System.Linq.Expressions;

public class Countries : MonoBehaviour {
    public UnityEngine.UI.Dropdown ddlCountries;
	// Use this for initialization
	void Start () {
        ddlCountries = GetComponent<UnityEngine.UI.Dropdown>();
        ddlCountries.ClearOptions();
        StartCoroutine(GetCountries());
	}


    IEnumerator GetCountries()
    {
        string getCountriesUrl = "https://restcountries.eu/rest/v2/all";
        using (UnityWebRequest www = UnityWebRequest.Get(getCountriesUrl))
        {
            //www.chunkedTransfer = false;
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = 
                        System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(jsonResult);
                    RootObject[] entities =
                        JsonHelper.getJsonArray<RootObject>(jsonResult);
                    ddlCountries.options.AddRange(
                        entities.OrderBy(p=>p.name).Select(x =>
									new UnityEngine.UI.Dropdown.OptionData()
									{
										text = x.name
                    }).ToList());
                    ddlCountries.value = 0;
                                
                }
                //ddlCountries.options.AddRange(entities.
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

