[System.Serializable]
public class ScoreResults
{
    public object error { get; set; }
    public string timestamp { get; set; }
    public List<List<object>> data { get; set; }

    public static ScoreResults CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ScoreResults>(jsonString);
    }
}


