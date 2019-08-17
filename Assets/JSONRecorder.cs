using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JSONRecorder : MonoBehaviour {

	//declare variables for JSON file
	private string path;
	private string filename = "MyList.JSON";

	//declare fields to be moved to MyClass
	public int integer;
	public string nameString;
	public double doubleNum;

	//InputFields in Scene
	public InputField integerInput, nameInput, doubleInput;

	//declare myClass and also the list class to be saved in JSON 
	public MyClass myClass;
	public MyClassList myClassList =  new MyClassList();

	void Start () {
		path = Application.persistentDataPath + "/" +filename; //path where JSON file goes
	}

	public void ButtonPush(){
		GetInputValues ();
		RecordIntegerName(integer, nameString, doubleNum);
	}

	//Takes values in the inputfields
	void GetInputValues(){
		integer = int.Parse (integerInput.text);
		nameString = nameInput.text;
		doubleNum = double.Parse(doubleInput.text);
	}

	//If there is a MyClassList already in JSON - move it into myClassList
	//before adding new entries to the MyClassList
	void PullData(){
		if(File.Exists(path)){
			string contents = File.ReadAllText(path);
			myClassList = JsonUtility.FromJson<MyClassList>(contents);
		}
	}

	//Take add the inputs to a MyClass and add MyClass to the MyClassList
	void RecordIntegerName(int i, string s, double d) {
		PullData();
		myClass = new MyClass(i, s, d);
		myClassList.classList.Add(myClass);
		string contents = JsonUtility.ToJson(myClassList);
		File.WriteAllText (path, contents);
	}
}
