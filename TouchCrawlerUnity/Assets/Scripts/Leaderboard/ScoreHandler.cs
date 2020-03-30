using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{

    public Text leaderboard;
    public int start = 0;
    public int end = 2;
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
                string info = "";
                int i = 1;
                foreach (JArray score in results.data)
                {
                    info += string.Format("{0}) Score: {1} || Name: {2} || Time: {3} \n",i, score[0], score[1], score[2]);
                    i++;
                }
                this.leaderboard.text = info;
            }else
            {
                Debug.Log("Error in HTTPRequest");
            }

        }
    }

    
}
