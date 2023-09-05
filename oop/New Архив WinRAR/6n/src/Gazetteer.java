public class Gazetteer {
    private int id;
    private float square;
    private float population;
    private String continent;
    private String capital;
    private String country_name;

    public Gazetteer(int id, float square, float population, String continent, String capital, String country_name) {
        this.id = id;
        this.square = square;
        this.population = population;
        this.continent = continent;
        this.capital = capital;
        this.country_name = country_name;
    }

    public Gazetteer(){};

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public float getSquare() {
        return square;
    }

    public void setSquare(float square) {
        this.square = square;
    }

    public float getPopulation() {
        return population;
    }

    public void setPopulation(float population) {
        this.population = population;
    }

    public String getContinent() {
        return continent;
    }

    public void setContinent(String continent) {
        this.continent = continent;
    }

    public String getCapital() {
        return capital;
    }

    public void setCapital(String capital) {
        this.capital = capital;
    }

    public String getCountry_name() {
        return country_name;
    }

    public void setCountry_name(String country_name) {
        this.country_name = country_name;
    }
    @Override
    public String toString(){
        return id + " " +square+ " " + population+ " " +continent + " " +capital+ " "+ country_name;
    }
}
