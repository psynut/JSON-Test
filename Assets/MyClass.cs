using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]

public class MyClass{

	public int identity;
	public string theName;
	public double doubleNumber;

	public MyClass(int id, string name){
		identity = id;
		theName = name; 
	}

	public MyClass(int id, string name, double num){
		identity = id;
		theName = name;
		doubleNumber = num;
	}

	public override string ToString(){
		string m_string = "\n\"identity\":" + identity + ",\"theName\":" + theName + ",\"doubleNumber\":" + doubleNumber;
		return m_string;
	}

}
