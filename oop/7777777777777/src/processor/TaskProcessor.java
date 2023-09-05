package processor;

import java.lang.*;
import java.sql.*;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;


import static java.lang.System.out;

public class TaskProcessor {
    private String dbURL = "jdbc:sqlite:D:/lab5.db";;


    public TaskProcessor() {
        this.dbURL = dbURL;
    }

    private String fitString(String s, int length) {
        int sLength = s.length();

        if (sLength == length)
            return s;
        /*if (sLength < length)
            /*return StringUtils.leftPad(s, length);*/
        return s.substring(0, length);
    }

    private void printExecutionResults(ResultSet rs) throws SQLException {
        ResultSetMetaData rsmd = rs.getMetaData();
        int count = rsmd.getColumnCount();
        int separatorLength = 1;

        out.print("| ");
        for (int i = 1; i <= count; i++) {
            String columnName = rsmd.getColumnName(i);
            String fitName = fitString(columnName, 10);
            out.print(fitName + " | ");
            separatorLength += fitName.length() + 3;
        }

        /*String separator = StringUtils.repeat('-', separatorLength);*/
        /*out.println();
        out.println(separator);*/

        while (rs.next()) {
            out.print("| ");
            for (int i = 1; i <= count; i++) {
                String fitCell = fitString(rs.getObject(i).toString(), 10);
                out.print(fitCell + " | ");
            }
            out.println();
        }
        /*out.println(separator);*/
    }

    private void processStatement(Connection conn, String sql) throws SQLException {
        Statement st = conn.createStatement();
        ResultSet rs = st.executeQuery(sql);
        printExecutionResults(rs);
        rs.close();
        st.close();
    }

    private void processPreparedStatement(Connection conn, String sql, Object... objs) throws SQLException {
        PreparedStatement pst = conn.prepareStatement(sql);
        for (int i = 1; i <= pst.getParameterMetaData().getParameterCount(); i++)
            pst.setObject(i, objs[i - 1]);
        pst.execute();
        ResultSet rs = pst.getResultSet();
        if (rs != null) {
            printExecutionResults(rs);
            rs.close();
        }
        else
            out.println("Успешно задействовано следующее число записей: " + pst.getUpdateCount());
        pst.close();
    }

    public void processFirstTask() {
        try (Connection conn = DriverManager.getConnection(dbURL)) {

            //1.	Отдел кадров — данные о сотрудниках и в каких должностях они работают.
            String sql = "SELECT * FROM [отдел кадров]";
            out.println("1.	Отдел кадров — данные о сотрудниках и в каких должностях они работают.");
            processStatement(conn, sql);

            //2.	Покупка — информация о покупателях и купленных квартирах.
            sql = "SELECT * FROM покупка";
            out.println("\n2.	Покупка — информация о покупателях и купленных квартирах.");
            processStatement(conn, sql);

            //3.	Заключённые договора на сумму не менее 10 000 рублей.
            sql = "SELECT * FROM [договоры >= 10000 рублей]";
            out.println("\n3.	Заключённые договора на сумму не менее 10 000 рублей.");
            processStatement(conn, sql);

        } catch (Exception e) {
            out.println(e.getMessage());
        }
    }

