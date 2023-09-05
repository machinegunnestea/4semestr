package com.company;


import java.io.IOException;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class task{

    public List<String> capitals;

    public task() throws IOException{
        capitals = WorkWithFile.readString();
    }

    public void show(){
        capitals.forEach(System.out::println);
    }

    public void showAllSecondTask() throws IOException {
        String min = capitals.stream().min(String::compareTo).get();
        String max = capitals.stream().max(String::compareTo).get();
        System.out.println("1.Минимальный элемент " + min);
        System.out.println("2.Максимальный элемент " + max);

        int minIndexOf = capitals.indexOf(min);
        int minLastIndex = capitals.lastIndexOf(min);
        System.out.println("3.Левый индекс первого минимума " + minIndexOf + ", правого " + minLastIndex);

        String[] between = new String[minLastIndex - minIndexOf - 1];

        System.arraycopy(capitals.toArray(), minIndexOf + 1, between, 0, minLastIndex - minIndexOf - 1);

        int sumOfBetween = Arrays.stream(between).mapToInt(e -> e.length()).sum();
        System.out.println("4.Сумма элементов, расположенным между индексами (" + minIndexOf + "," + minLastIndex + ") равна " + sumOfBetween);

        int countOfBetween = between.length;
        System.out.println("5.Количество элементов, расположенным между индексами (" + minIndexOf + "," + minLastIndex + ") равна " + countOfBetween);

        double averageBetween = Arrays.stream(between).mapToInt(e -> e.length()).average().getAsDouble();
        System.out.println("6.Среднее значение " + averageBetween);

        List<String> decreasingList = capitals.stream().sorted((a, b) -> b.compareTo(a)).collect(Collectors.toList());
        System.out.println("7.Убывающий список " + Arrays.toString(decreasingList.toArray()));
        List<String> increasingList = capitals.stream().sorted().collect(Collectors.toList());
        System.out.println("8.Возрастающий список " + Arrays.toString(increasingList.toArray()));

        List<String> group = capitals.stream().skip(5).limit(5).collect(Collectors.toList());
        System.out.println("9.Группа из 5 элементов " + Arrays.toString(group.toArray()));

        List<String> fiveMax = decreasingList.stream().limit(5).collect(Collectors.toList());
        System.out.println("10.Пять максимальных чисел " + Arrays.toString(fiveMax.toArray()));

        int amountAfterFive = capitals.stream().skip(5).mapToInt(t->t.length()).sum();
        System.out.println("11.Сумма элементов после пятого равна" + amountAfterFive);

        int amountSkipThreeBeforeMax = capitals.stream().skip(3).takeWhile(t->t!=max).mapToInt(t->t.length()).sum();
        System.out.println("12.Пропустить первые 3 элемента и посчитать сумму элементов, пока не достигнем первого максимального: " + amountSkipThreeBeforeMax);

        List<String> lessThenMax = capitals.stream().filter(t-> t.length()-4 == max.length()).limit(5).collect(Collectors.toList());
        System.out.println("13.Выбрать из массива array0 пять элементов, меньших максимума на 4 " + Arrays.toString(lessThenMax.toArray()));

        List<String> fiveMin = increasingList.stream().limit(5).collect(Collectors.toList());
        System.out.println("14.Выбрать из массива первые 5 наименьших элементов " + Arrays.toString(fiveMin.toArray()));

        List<String> con = Stream.concat(fiveMax.stream(), fiveMin.stream()).collect(Collectors.toList());
        System.out.println("15.Список из пяти максимальных и минимальных элементов " + Arrays.toString(con.toArray()));

        List<String> without = decreasingList.stream().skip(5).collect(Collectors.toList());
        System.out.println("16.Исходный список без 5-ти максимальных " + Arrays.toString(without.toArray()));

        List<String> with = capitals.stream().distinct().collect(Collectors.toList());
        System.out.println("17.Уникальные элементы " + Arrays.toString(with.toArray()));

        List<String> startsB = capitals.stream().filter(e -> e.startsWith("Б")).collect(Collectors.toList());
        System.out.println("18.Слова на букву Б " + Arrays.toString(startsB.toArray()));

        List<String> startsNoB = capitals.stream().filter(e -> !e.startsWith("Б")).collect(Collectors.toList());
        System.out.println("19.Слова не на букву Б " + Arrays.toString(startsNoB.toArray()));
    }



}
