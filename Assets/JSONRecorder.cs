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


	//Will still need to initialize, but it makes sense to initialize in start.
	MyListClass myListClass;
//	MyListClass myListClass = new MyListClass();
	MyClass myClass;
//	MyClass myClass = new MyClass();

	// Use this for initialization
	void Start () {
		filename = "MyList.JSON";
		path = Application.persistentDataPath + "/" +filename;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonPush(){
	RecordIdName(id, nameString);
	}

	void RecordIdName(int i, string s) {
	Debug.Log("Saving JSON of ID & Name @ " + path);
	myClass = new MyClass(i, s);
	myListClass = new MyListClass(myClass);
	//myListClass = new MyListClass

	string contents = JsonUtility.ToJson (myClass);
	File.WriteAllText (path, contents);

	}
}
