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

    public static void sorting()
    {
        System.out.print("\n Sorted array:");
        Arrays.sort(array);
    }

    public void myltiplication(int index)
    {
        int multiply = 1;
        for (int j = index; j < array.length; j++)
        {
            if (array[j] < 0)
            {
                multiply*=array[j];
            }

        }
        System.out.printf("\n Multiplication of negative after first positive %d", multiply);
    }
    /*
    count++;

    if (count == 1)
    {
        positive =  i;
    }*/
    public int indexOfPositive()
    {
        int positive = 0;
        int count = 0;

        for (int i = 0; i < array.length;i++) {
            if (array[i] > 0) {
                positive = i;
                break;
            }
        }
        return positive;
    }


    public static void indexMultiplication(int number)
    {

        int mult = 1;
        for (int i = number; i < array.length; i++)
        {
            if (array[i] < 0)
                mult*= array[i];
        }
        System.out.printf("\n Multiplication of negative after chosen index %d", mult);

    }
}
