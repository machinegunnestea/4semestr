package com.company;

import java.util.Scanner;

public class main {

    public static void main(String[] args) {
        test1();
    }

    public static void test1() {
        int[] arrFirst = new int[]{-10, 4, -6, 2};
        int[] arrSecond = inputArrSecond();
        int[] arrThird = createThirdArr(arrFirst, arrSecond);

        LR_1 arr1 = new LR_1(arrFirst);
        System.out.println(arr1);

        LR_1 arr2 = new LR_1(arrSecond);
        System.out.println(arr2);

        LR_1 arr3 = new LR_1(arrThird);
        System.out.println(arr3);

        arr3.myltiplication(arr3.indexOfPositive());

        System.out.print("\n Input index of starting point :");
        Scanner in = new Scanner(System.in);
        int number = in.nextInt();
        arr3.indexMultiplication(number);

        arr3.sorting();
        System.out.println(arr3);

    }
    public static int[] createThirdArr(int[] arrFirst, int[] arrSecond) {
        int[] arr = new int[arrFirst.length + arrSecond.length];
        System.arraycopy(arrFirst, 0, arr, 0, arrFirst.length);
        System.arraycopy(arrSecond, 0, arr, arrFirst.length, arrSecond.length);

        return arr;
    }

    public static int[] inputArrSecond() {
        System.out.println("Input size of second array: ");
        Scanner in = new Scanner(System.in);
        int sizeOfArr = in.nextInt();

        int[] arr = new int[sizeOfArr];

        for (int index = 0; index < sizeOfArr; index++) {
            System.out.printf("Input %d element of array: ", index + 1);
            arr[index] = in.nextInt();
        }
        return arr;
    }
}



