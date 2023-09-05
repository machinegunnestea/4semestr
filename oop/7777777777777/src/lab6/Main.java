package lab6;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

import processor.TaskProcessor;


public class Main {

    public static void main(String[] args) {

        TaskProcessor tp = new TaskProcessor();
        System.out.println("--------------Первое задание-------------");
        tp.processFirstTask();
        System.out.println("\n--------------Второе задание-------------");
        tp.processSecondTask();
    }
}
