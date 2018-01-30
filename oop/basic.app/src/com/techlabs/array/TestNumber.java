package com.techlabs.array;

public class TestNumber {

	public static void main(String[] ar) {
		int mark = 100;
		changeMarkToZero(mark);
		System.out.println(mark);

		int[] marks = { 80, 90, 100 };
		changeMarksToZero(marks);

		for (int i : marks) {
			System.out.println(i);
		}
		System.out.println(marks);
		

	}

	static void changeMarkToZero(int markpar) {
		markpar = 0;

	}

	static void changeMarksToZero(int[] pmarkspar) {
		for (int i = 0; i < pmarkspar.length; i++) {
			pmarkspar[i] = 0;
		}
		System.out.println(pmarkspar);
	}

}
