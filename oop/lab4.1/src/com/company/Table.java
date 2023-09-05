package com.company;

import java.util.Arrays;

public class Table {
    //  Закрытые поля: заголовок таблицы, заголовки столбцов, ширина первого столбца, ширина второго столбца.
    private String topTable;   // заголовок таблицы
    private String topCol1;    // заголовок 1 столбца
    private String topCol2;    // заголовок 2 столбца
    private String topCol3;    // заголовок 3 столбца
    private int widthCol1;     // ширина 1 столбца
    private int widthCol2;     // ширина 2 столбца
    private int widthCol3;     // ширина 3 столбца
    //  Конструктор с параметрами.
    public Table(String topTable, String topCol1, String topCol2, String topCol3, int widthCol1, int widthCol2, int widthCol3)
    {
        this.topTable = topTable;
        this.topCol1 = topCol1;
        this.topCol2 = topCol2;
        this.topCol3 = topCol3;
        this.widthCol1 = widthCol1;
        this.widthCol2 = widthCol2;
        this.widthCol3 = widthCol3;
    }
    public void PrintHead()
    {
        // первая строчка

        System.out.print("╔");
        for (int i = 0; i <= widthCol1 +3; i++)
            System.out.print("═");
        for (int i = 0; i <= widthCol2; i++)
            System.out.print("═");
        for (int i = 0; i <= widthCol3+2; i++)
            System.out.print("═");
        System.out.print("╗\n");
        // вторая строчка - заголовок таблицы
        ShowCol(widthCol1 + widthCol2 + widthCol3 + 8 - ShowColLeft(widthCol1 + widthCol2 + widthCol3 + 1, topTable) - topTable.length(), topTable, widthCol1 + widthCol2 + widthCol3 + 4);
        System.out.print("║\n");
        // третья строчка
        System.out.print("╠");
        for (int i = 0; i < widthCol1+6; i++)
            System.out.print("═");
        System.out.print("╦");
        for (int i = 0; i < widthCol2; i++)
            System.out.print("═");
        System.out.print("╦");
        for (int i = 0; i < widthCol3; i++)
            System.out.print("═");
        System.out.print("╣\n");
        // четвертая строчка - заголовок 1 столбца
        ShowCol(widthCol1 - ShowColLeft(widthCol1, topCol1) - topCol1.length()+6, topCol1, widthCol1);
        // четвертая строчка - заголовок 2 столбца
        ShowCol(widthCol2 - ShowColLeft(widthCol2, topCol2) - topCol2.length(), topCol2, widthCol2);
        // четвертая строчка - заголовок 2 столбца
        ShowCol(widthCol3 - ShowColLeft(widthCol3, topCol3) - topCol3.length(), topCol3, widthCol3);
        System.out.print("║");
        // пятая строчка
        System.out.print("\n╠");
        for (int i = 0; i < widthCol1+6; i++)
            System.out.print("═");
        System.out.print("╬");
        for (int i = 0; i < widthCol2; i++)
            System.out.print("═");
        System.out.print("╬");
        for (int i = 0; i < widthCol3; i++)
            System.out.print("═");
        System.out.print("╣\n");
    }
    //  Метод для вывода строки таблицы (входные параметры – числовые значения, которые выводятся в строке таблицы).
    public void PrintString(double a, double b, double c, double discriminant, String roots)
    {
        // значение 1 столбца
        String valuea = Double.toString(a);
        String valueb = Double.toString(b);
        String valuec = Double.toString(c);
        ShowColForThree(widthCol1 - ShowColLeftForThree(widthCol1, valuea, valueb, valuec) - valuea.length() - valueb.length() - valuec.length(), valuea, valueb, valuec, widthCol1);
        // значение 2 столбца
        String valuedisc = Double.toString(discriminant);
        ShowCol(widthCol2 - ShowColLeft(widthCol2, valuedisc) - valuedisc.length(), valuedisc, widthCol2);
        ShowCol(widthCol2 - ShowColLeft(widthCol2, roots) - roots.length(), roots, widthCol2);
        System.out.print("║\n");
    }
    //  Метод для вывода низа таблицы.
    public void PrintBottom()
    {
        System.out.print("╚");
        for (int i = 0; i <= widthCol1 +5; i++)
            System.out.print("═");
        System.out.print("╩");
        for (int i = 0; i < widthCol2; i++)
            System.out.print("═");
        System.out.print("╩");
        for (int i = 0; i < widthCol3; i++)
            System.out.print("═");
        System.out.print("╝\n");
    }
    // находим количество пробелов слева, печатаем их и возвращаем их количество
    static int ShowColLeft(int COL, String str)
    {
        int spLeft = (COL - str.length()) / 2;
        System.out.print("║");
        for (int i = 0; i < spLeft; i++)
            System.out.print(" ");
        return spLeft;
    }
    static int ShowColLeftForThree(int COL, String str, String str2, String str3)
    {
        int spLeft = (COL - (str.length() + str2.length() + str3.length())) / 2;
        System.out.print("║");
        for (int i = 0; i < spLeft; i++)
            System.out.print(" ");
        return spLeft;
    }

    // печатаем значение и пробелы справа
    static void ShowCol(int spRight, String str, int COL)
    {
        if (str.length() > COL)
            System.out.print(str.substring(0, COL));
        else
            System.out.print(str);
        for (int i = 0; i < spRight; i++)
            System.out.print(" ");
    }
    static void ShowColForThree(int spRight, String str, String str2, String str3, int COL)
    {
        if (str.length() > COL)
            System.out.print(str.substring(0, COL));
        else //(<1>"x^2"+ <2> <3>);
            System.out.print(str+"x^2+"+ str2+"x+"+ str3);
        for (int i = 0; i < spRight; i++)
            System.out.print(" ");
    }
}
