package com.company;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {

        var line = new StringBuilder("кружево");
        var myHashMap = createMap(line);
        var sentence = "котмойтылол";
        var arrayChars = sentence.toCharArray();
        var result = new StringBuilder();
        for (Map.Entry<Integer, Character> entry : myHashMap.entrySet()) {
            for (int i = entry.getKey() - 1; i < arrayChars.length; i += line.length()) {
                result.append(arrayChars[i]);
            }
        }
        System.out.println(result);
    }

    private static HashMap<Integer, Character> createMap(StringBuilder line) {
        HashMap<Integer, Character> result = new HashMap<>();
        char[] argChars = new char[line.length()];
        line.getChars(0, line.length(), argChars, 0);
        result.put(1, argChars[0]);
        result.put(2, argChars[1]);
        result.put(3, argChars[2]);
        result.put(4, argChars[3]);
        result.put(5, argChars[4]);
        result.put(6, argChars[5]);
        result.put(7, argChars[6]);
        return result;
    }

}
