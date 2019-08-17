using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JSONRetriever : MonoBehaviour {

	//declare variables for JSON file
	private string path;
	private string filename = "MyList.JSON";

	//declare text fields in scene
	public Text integerText, nameText, doubleText;

	//dropdown object in scene
	public Dropdown dropdown;

	//declare the myClassList
	public MyClassList myClassList;

	// Use this for initialization
	void Start () {
		path = Application.persistentDataPath + "/" +filename; //path where JSON file is
		CheckForFile ();
		SetupDropdown ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//if the JSON file is not there, make an empty myClassList and an empty JSON file
	private void CheckForFile (){
		if (!File.Exists (path)) {
			List<MyClass> freshList = new List<MyClass>();
			myClassList.classList = freshList;
			string contents = JsonUtility.ToJson(myClassList);
			File.WriteAllText (path, contents);
		}
	}

	//Once JSON is in myClassList, count the instances of MyClasses in the myClassList
	//make a selection avaialable in the dropdown for each instance.
	//Have to clear the dropdown each time or it will add duplicates
	public void SetupDropdown(){
		readJSON();
		dropdown.ClearOptions();
			List<string> options = new List<string>();
		for (int i = 0; i < myClassList.classList.Count; i++) {
				options.Add(i.ToString());
		}
		dropdown.AddOptions(options);
	}

	//TODO figure out how to make this work if there is only one instance of MyClass
	// When the selection is chosen in the dropdown menu, display the fields in the text fields aboe
	public void DropdownSelected(int j){
		Debug.Log("DropdownSelected(" + j + ")");
		MyClass myClass = RetrieveMyClass(j);
		integerText.text = myClass.integer.ToString();
		nameText.text = myClass.theName;
		doubleText.text = myClass.doubleNumber.ToString();
	}

	//Get the MyClass instance in 
	private MyClass RetrieveMyClass(int j){
		return myClassList.classList[j]; //The MyClass is actually stored in the list classList in myClassList class
	}

	//Take the JSON file and move it into the myClassList
	private void readJSON(){
		string contents = File.ReadAllText (path);
		myClassList = JsonUtility.FromJson<MyClassList> (contents);
	}
}
