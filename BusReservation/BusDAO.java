package BusReservation;

import java.sql.*;

public class BusDAO {
	
	public void displayBusInfo() throws SQLException {
		String query = "SELECT * FROM bus;";
		Connection con = DbConnection.getConnection();
		Statement st = con.createStatement();
		ResultSet rs = st.executeQuery(query);
		
		while (rs.next()) {
		    System.out.println("Bus no: " + rs.getInt(1));
		    System.out.println("AC: " + (rs.getInt(2) == 0 ? "No" : "Yes"));
		    System.out.println("Capacity: " + rs.getInt(3));
		    System.out.println("-------------------------------------");
		}
	}
	
	public int getCapactiy(int id) throws SQLException {
		String query = "SELECT capacity FROM bus WHERE id = " + id + ";";
		Connection con = DbConnection.getConnection();
		Statement st = con.createStatement();
		ResultSet rs = st.executeQuery(query);
		rs.next();
		
		return rs.getInt(1);
	}

}
