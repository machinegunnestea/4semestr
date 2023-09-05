import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        menu();
    }

    public static void menu(){
        boolean exit = false;
        while (!exit){
            Scanner scan = new Scanner(System.in);
            try {
                System.out.println("1.Show data");
                System.out.println("2.Search");
                System.out.println("3.Add");
                System.out.println("4.Delete by id");
                System.out.println("5.Edit by id");
                System.out.println("6.Close");
                int userChoice = scan.nextInt();
                switch (userChoice) {
                    case 1 -> showElements();
                    case 2 -> searchElement();
                    case 3 -> addElement();
                    case 4 -> delete();
                    case 5 -> updateElement();
                    case 6 -> exit = true;
                }
            } catch (Exception e) {
                System.out.println("Incorrect.");
            }
        }
    }
    public static void searchElement(){
        System.out.println("Choose capital:");
        System.out.println(new BaseHandler().searchElementByCapital(new Scanner(System.in).nextLine()).toString());
    }
    public static void showElements(){
        List<Gazetteer> lst = new BaseHandler().getAll();
        System.out.println("===================================");
        lst.forEach(x -> System.out.println(x.toString()));
        System.out.println("===================================");
    }
    public static void addElement(){
        Gazetteer el = new Gazetteer();

        System.out.println("Square:");
        el.setSquare(Float.parseFloat(new Scanner(System.in).nextLine()));

        System.out.println("Population:");
        el.setPopulation(Float.parseFloat(new Scanner(System.in).nextLine()));

        System.out.println("Continent:");
        el.setContinent(new Scanner(System.in).nextLine());

        System.out.println("Capital:");
        el.setCapital(new Scanner(System.in).nextLine());

        System.out.println("Country:");
        el.setCountry_name(new Scanner(System.in).nextLine());

        new BaseHandler().insert(el);
    }
    public static void updateElement(){
        Gazetteer ch = new Gazetteer();

        System.out.println("Enter id:");
        ch.setId(new Scanner(System.in).nextInt());

        System.out.println("Square:");
        ch.setSquare(Float.parseFloat(new Scanner(System.in).nextLine()));

        System.out.println("Population:");
        ch.setPopulation(Float.parseFloat(new Scanner(System.in).nextLine()));

        System.out.println("Continent:");
        ch.setContinent(new Scanner(System.in).nextLine());

        System.out.println("Capital:");
        ch.setCapital(new Scanner(System.in).nextLine());

        System.out.println("Country:");
        ch.setCountry_name(new Scanner(System.in).nextLine());

        new BaseHandler().updateById(ch);
    }
    public static void delete(){
        System.out.println("Enter id:");
        new BaseHandler().deleteById(new Scanner(System.in).nextInt());
    }
}
