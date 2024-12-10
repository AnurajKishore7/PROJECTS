package BusReservation;

import java.sql.*;

public class BusDAO {
	
	public void displayBusInfo() throws SQLException {
	    String query = "SELECT * FROM bus;";
	    
	    try (Connection con = DbConnection.getConnection();
	         Statement st = con.createStatement();
	         ResultSet rs = st.executeQuery(query)) {
	        
	        while (rs.next()) {
	            System.out.println("Bus no: " + rs.getInt(1));
	            System.out.println("AC: " + (rs.getInt(2) == 0 ? "No" : "Yes"));
	            System.out.println("Capacity: " + rs.getInt(3));
	            System.out.println("-------------------------------------");
	        }
	    }
	}

	
	public int getCapacity(int id) throws SQLException {
	    String query = "SELECT capacity FROM bus WHERE id = ?";
	
	    try (Connection con = DbConnection.getConnection();
	         PreparedStatement pst = con.prepareStatement(query)) {
	        
	        pst.setInt(1, id); 
	        try (ResultSet rs = pst.executeQuery()) {
	            if (rs.next()) {
	                return rs.getInt(1);
	            } else {
	                throw new SQLException("No bus found with id: " + id);
	            }
	     	}
            }
	}


}
