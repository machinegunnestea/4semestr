package com.company;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.io.IOException;
import java.lang.Math;
import java.util.Locale;

public class QuadraticEquation {
    public double ValueA;
    public double ValueB;
    public double ValueC;

    public double getValueA() {
        return ValueA;
    }

    public double setValueA(double ValueA) {
        return this.ValueA = ValueA;
    }

    public double getValueB() {
        return ValueB;
    }

    public double setValueB(double ValueB) {
        return this.ValueB = ValueB;
    }

    public double getValueC() {
        return ValueC;
    }

    public double setValueC(double ValueC) {
        return this.ValueC = ValueC;
    }


    @Override
    public String toString(){
        return (ValueA + "x^2" + ValueB +"x" + ValueC);
    }

    public QuadraticEquation(double valueA, double valueB, double valueC) {
        ValueA = valueA;
        ValueB = valueB;
        ValueC = valueC;
    }

    public QuadraticEquation() {
        ValueA = 1;
        ValueB = 0;
        ValueC = -1;
    }
    public double GetDiscriminant() {return (Math.pow(ValueB, 2) - 4 * ValueA*ValueC);}

    public double[] GetRoots(){
        double discriminant = GetDiscriminant();
        double[] result = new double[0];
        if (discriminant ==0){
            result = new double[1];
            result[0] = -ValueB / 2 * ValueA;
        }
        else if (discriminant > 0)
        {
            result = new double[2];
            result[0] = (-ValueB - Math.sqrt(discriminant)) / 2 * ValueA;
            result[1] = (-ValueB + Math.sqrt(discriminant)) / 2 * ValueA;
        }


        return result;
    }
    public String Converter(double[] result){
        String str = Arrays.toString(result);
        return str;
    }
    public static boolean CheckingIdenticalRoots(QuadraticEquation eq1, QuadraticEquation eq2){
        double[] x1 = eq1.GetRoots();
        double[] x2 = eq2.GetRoots();

        if (x1.length ==2 &&  x2.length ==2)
        {
            return x1[0] == x2[0] && x1[1] == x2[1];
        }
        else if (x1.length ==1 && x2.length == 1)
        {
            return x1[0] == x2[0];
        }
        else
        {
            return false;
        }
    }
    static void OutputTable(QuadraticEquation equation1, QuadraticEquation equation2, QuadraticEquation equation3){
        double[] roots1 = equation1.GetRoots();

        double[] roots2 = equation2.GetRoots();

        double[] roots3 = equation3.GetRoots();

        Table table = new Table("Quadratic Equations", "Equations", "Discriminant", "Roots", 12, 12, 12);
        table.PrintHead();
        table.PrintString(equation1.ValueA, equation1.ValueB, equation1.ValueC, equation1.GetDiscriminant(), equation1.Converter(roots1));
        table.PrintString(equation2.ValueA, equation2.ValueB, equation2.ValueC, equation2.GetDiscriminant(), equation2.Converter(roots2));
        table.PrintString(equation3.ValueA, equation3.ValueB, equation3.ValueC, equation3.GetDiscriminant(), equation3.Converter(roots3));
        table.PrintBottom();
    }
    static void Print(QuadraticEquation equation1, QuadraticEquation equation2, QuadraticEquation equation3){

        double[] roots1 = equation1.GetRoots();

        double[] roots2 = equation2.GetRoots();

        double[] roots3 = equation3.GetRoots();
        System.out.print(" ╔═════════════════════╦══════════════╦═══════════╗\n");
        System.out.print(" ║  Quadratic Equation ║ Discriminant ║   Roots   ║\n");
        System.out.print(" ║═════════════════════╬══════════════╬═══════════║\n");

        System.out.format(" ║%3.0fx^2 + %2.0fx + %-4.0f  ║ %6.0f       ║%s║\n",
                                                                equation1.ValueA,
                                                                equation1.ValueB,
                                                                equation1.ValueC,
                                                                equation1.GetDiscriminant(),
                                                                equation1.Converter(roots1));


        System.out.print(" ║═════════════════════╬══════════════╬══════════║\n");
        System.out.format(" ║%3.0fx^2 + %2.0fx + %-4.0f  ║ %6.0f       ║%s║\n",
                equation2.ValueA,
                equation2.ValueB,
                equation2.ValueC,
                equation2.GetDiscriminant(),
                equation2.Converter(roots2));
        System.out.print(" ║═════════════════════╬══════════════╬═══════════║\n");
        System.out.format(" ║%3.0fx^2 + %2.0fx + %-4.0f  ║ %6.0f       ║%s ║\n",
                equation3.ValueA,
                equation3.ValueB,
                equation3.ValueC,
                equation3.GetDiscriminant(),
                equation3.Converter(roots3));
        System.out.print(" ╚═════════════════════╩══════════════╩═══════════╝\n");

    }
}
