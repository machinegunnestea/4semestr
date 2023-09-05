import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class BaseHandler {
    public Connection getDbConnection() throws ClassNotFoundException, SQLException {
        return DriverManager.getConnection("jdbc:sqlite:identifier.sqlite");
    }
    public List<Gazetteer> getAll(){
        String select = "SELECT * FROM gazetteer ORDER BY population";
        List<Gazetteer> lst = new ArrayList<Gazetteer>();
        try {
            PreparedStatement prSt = getDbConnection().prepareStatement(select);
            ResultSet resultSet = prSt.executeQuery();
            while (resultSet.next()) {
                lst.add(new Gazetteer(
                        resultSet.getInt("id"),
                        resultSet.getFloat("square"),
                        resultSet.getFloat("population"),
                        resultSet.getString("continent"),
                        resultSet.getString("capital"),
                        resultSet.getString("country_name")
                ));
            }
            prSt.close();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }
        return lst;
    }
    public void deleteById(int id){
        String delete = "DELETE FROM gazetteer WHERE id=?";
        try {
            PreparedStatement prSt = getDbConnection().prepareStatement(delete);
            prSt.setInt(1, id);
            prSt.execute();
            prSt.close();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
    public void updateById(Gazetteer el){
        String update = "UPDATE gazetteer SET square=?, population=?, continent=?, capital=?, country_name=? where id =?";
        try {
            PreparedStatement prSt = getDbConnection().prepareStatement(update);
            prSt.setFloat(1,el.getSquare());
            prSt.setFloat(2,el.getPopulation());
            prSt.setString(3, el.getContinent());
            prSt.setString(4, el.getCapital());
            prSt.setString(5, el.getCountry_name());
            prSt.setInt(6, el.getId());
            prSt.executeUpdate();
            prSt.close();
        }catch (SQLException | ClassNotFoundException e){
            e.printStackTrace();
        }
    }
    public void insert(Gazetteer el){
        String insert = "INSERT INTO gazetteer (square, population, continent, capital, country_name) VALUES (?,?,?,?,?)";
        try {
            PreparedStatement prSt = getDbConnection().prepareStatement(insert);
            prSt.setFloat(1, el.getSquare());
            prSt.setFloat(2, el.getPopulation());
            prSt.setString(3, el.getContinent());
            prSt.setString(4, el.getCapital());
            prSt.setString(5, el.getCountry_name());
            prSt.executeUpdate();
            prSt.close();
        }catch (SQLException | ClassNotFoundException e){
            e.printStackTrace();
        }
    }
    public Gazetteer searchElementByCapital(String capital){
        String select = "SELECT * FROM gazetteer WHERE capital=?";
        Gazetteer el = new Gazetteer();
        try {
            PreparedStatement prSt = getDbConnection().prepareStatement(select);
            prSt.setString(1, capital);
            ResultSet resultSet = prSt.executeQuery();
            if(resultSet.next()) {
                el.setCapital(resultSet.getString("capital"));
                el.setId(resultSet.getInt("id"));
                el.setContinent(resultSet.getString("continent"));
                el.setCountry_name(resultSet.getString("country_name"));
                el.setSquare(resultSet.getFloat("square"));
                el.setPopulation(resultSet.getFloat("population"));
            }
            prSt.close();
        } catch (SQLException | ClassNotFoundException e) {
            e.printStackTrace();
        }
        return el;
    }

}
