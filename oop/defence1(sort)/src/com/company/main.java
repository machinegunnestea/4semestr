package com.company;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Arrays;
import java.time.Clock;

public class main {

    public static void main(String[] args) {
        BufferedReader input = new BufferedReader(new InputStreamReader(
                System.in));
        int i, j, rows, columns, N;
        int[][] array = null;
        int[][] array2 = null;
        try
        {
            System.out.print("Input row count:\n> ");
            rows = Integer.parseInt(input.readLine());
            System.out.print("Input column count:\n> ");
            columns = Integer.parseInt(input.readLine());

            if (rows < 1 || columns < 1)
                throw new Exception();

            System.out.print("Input range N:\n> ");
            N = Integer.parseInt(input.readLine());
            if (N < 2)
                throw new Exception();

        }
        catch (IOException e)
        {
            System.out.println("Program exit with exception.");
            return;
        }
        catch (NumberFormatException e)
        {
            System.out.println("Program exit with exception.");
            return;
        }
        catch (Exception e)
        {
            System.out.println("Program exit with error.");
            return;
        }
        array = new int[rows][columns];
        array2 = new int[rows][columns];
        java.util.Random random = new java.util.Random();

        for (i = 0; i < rows; ++i)
            for (j = 0; j < columns; ++j)
                array[i][j] = random.nextInt(N) + 1;

        for (i = 0; i < rows; ++i)
            for (j = 0; j < columns; ++j)
                array2[i][j] = random.nextInt(N) + 1;

        System.out.println("Matrix:");
        for (i = 0; i < rows; ++i, System.out.println())
            for (j = 0; j < columns; ++j)
                System.out.print(array[i][j] + "\t");
        System.out.println("Matrix:");
        for (i = 0; i < rows; ++i, System.out.println())
            for (j = 0; j < columns; ++j)
                System.out.print(array2[i][j] + "\t");


        long start = System.nanoTime();
        for (i = 0; i < rows; i++){
            Arrays.sort(array[i]);
        }
        long timeWorkSort = System.nanoTime() - start;

        System.out.println("Array.sort took : " + timeWorkSort + " nanosec");


        long start1 = System.nanoTime();
        boolean sorted = false;
        while (!sorted){
            sorted = true;
            for (i = 0; i < rows; i++){
                for(j = 0; j < columns-1; j++){
                    if(array2[i][j] > array2[i][j+1])
                    {
                        int temp = array2[i][j];
                        array2[i][j] = array2[i][j+1];
                        array2[i][j+1] = temp;
                        sorted = false;
                    }
                }
            }
        }

        long timeWorkSort1 = System.nanoTime() - start1;

        System.out.println("Buble sort took : " + timeWorkSort1 + " nanosec");

/*        System.out.print("\n Sorted array: \n");
         for (i = 0; i < rows; ++i, System.out.println())
            for (j = 0; j < columns; ++j)
                System.out.print(array[i][j] + "\t");*/
    }

}