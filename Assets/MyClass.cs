using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public string ToString();
	return "\"identity\":" + identity + ",\"theName\":" + theName + ",\"doubleNumber\":" + doubleNumber"
}
