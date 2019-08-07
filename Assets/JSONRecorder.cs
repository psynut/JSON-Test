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

	MyClass myClass;

	List<MyClass> myList = new List<MyClass>();
	List<string> stringList;

	MyListClass myListClass;

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

	void PullData(){
		if(File.Exists(path)){
			string contents = File.ReadAllText(path);
			//myListClass = JsonUtility.FromJson<MyListClass>(contents);
			stringF = JsonUtility.FromJson<string>(contents);
			//myList = myListClass.myList;
			}
	}

	void RecordIdName(int i, string s) {

	//PullData();            Put this back on once you figure out how to write the muListClass to JSON
	Debug.Log("Saving JSON of ID & Name @ " + path);
	myClass = new MyClass(i, s);
	myList.Add(myClass);
	myClass = new MyClass(1, "mememe");
	myList.Add(myClass);

	Debug.Log("myClass identity is " + myClass.identity);
	Debug.Log("myList = " + myList);
	//myListClass.myList = myList;

	//myListClass = new MyListClass
	string contents = JsonUtility.ToJson (myClass);
	stringList = new List<string>(contents);
	//string contents = JsonUtility.ToJson (myListClass);
	File.WriteAllText (path, contents);

	}
}
