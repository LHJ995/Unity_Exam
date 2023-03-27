using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{

    [System.Serializable]
    class DataForm
    {
        public string Name;
        public string Age;

        DataForm(string _name,string _age)
        {
            Name = _name;
            Age = _age;
        }
    }

    void Start()
    {
        var JsonData = Resources.Load<TextAsset>("saveFile/Test");

        print(JsonData.ToString());

        DataForm form = JsonUtility.FromJson<DataForm>(JsonData.ToString());

        print(form.Name);
        print(form.Age);
    }

    void Update()
    {
        
    }
}
