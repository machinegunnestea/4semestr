package com.company;

import java.io.FileReader;
import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;

public class WorkWithFile {

    public static List<String> readString() throws IOException{
        Scanner scan = new Scanner(new FileReader("D:\\универ\\4sem\\oop\\llllrrrr5\\string.txt"));
        String[] line = scan.nextLine().split(" ");
        List<String> list = Arrays.stream(line).collect(Collectors.toList());
        return list;
    }
}
