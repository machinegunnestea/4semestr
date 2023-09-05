package com.company;

import com.sun.jdi.Value;

import java.io.IOException;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

public class main {
    public static void main(String[] args){
        QuadraticEquation quadratic1 = new QuadraticEquation();

        System.out.print("Values for the first equation are static\n");
        System.out.print("Enter values for the second equation \n");
        System.out.print("\nEnter variable values for the second: \n");
        double ValueA = Correction("Enter value of the coefficient A(ValueA) = ");
        double ValueB = Correction("Enter value of the coefficient B(ValueB) = ");
        double ValueC = Correction("Enter value of the coefficient C(ValueC) = ");

        QuadraticEquation quadratic2 = new QuadraticEquation(ValueA, ValueB, ValueC);
        System.out.print("\nEnter variable values for the third: \n");
        ValueA = Correction("Enter value of the coefficient A(ValueA) = ");
        ValueB = Correction("Enter value of the coefficient B(ValueB) = ");
        ValueC = Correction("Enter value of the coefficient C(ValueC) = ");

        QuadraticEquation quadratic3 = new QuadraticEquation(ValueA, ValueB, ValueC);

        System.out.print("\nAre roots for the 2nd and the 3rd are idenical?\n");
        Check(quadratic2, quadratic3);
        System.out.print("\nAre roots for the 1st and the 3rd are idenical?\n");
        Check(quadratic1, quadratic3);

        QuadraticEquation.OutputTable(quadratic1,quadratic2, quadratic3);


        //QuadraticEquation.Print(quadratic1,quadratic2, quadratic3);

        System.out.print(" Which equation do you want to change?");
        System.out.print(" 1. First equation.");
        System.out.print(" 2. Second equation.");
        System.out.print(" 3. Third equation.");
        System.out.print("Type: ");

        Scanner in = new Scanner(System.in);

        int choise = Integer.parseInt(in.nextLine());;
        switch(choise)
        {
            case 1:

                System.out.print(" Enter the value of the first coefficient that we are going to change: ");
                quadratic1.ValueA = Double.parseDouble(in.nextLine());;
                System.out.print(" Enter the value of the second coefficient that we are going to change: ");
                quadratic1.ValueB = Double.parseDouble(in.nextLine());;
                System.out.print(" Enter the value of the third coefficient that we are going to change: ");
                quadratic1.ValueC = Double.parseDouble(in.nextLine());;

                double[] roots1 = quadratic1.GetRoots();
                System.out.format(" ║%3.0fx^2 + %2.0fx + %-4.0f  ║ %6.0f       ║%s║\n",
                        quadratic2.ValueA,
                        quadratic2.ValueB,
                        quadratic2.ValueC,
                        quadratic2.GetDiscriminant(),
                        quadratic2.Converter(roots1));

                break;
            case 2:

                System.out.print(" Enter the value of the first coefficient that we are going to change: ");
                quadratic2.ValueA = Double.parseDouble(in.nextLine());;
                System.out.print(" Enter the value of the second coefficient that we are going to change: ");
                quadratic2.ValueB = Double.parseDouble(in.nextLine());;
                System.out.print(" Enter the value of the third coefficient that we are going to change: ");
                quadratic2.ValueC = Double.parseDouble(in.nextLine());;


                double[] roots2 = quadratic2.GetRoots();

                System.out.format(" ║%3.0fx^2 + %2.0fx + %-4.0f  ║ %6.0f       ║%s║\n",
                        quadratic2.ValueA,
                        quadratic2.ValueB,
                        quadratic2.ValueC,
                        quadratic2.GetDiscriminant(),
                        quadratic2.Converter(roots2));
                break;
            case 3:

                System.out.print(" Enter the value of the first coefficient that we are going to change: ");
                quadratic3.ValueA = Double.parseDouble(in.nextLine());;
                System.out.print(" Enter the value of the second coefficient that we are going to change: ");
                quadratic3.ValueB = Double.parseDouble(in.nextLine());;
                System.out.print(" Enter the value of the third coefficient that we are going to change: ");
                quadratic3.ValueC = Double.parseDouble(in.nextLine());;


                double[] roots3 = quadratic3.GetRoots();

                System.out.format(" ║%3.0fx^2 + %2.0fx + %-4.0f  ║ %6.0f       ║%s║\n",
                        quadratic3.ValueA,
                        quadratic3.ValueB,
                        quadratic3.ValueC,
                        quadratic3.GetDiscriminant(),
                        quadratic3.Converter(roots3));
                break;
        }
        int value;
    }

    static void Check(QuadraticEquation q1, QuadraticEquation q2){
        if(QuadraticEquation.CheckingIdenticalRoots(q1,q2))        {
            System.out.print("Roots are ideniical\n");
        }
        else{
            System.out.print("Roots aren't idenical\n");
        }
    }

    public static double Correction(String message)
    {
        Scanner in = new Scanner(System.in);
        System.out.print(message);
        double number = 0;
        while (true)
        {
            try
            {
                number = Double.parseDouble(in.nextLine());
            }
            catch (Exception ex)
            {
                System.out.print(ex.getMessage()+'\n');
                System.out.print("Повторите ввод: ");
                continue;
            }
            break;
        }
        return number;
    }
}
