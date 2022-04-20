using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Networking;
using SimpleJSON;
using UnityEditor.PackageManager.Requests;


public class test : MonoBehaviour
{
    public TMP_Text sampleText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetInfo());
        Debug.Log("Hello");

    }

    IEnumerator GetInfo()
    {
        var request = new UnityWebRequest("https://arr4npnan2.execute-api.ap-northeast-1.amazonaws.com/Default/weekend", "Post");
        JSONObject info = new JSONObject();
        info.Add("username","Yuko");
        info.Add("num1",25);
        info.Add("num2",25);
        string str = info.ToString();
        byte[] bodyRaw = System.Text.Encoding.ASCII.GetBytes(str);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        JSONNode response = JSON.Parse(request.downloadHandler.text);
        sampleText.text = response[1];
        
        Debug.Log(request.downloadHandler.text);
    }


}
