package com.company;

import java.io.IOException;
import java.util.Arrays;
import java.util.Comparator;
import java.util.Scanner;

import static com.company.Gazetteer.*;

public class Main {

    public static void main(String[] args) throws CloneNotSupportedException, IOException {
        Gazetteer<String>[] array = DataAccess.readFile();
        ShowClass.show(array);

       Arrays.sort(array, (a,b) -> a.getPopulation().compareTo(b.getPopulation()));

        ShowClass.show(array);


        Scanner in = new Scanner(System.in);
        System.out.println("Enter the capital: ");
        String capital = in.nextLine();

        search(array, capital);
        array = add(array);
        ShowClass.show(array);

        System.out.format("Enter index(less than %d), after which we need to insert new element", array.length - 1);
        array = after(array);
        ShowClass.show(array);


        Scanner in2 = new Scanner(System.in);
        System.out.println("Entex index to remove element: ");
        int choice = in2.nextInt();
        array = delete(array, choice);
        ShowClass.show(array);

        System.out.println("Choose element to edit: ");
        Scanner element = new Scanner(System.in);
        int chosen = element.nextInt();

        System.out.println("Change\n1.capital\n2.square\n3.population\n4.continent\n5.country");
        Scanner changing = new Scanner(System.in);
        int change = changing.nextInt();

        array = change(array, chosen, change);
        ShowClass.show(array);
        DataAccess.savingFile(array);
    }

}
