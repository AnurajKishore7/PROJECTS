package BusReservation;

import java.util.Date;
import java.sql.*;


public class BookingDAO {

	public int getBookedCount(int busNo, Date date) throws SQLException {
		String query = "SELECT COUNT(passenger_name) FROM booking WHERE bus_no = ? AND travel_date = ?;";
		Connection con = DbConnection.getConnection();
		PreparedStatement pst = con.prepareStatement(query);
		java.sql.Date sqldate = new java.sql.Date(date.getTime());
		pst.setInt(1, busNo);
		pst.setDate(2, sqldate);
		ResultSet rst = pst.executeQuery();
		rst.next();
		
		return rst.getInt(1);
	}
	
	public Booking addBooking(Booking booking) throws SQLException {
	    String query = "INSERT INTO booking VALUES (?, ?, ?);";
	    Connection con = DbConnection.getConnection();
	    PreparedStatement pst = con.prepareStatement(query);
	    pst.setString(1, booking.passenger);
	    pst.setInt(2, booking.busNo);
	    java.sql.Date sqlDate = new java.sql.Date(booking.date.getTime());
	    pst.setDate(3, sqlDate);
	    
	    pst.executeUpdate();
	    return booking;
	}

}
