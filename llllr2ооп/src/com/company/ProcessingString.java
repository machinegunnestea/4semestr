package com.company;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class ProcessingString {
    public String Str;

    public int LengthLimit;

    public void Task()
    {
        var Str = "Chel 10%5 loloolk 5*5  5-f";
        var sb = new StringBuilder();

        Pattern pattern = Pattern.compile("(\\d+)([+%-*])(\\d+)");
        Matcher matcher = pattern.matcher(Str);
        System.out.println("Input string is " + Str);
        while (matcher.find()) {
            int start=matcher.start();
            int end=matcher.end();
            System.out.println(matcher.group() + "=" + Switch(matcher.group()));
        }
    }
    public static int Switch(String str)
    {
        Pattern pattern = Pattern.compile("[+%-*]");
        Matcher matcher = pattern.matcher(str);
        matcher.find();

        int result = 0;
        int left = Integer.parseInt(str.substring(0, matcher.start()));
        int right = Integer.parseInt(str.substring(matcher.start()+1, str.length()));


        switch(str.charAt(matcher.start()))
        {
            case '*': result = left * right ; break;
            case '-': result = left - right ; break;
            case '+': result = left + right ; break;
            case '%': result = left / right ; break;

        }
        return result;
    }
}
