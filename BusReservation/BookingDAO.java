package BusReservation;

import java.util.Date;
import java.sql.*;


public class BookingDAO {

	public int getBookedCount(int busNo, Date date) throws SQLException {
	    String query = "SELECT COUNT(passenger_name) FROM booking WHERE bus_no = ? AND travel_date = ?;";
	    
	    try (Connection con = DbConnection.getConnection();
	         PreparedStatement pst = con.prepareStatement(query)) {
	         
	        java.sql.Date sqlDate = new java.sql.Date(date.getTime());
	        pst.setInt(1, busNo);
	        pst.setDate(2, sqlDate);
	        
	        try (ResultSet rst = pst.executeQuery()) {
	            if (rst.next()) {
	                return rst.getInt(1); 
	            } else {
	                return 0;
	            }
	        }
	    }
	}

	
	public Booking addBooking(Booking booking) throws SQLException {
	    String query = "INSERT INTO booking (passenger_name, bus_no, travel_date) VALUES (?, ?, ?);";
	    
	    try (Connection con = DbConnection.getConnection();
	         PreparedStatement pst = con.prepareStatement(query)) {
	         
	        if (booking == null || booking.passenger == null || booking.date == null) {
	            throw new IllegalArgumentException("Invalid booking details provided.");
	        }
	        
	        pst.setString(1, booking.passenger);
	        pst.setInt(2, booking.busNo);
	        java.sql.Date sqlDate = new java.sql.Date(booking.date.getTime());
	        pst.setDate(3, sqlDate);
	        
	        int rowsAffected = pst.executeUpdate();
	        
	        if (rowsAffected > 0) {
	            return booking;
	        } else {
	            throw new SQLException("Failed to add booking.");
	        }
	    }
	}


}
