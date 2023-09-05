package com.company;

public class ShowClass {

    public static void show(Gazetteer[] array) {

        System.out.println("\n");
        for (Gazetteer i : array) {
            System.out.println(i.toString());
        }
        System.out.println("\n");
    }

}
