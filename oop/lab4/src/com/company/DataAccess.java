package com.company;

import java.io.*;
import java.util.ArrayList;
import java.util.Scanner;


public class DataAccess {

    public static String[] line;

    public static Gazetteer[] readFile() throws IOException {

        ArrayList<Gazetteer> e = new ArrayList<Gazetteer>();
        FileReader fr= new FileReader("D:\\универ\\4sem\\oop\\lab4\\data.txt");
        Scanner scan = new Scanner(fr);
        while (scan.hasNextLine()) {
            line = scan.nextLine().split("\\W+");
            Gazetteer someone = new Gazetteer(line[1],line[3],line[5],line[7],line[9]);
            e.add(someone);
        }
        fr.close();
        Gazetteer[] array = e.stream().toArray(Gazetteer[]::new);
        return array;
    }

    public static void savingFile(Gazetteer[] array) throws IOException {
        FileWriter nFile = new FileWriter("D:\\универ\\4sem\\oop\\lab4\\data.txt");
        for (Gazetteer i: array) {
            nFile.write(i.toString());
        }
        nFile.close();
    }
}