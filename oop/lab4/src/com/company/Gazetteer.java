package com.company;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.io.IOException;


public class Gazetteer<T> implements Comparable<Gazetteer>
{

    private T country;
    private T square;
    private String population;
    private T continent;
    private T capital;

    public Gazetteer(T country, T square, String population, T continent, T capital){
        this.country = country;
        this.square = square;
        this.population = population;
        this.continent = continent;
        this.capital = capital;
    }
    public T getCountry(){
        return country;
    }

    public T getSquare() {
        return square;
    }

    public String getPopulation() {
        return population;
    }

    public T getContinent() {
        return continent;
    }

    public T getCapital() {
        return capital;
    }

    public void setCountry(T country) {
        this.country = country;
    }

    public void setSquare(T square) {
        this.square = square;
    }

    public void setPopulation(String population) {
        this.population = population;
    }

    public void setContinent(T continent) {
        this.continent = continent;
    }

    public void setCapital(T capital) {
        this.capital = capital;
    }

    @Override
    public String toString() {
        return "Country='" + country + '\'' +
                ", Square='" + square + '\'' +
                ", Population=" + population +
                ", Continent='" + continent + '\'' +
                ", Capital='" + capital + '\'' + System.getProperty("line.separator");
    }


    public static void search(Gazetteer[] a, String cap) {
        for (Gazetteer i : a) {
            if (cap.equals(i.getCapital())) {
                System.out.println(i.toString());
                break;
            }
        }
    }


    public static Gazetteer[] change(Gazetteer[] array, int chosen, int change) throws IOException {

        while (chosen <= 0 || chosen > array.length)
        {
            throw new IOException("wrong input");
        }
        while (change < 1 || change >= 5)
        {
            throw new IOException("wrong input");
        }

        Scanner in = new Scanner(System.in);

        switch (change) {
            case 1:
                System.out.println("...changing capital...");
                array[chosen - 1].setCapital(in.nextLine());
                break;
            case 2:
                System.out.println("...changing square...");
                array[chosen - 1].setSquare(in.nextLine());
                break;
            case 3:
                System.out.println("...changing population...");
                array[chosen - 1].setPopulation(in.nextLine());
                break;
            case 4:
                System.out.println("...changing continent...");
                array[chosen - 1].setContinent(in.nextLine());
                break;
            case 5:
                System.out.println("...changing country...");
                array[chosen - 1].setCountry(in.nextLine());
                break;

        }
        return array;
    }

    public static Gazetteer[] delete(Gazetteer[] array, int choice) {

        ArrayList<Gazetteer> arrayList = new ArrayList<Gazetteer>(Arrays.asList(array));
        arrayList.remove(choice);
        array = arrayList.stream().toArray(Gazetteer[]::new);
        return array;
    }

    public static Gazetteer[] after(Gazetteer[] array) {
        Scanner in = new Scanner(System.in);
        int choice = in.nextInt();
        ArrayList<Gazetteer> arrayList = new ArrayList<Gazetteer>(Arrays.asList(array));
        arrayList.add(choice + 1, new Gazetteer("NEW++", "NEW++", "2", "NEW++", "NEW++"));
        array = arrayList.stream().toArray(Gazetteer[]::new);
        return array;
    }

    public static Gazetteer[] add(Gazetteer[] array) {
        ArrayList<Gazetteer> arrayList = new ArrayList<Gazetteer>(Arrays.asList(array));
        arrayList.add(new Gazetteer("NEW", "NEW", "2", "NEW", "NEW"));
        array = arrayList.stream().toArray(Gazetteer[]::new);
        return array;
    }


    public int compareTo(Gazetteer gazetteer)
    {

        if (Double.parseDouble(this.population) <= Double.parseDouble((String) gazetteer.population)) return -1;
        else if (this.population == gazetteer.population) return 0;
        else return 1;
    }


}
