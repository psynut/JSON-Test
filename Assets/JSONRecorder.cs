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

	List<string> myList = new List<string>();

	MyClass myClass;
	MyListClass myListClass = new MyListClass();

	// Use this for initialization
	void Start () {
		filename = "MyList.JSON";
		path = Application.persistentDataPath + "/" +filename;
	}

	public void ButtonPush(){
	RecordIdName(id, nameString, doubleNum);
	RecordIdName(id, nameString);
	}

	void PullData(){
		if(File.Exists(path)){
			string contents = File.ReadAllText(path);
			myListClass = JsonUtility.FromJson<MyListClass>(contents);
			myList = new List<string>(myListClass.myList);
		}

	}

	void RecordIdName(int i, string s) {
		PullData();
		myClass = new MyClass(i, s);
		myList.Add(myClass.ToString());
		myListClass.myList = myList;
		string contents = JsonUtility.ToJson(myListClass);
		File.WriteAllText (path, contents);
	}

	void RecordIdName(int i, string s, double d) {
		PullData();
		myClass = new MyClass(i, s, d);
		myList.Add(myClass.ToString());
		myListClass.myList = myList;
		string contents = JsonUtility.ToJson(myListClass);
		File.WriteAllText (path, contents);
	}
}
