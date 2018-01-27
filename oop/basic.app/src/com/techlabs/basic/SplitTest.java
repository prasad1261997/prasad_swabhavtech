package com.techlabs.basic;

public class SplitTest {
	
	public static void main(String ar[])
	{
		String str=new String("www.SwabhavTechlabs.com?developer=prasad");
		String str1[]=str.split("\\.");
		//str1=str.split(".");
		System.out.print(str1[1]);
	}
	


}
