package com.company;
import java.util.Arrays;
import java.util.Comparator;

public abstract class SortByPopulation<T> implements Comparable<Gazetteer> {

    public int compareTo(Gazetteer<String> a, Gazetteer<String> b) {
        if (Double.parseDouble(a.getPopulation())<= Double.parseDouble(b.getPopulation())) return -1;
        else if (a.getPopulation() == b.getPopulation()) return 0;
        else return 1;
    }
}
