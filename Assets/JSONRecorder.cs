using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JSONRecorder : MonoBehaviour {

	private string path;
	private string filename = "MyList.JSON";

	public int id;
	public string nameString;
	public double doubleNum;

	public InputField idInput, nameInput, doubleInput;

	public MyClass myClass;
	public MyClassList myClassList =  new MyClassList();

	void Start () {
		path = Application.persistentDataPath + "/" +filename;
	}

	public void ButtonPush(){
		GetInputValues ();
		RecordIdName(id, nameString, doubleNum);
	}

	void GetInputValues(){
		id = int.Parse (idInput.text);
		nameString = nameInput.text;
		doubleNum = double.Parse(doubleInput.text);
	}

	void PullData(){
		if(File.Exists(path)){
			string contents = File.ReadAllText(path);
			myClassList = JsonUtility.FromJson<MyClassList>(contents);
		}
	}

	void RecordIdName(int i, string s, double d) {
		PullData();
		myClass = new MyClass(i, s, d);
		myClassList.classList.Add(myClass);
		string contents = JsonUtility.ToJson(myClassList);
		File.WriteAllText (path, contents);
		Debug.Log(myClassList.classList[0]);
	}
}
