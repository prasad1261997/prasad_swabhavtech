package com.techlabs.basic;

//import java.io.*;
public class Test {
	public static void main(String[] args) {
		int x = 0;
		int y = 0;
		while (x < 5) {

			y = x - y;

			// 1. System.out.println(x+""+y+"");

			// 2. y = y + x;

			/*
			 * 3. y = y + 2; if( y > 4 ) { y = y - 1; }
			 */

			/*
			 * 4. x = x + 1; y = y + x;
			 */

			/*
			 * 5. if ( y < 5 ) { x = x + 1; if ( y < 3 ) { x = x - 1; } } y = y
			 * + 2;
			 */

			x = x + 1;
		}
	}
}