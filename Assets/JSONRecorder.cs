using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONRecorder : MonoBehaviour {

	private string path;
	private string filename = "MyList.JSON";

	public int id;
	public string nameString;
	public double doubleNum;

	public MyClass myClass;
	public MyClassList myClassList =  new MyClassList();

	void Start () {
		path = Application.persistentDataPath + "/" +filename;
	}

	public void ButtonPush(){
	RecordIdName(id, nameString);
	}

	void PullData(){
		if(File.Exists(path)){
			string contents = File.ReadAllText(path);
			myClassList = JsonUtility.FromJson<MyClassList>(contents);
		}
	}

	void RecordIdName(int i, string s) {
		PullData();
		myClass = new MyClass(i, s);
		myClassList.classList.Add(myClass);
		string contents = JsonUtility.ToJson(myClassList);
		File.WriteAllText (path, contents);
		Debug.Log(myClassList.classList[0]);
	}
}
