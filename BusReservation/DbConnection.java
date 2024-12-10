package BusReservation;

import java.sql.*;

public class DbConnection {

    private static final String URL = "jdbc:mysql://localhost:3306/bus_reservation";
    private static final String USERNAME = "root";
    private static final String PASSWORD = "password";

    private static Connection connection;

    // Get database connection
    public static Connection getConnection() throws SQLException {
        if (connection == null || connection.isClosed()) {
            connection = DriverManager.getConnection(URL, USERNAME, PASSWORD);
        }
        return connection;
    }

    // Close database connection
    public static void closeConnection() throws SQLException {
        if (connection != null && !connection.isClosed()) {
            connection.close();
            System.out.println("Database connection closed.");
        }
    }
}
