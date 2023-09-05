package com.company;
import javax.naming.PartialResultException;
import java.util.Arrays;
import java.util.Scanner;

public class LR_1 {

    private static int[] array;

    public LR_1(int[] arr) {
        array = arr;
    }

    public String toString() {
        return Arrays.toString(array);
    }

    public static void sorting() {
        System.out.print("\n Sorting array:");
        Arrays.sort(array);
    }

    public void exercise1(int index) {
        int counter = 0;
        for (int i = index; i < array.length - 1; i++) {
            if(array[i] < 0)
                counter+=array[i];
        }
        System.out.printf("\n exercise 1 result is %d", counter);
    }

    public int indexOfExer1(){
        int needed = 0;
        for (int i = 1; i < array.length; i++)
        {
            if(array[i]<array[i-1])
                needed = i;
        }
        return needed;
    }

    public static void exercise2() {
        System.out.print("\n Input number:");
        Scanner in = new Scanner(System.in);

        int number = in.nextInt();
        int sum = 0;
        for (int i = 0; i < array.length; i++) {
            if ((i+1)%number == 0)
                if(array[i]<0)
                    sum+=array[i];
        }
        System.out.printf("\n exercise 2 result is %d", sum);
    }
}
