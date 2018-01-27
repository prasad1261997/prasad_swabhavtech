package com.techlabs.basic;

public class SubStringTest {
	public static void main(String ar[]) {
		String str1;
		String str = new String("www.SwabhavTechlabs.com?developer=prasad");
		int a = str.indexOf(".");
		int b = str.lastIndexOf(".");

		str1 = str.substring(a + 1, b);
		System.out.println(str1);

		a = str.indexOf("=") + 1;
		System.out.println(str.substring(a));
	}

}
