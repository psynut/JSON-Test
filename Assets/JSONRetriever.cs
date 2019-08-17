using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JSONRetriever : MonoBehaviour {

	private string path;
	private string filename = "MyList.JSON";

	public Text idText, nameText, doubleText;

	public Dropdown dropdown;

	public MyClassList myClassList;

	// Use this for initialization
	void Start () {
		path = Application.persistentDataPath + "/" +filename;
		CheckForFile ();
		SetupDropdown ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void CheckForFile (){
		if (File.Exists (path)) {
			string contents = File.ReadAllText (path);
			myClassList = JsonUtility.FromJson<MyClassList> (contents);
		} else {
			List<MyClass> freshList = new List<MyClass>();
			myClassList.classList = freshList;
			Debug.Log(myClassList.classList.Count);
		}
	}

	public void SetupDropdown(){
		Debug.Log ("Running SetupDropdown()");
		dropdown.ClearOptions();
			List<string> options = new List<string>();
		for (int i = 0; i < myClassList.classList.Count; i++) {
			if (i > 0){
				options.Add(i.ToString());
			}
		}
		dropdown.AddOptions(options);
	}

	public void DropdownSelected(int j){
		MyClass myClass = RetrieveMyClass(j);
		idText.text = myClass.identity.ToString();
		nameText.text = myClass.theName;
		doubleText.text = myClass.doubleNumber.ToString();
	}

	private MyClass RetrieveMyClass(int j){
		return myClassList.classList[j];
	}
}
