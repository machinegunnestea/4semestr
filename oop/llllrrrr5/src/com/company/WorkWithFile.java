package com.company;

import java.io.FileReader;
import java.io.IOException;
import java.util.*;
import java.util.stream.Collectors;

public class WorkWithFile {
    public static List<Integer> readFile() throws IOException {
        Scanner scan = new Scanner(new FileReader("D:\\универ\\4sem\\oop\\llllrrrr5\\numbers.txt"));
        String[] line = scan.nextLine().split(" ");
        List<Integer> list = Arrays.stream(line).map(e -> Integer.parseInt(e)).collect(Collectors.toList());
        return list;
    }
}