    public void processSecondTask() {
        try (Connection conn = DriverManager.getConnection(dbURL)) {

            //1.	Отдел кадров — данные о сотрудниках и в каких должностях они работают.
            String sql = "SELECT сотрудники.*, должность.[Наименование должности] "
                    + "FROM сотрудники INNER JOIN "
                    + "		(SELECT [Код должности], [Наименование должности] "
                    + "	 	FROM (SELECT должности.[Код должности], должности.[Наименование должности] FROM должности)"
                    + "		) AS должность "
                    + "ON сотрудники.[Код должности] = должность.[Код должности]";
            out.println("1.	Отдел кадров — данные о сотрудниках и в каких должностях они работают.");
            processStatement(conn, sql);

            //2.	Покупка — информация о покупателях и купленных квартирах.
            sql = "SELECT клиенты.*, квартиры.[Адрес квартиры], квартиры.[Количество комнат], квартиры.[Наличие телефона],"
                    + "квартиры.[Раздельный санузел], квартиры.Площадь, квартиры.Цена, квартиры.[Дополнительная информация],"
                    + "квартиры.[Код вида квартиры], [виды квартир].Наименование, [виды квартир].Описание "
                    + "FROM клиенты INNER JOIN "
                    + "    (SELECT [Код покупателя], [Код вида квартиры], [Адрес квартиры], [Количество комнат],"
                    + "    [Наличие телефона], [Раздельный санузел], Площадь, Цена, [Дополнительная информация] "
                    + "    FROM договоры) AS квартиры "
                    + "ON клиенты.[Код клиента] = [Код покупателя] "
                    + "INNER JOIN [виды квартир] ON [Код вида квартиры] = [виды квартир].[Код вида]";
            out.println("\n2.	Покупка — информация о покупателях и купленных квартирах.");
            processStatement(conn, sql);

            //3.	Заключённые договора на сумму не менее 10 000 рублей.
            sql = "SELECT договоры.* "
                    + "FROM договоры "
                    + "WHERE договоры.[Сумма сделки] >= 10000";
            out.println("\n3.	Заключённые договора на сумму не менее 10 000 рублей.");
            processStatement(conn, sql);

            //4.	Параметрический запрос для отображения информации о сотрудниках, работающих на определенной должности.
            sql = "SELECT сотрудники.*, [Данные о должности].[Наименование должности] "
                    + "FROM сотрудники INNER JOIN "
                    + "        (SELECT [Код должности], [Наименование должности] "
                    + "        FROM должности "
                    + "        ) AS [Данные о должности] "
                    + "ON сотрудники.[Код должности] = [Данные о должности].[Код должности] "
                    + "WHERE сотрудники.[Код должности] = ?";
            out.println("\n4.	Параметрический запрос для отображения информации о сотрудниках, работающих на определенной должности.");
            processPreparedStatement(conn, sql, new Object[] {2});

            //5.	Параметрический запрос для отображения сведений об определенном покупателе.
            sql = "SELECT клиенты.* "
                    + "FROM клиенты INNER JOIN "
                    + "        (SELECT DISTINCT [Код покупателя] "
                    + "        FROM договоры "
                    + "        ) AS [покупатели] "
                    + "ON клиенты.[Код клиента] = покупатели.[Код покупателя] "
                    + "WHERE клиенты.[Код клиента] = ?";
            out.println("\n5.	Параметрический запрос для отображения сведений об определенном покупателе.");
            processPreparedStatement(conn, sql, new Object[] {14});

            //6.	Вычисление количества продаваемых квартир заданным продавцом.
            sql = "SELECT DistinctДоговоры.[Код продавца], Count(DistinctДоговоры.[Адрес квартиры]) AS [Количество] "
                    + "FROM (SELECT DISTINCT договоры.[Код продавца], договоры.[Адрес квартиры] FROM договоры) AS [DistinctДоговоры] "
                    + "GROUP BY DistinctДоговоры.[Код продавца] "
                    + "HAVING (((DistinctДоговоры.[Код продавца]) = ?))";
            out.println("\n6. Вычисление количества продаваемых квартир заданным продавцом.");
            processPreparedStatement(conn, sql, new Object[] {7});

            DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd.MM.yyyy");
            Object date = (dbURL.contains("sqlite")) ? dtf.format(LocalDate.of(1992, 5, 31)) : Date.valueOf("1992-05-31");

            //8.	Запрос на добавление нового клиента.
            sql = "INSERT INTO клиенты ([Код клиента], [ФИО], [Пол], [Дата рождения], [Адрес проживания], [Телефон], [Паспортные данные]) "
                    + "VALUES (?, ?, ?, ?, ?, ?, ?), (?, ?, ?, ?, ?, ?, ?)";
            out.println("\n8. Запрос на добавление нового покупателя.");
            processPreparedStatement(conn, sql, new Object[] {
                    21,
                    "Романов Вадим Максимович",
                    "Мужской",
                    date,
                    "ул. Пушкина, д. 23, кв. 1",
                    "+375 (29) 333-22-33",
                    "3245632125",
                    22,
                    "Денисов Роман Максимович",
                    "Мужской",
                    date,
                    "ул. Пушкина, д. 22, кв. 3",
                    "+375 (29) 222-33-22",
                    "3253563421"
            });

            //9.	Запрос на обновление данных о покупателе.
            sql = "UPDATE клиенты "
                    + "SET [ФИО] = ?, [Пол] = ?, [Дата рождения] = ?, [Адрес проживания] = ?, [Телефон] = ?, [Паспортные данные] = ? "
                    + "WHERE клиенты.[Код клиента] = ?";
            out.println("\n9. Запрос на обновление данных о покупателе.");
            processPreparedStatement(conn, sql, new Object[] {
                    "Романов Вадим Максимович",
                    "Мужской",
                    date,
                    "ул. Пушкина, д. 23, кв. 1",
                    "+375 (29) 333-22-33",
                    "3245632123",
                    22
            });

            //10.	Запрос на удаление данных о покупателе.
            sql = "DELETE FROM клиенты "
                    + "WHERE клиенты.[Код клиента] = ?";
            out.println("\n10. Запрос на удаление данных о покупателе.");
            processPreparedStatement(conn, sql, new Object[] {21});

        } catch (Exception e) {
            out.println(e.getMessage());
        }
    }
}
