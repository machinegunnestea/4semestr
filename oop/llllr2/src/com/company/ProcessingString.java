package com.company;

import java.util.Scanner;

public class ProcessingString {
    public String Str;

    public int LengthLimit;

    public void Task()
    {
        var scanner = new Scanner(System.in);
        System.out. print("Введите строку: ");
        var Str = scanner.nextLine();
        var numbers = Str.split(String.valueOf(new char[]{ '+', '-', '/', '*' }));
        var sign = Str.substring(numbers[0].length(), 1);
        var a = Integer.parseInt(numbers[0]);
        var b = Integer.parseInt(numbers[1]);
        var result= 0;

        switch (sign)
        {
            case "+": result = a+b; break;
            case "-": result = a-b; break;
            case "*": result = a*b; break;
            case "/": result = a/b; break;
        }
    }
}
