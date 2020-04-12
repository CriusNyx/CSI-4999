using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{

    public Text leaderboard;
    public int start = 0;
    public int end = -1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Request());
    }

    // Update is called once per frame
    IEnumerator Request()
    {
        UnityWebRequest www = UnityWebRequest.Get(string.Format("http://touchcrawler.appspot.com/topscores?start={0}&end={1}", start.ToString(), end.ToString()));
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            ScoreResults results = JsonConvert.DeserializeObject<ScoreResults>(www.downloadHandler.text);
            if (results.error == null)
            {
                string info = "";// string.Format("{0,-15} {1,-15} {2,-8} {3} \n","Place","Username","Score","Date");
                int i = 1;
                foreach (JArray score in results.data)
                {
                    DateTime date = new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc);
                    if(score[2].ToString().IndexOf("nano") >= 0)
                        score[2] = score[2].ToString().Substring(0, score[2].ToString().IndexOf("nano"));
                    info += string.Format("{0,-15} {2,-18} {1,-13} {3} \n", i, score[0], score[1], date.AddSeconds(Convert.ToDouble(Regex.Replace((string)score[2], "[^0-9]", ""))).ToString("MM-dd-yyyy"));
                    i++;
                }
                this.leaderboard.text = info;
                Debug.Log(info);
            }else
            {
                Debug.Log("Error in HTTPRequest");
            }

        }
    }

    
}
