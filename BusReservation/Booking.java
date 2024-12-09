package BusReservation;

import java.util.*;	//Date
import java.sql.SQLException;
import java.text.ParseException;
import java.text.SimpleDateFormat;

public class Booking {
	 
	String passenger;
	int busNo;
	Date date;
	
	Booking(Scanner sc){
		System.out.print("Enter name of passenger: ");
		passenger = sc.next();
		System.out.print("Enter bus no: ");
		busNo = sc.nextInt();
		System.out.print("Enter date of journey (dd-mm-yyyy): ");
		String dateInput = sc.next();
		SimpleDateFormat dateFormat = new SimpleDateFormat("dd-MM-yyyy");
		try {
			date = dateFormat.parse(dateInput);
		} catch (ParseException e) {
			e.printStackTrace();
		}
	}
	
	public boolean isAvailable() throws SQLException  {
		
		 BusDAO busDao = new BusDAO();
		 int capacity = busDao.getCapactiy(busNo);
		 
		 BookingDAO bookingDao = new BookingDAO();
		 int booked = bookingDao.getBookedCount(busNo, date);
		 
		 return booked < capacity;
	}	
	
	public void displayTicketDetails() {
	    System.out.println("------------ Ticket Details ------------");
	    System.out.println("Passenger Name: " + passenger);
	    System.out.println("Bus No: " + busNo);
	    System.out.println("Date of Journey: " + new SimpleDateFormat("dd-MM-yyyy").format(date));
	    System.out.println("----------------------------------------");
	}

	
}
