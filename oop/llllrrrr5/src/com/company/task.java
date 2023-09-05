package com.company;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;



public class task {

    public List<Integer> list;

    public task() throws IOException {
        list = WorkWithFile.readFile();
    }

    public void show(){
        list.forEach(System.out::print);
    }

    public void showAllTask(){
        int min = list.stream().min(Integer::compare).get();
        int max = list.stream().max(Integer::compare).get();
        System.out.println("Минимальный элемент " + min);
        System.out.println("Максммальный элемент " + max);

        int minIndexOf = list.indexOf(min);
        int minLastIndex = list.lastIndexOf(min);
        System.out.println("Левый индекс первого минимума" + minIndexOf + ", правого " + minLastIndex);

        int[] arr = Arrays.stream(Arrays.copyOfRange(list.stream().mapToInt(j->(int)j).toArray(), minIndexOf+1, minLastIndex)).toArray();
        System.out.println("Массив между левым и правым минимумами: " + Arrays.toString(arr));


        int sumOfBetween = Arrays.stream(arr).sum();
        System.out.print("Сумма элементов, расположенным между индексами (" + minIndexOf + ", " + minLastIndex + ") равна " + sumOfBetween);
        System.out.println();
        int countOfBetween = arr.length;
        System.out.println("Количество элементов, расположенным между индексами (" + minIndexOf + "," + minLastIndex + ") равна " + countOfBetween );
        double averageBetween = Arrays.stream(arr).average().getAsDouble();
        System.out.println("Среднее значение " + averageBetween);

        List<Integer> decreasingList = list.stream().sorted((a, b) -> b - a).collect(Collectors.toList());
        System.out.println("Убывающий список " + Arrays.toString(decreasingList.toArray()));
        List<Integer> increasingList = list.stream().sorted().collect(Collectors.toList());
        System.out.println("Возрастающий список " + Arrays.toString(increasingList.toArray()));

        List<Integer> group = list.stream().skip(5).limit(5).collect(Collectors.toList());
        System.out.println("Группа из 5 элементов " + Arrays.toString(group.toArray()));

        List<Integer> fiveMax = decreasingList.stream().limit(5).collect(Collectors.toList());
        System.out.println("Пять максимальных чисел " + Arrays.toString(fiveMax.toArray()));

        int amountAfterFive = list.stream().skip(5).mapToInt(t->t).sum();
        System.out.println("Сумма элементов после пятого равна" + amountAfterFive);

        int amountSkipThreeBeforeMax = list.stream().skip(3).takeWhile(t->t!=max).mapToInt(t->t).sum();
        System.out.println("Пропустить первые 3 элемента и посчитать сумму элементов, пока не достигнем первого максимального: " + amountSkipThreeBeforeMax);

        List<Integer> lessThenMax = list.stream().filter(t-> t-4 == max).limit(5).collect(Collectors.toList());
        System.out.println("Выбрать из массива array0 пять элементов, меньших максимума на 4 " + Arrays.toString(lessThenMax.toArray()));

        List<Integer> fiveMin = increasingList.stream().limit(5).collect(Collectors.toList());
        System.out.println("Выбрать из массива первые 5 наименьших элементов " + Arrays.toString(fiveMin.toArray()));

        List<Integer> con = Stream.concat(fiveMax.stream(), fiveMin.stream()).collect(Collectors.toList());
        System.out.println("Список из пяти максимальных и минимальных элементов " + Arrays.toString(con.toArray()));

        List<Integer> without = decreasingList.stream().skip(5).collect(Collectors.toList());
        System.out.println("Исходный список без 5-ти максимальных " + Arrays.toString(without.toArray()));

        List<Integer> with = list.stream().distinct().collect(Collectors.toList());
        System.out.println("Уникальные элементы " + Arrays.toString(with.toArray()));

    }

}
