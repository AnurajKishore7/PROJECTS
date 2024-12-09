package BusReservation;

import java.sql.SQLException;
import java.util.Scanner;


public class Main {

	public static void main(String[] args) throws SQLException {
		
		BusDAO busDao = new BusDAO();
		
		try {
			busDao.displayBusInfo();
			
			Scanner sc = new Scanner(System.in);
			int userOp = 1;
	
			do{
				System.out.println("1.Book a seat\n2.Exit");
				System.out.print("Enter your choice:");
				userOp = sc.nextInt();
				if(userOp == 1) {
					Booking booking = new Booking(sc);
					if (booking.isAvailable()) {
					    BookingDAO bookingDao = new BookingDAO();
					    Booking confirmedBooking = bookingDao.addBooking(booking);
					    System.out.println("Booking confirmed! Thank you for choosing our service.");
					    
					    // Display ticket details
					    confirmedBooking.displayTicketDetails();
					} else {
					    System.out.println("Sorry, the bus is fully booked. Please try another bus or select a different date.");
					}	
				}
					
			}while(userOp == 1);
			
			sc.close();
			System.out.println("Thank you for visiting. Have a great day!");
		}catch(SQLException e) {
			System.out.println("Database error: Unable to process the request. Please contact support.");
		    e.printStackTrace();
		}catch (Exception e) {
		    System.out.println("An unexpected error occurred. Please try again later.");
		    e.printStackTrace();
		}

	}

}
