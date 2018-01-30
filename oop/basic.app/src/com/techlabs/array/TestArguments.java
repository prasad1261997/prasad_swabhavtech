package com.techlabs.array;


public class TestArguments {
	public static void main(String[] developerNames)
	{
		System.out.println("main");
		if(developerNames.length!=0)
		for(int position=0;position<developerNames.length;position++)
			System.out.println("hello "+developerNames[position]);
		else
			System.out.println("no arguments passsed");
		
		for(String name:developerNames)
			System.out.println(name);
	}

}
