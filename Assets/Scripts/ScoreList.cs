using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Score {
    public Score(string n, float t){
        name = n;
        time = t;
    }
    public string name;
    public float time;
}
public class ScoreList : MonoBehaviour
{
    public List<Score> score = new List<Score>();
    public string fileName;
    public GameObject input;
    public GameObject finalPanel;
    public GameObject scorePanel;
    public GameObject entryPrefab;
    void Start()
    {
        if(File.Exists(fileName)){
            using(BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open))){
                while(true){
                    try{
                            string name = reader.ReadString();
                            float time = reader.ReadSingle();
                            score.Insert(0, new Score(name, time));
                    }
                    catch(EndOfStreamException e){
                        break;
                    }
                }
            }
        }
    }
    void Update()
    {
        
    }
    public void NewEntry(){
   
        string name = input.GetComponent<TMP_InputField>().text;
        float time = Time.time - GameData.gamePlayStart;
        score.Add(new Score(name, time));

        int offset = 50;
        foreach(Score score in score){
            GameObject temp = Instantiate(entryPrefab);
            Transform[] children = temp.GetComponentsInChildren<Transform>();
            children[1].GetComponent<TextMeshProUGUI>().text = score.name;
            children[2].GetComponent<TextMeshProUGUI>().text = score.time.ToString("F2");

            temp.transform.SetParent(scorePanel.transform);
            RectTransform rtrans = temp.GetComponent<RectTransform>();
            rtrans.anchorMin = new Vector2(0.5f, 0.5f);
            rtrans.anchorMax = new Vector2(0.5f, 0.5f);
            rtrans.pivot = new Vector2(0.5f, 0.5f);
            rtrans.localPosition = new Vector3(0, offset, 0);

            offset -= 35;
        }
        finalPanel.SetActive(false);
        scorePanel.SetActive(true);
        Debug.Log("New Entry Method");
    }
    private void OnDestroy(){
        using(BinaryWriter write = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate))){
            foreach(Score score in score){
                write.Write(score.name);
                write.Write(score.time);
            }
        }
    }
}
