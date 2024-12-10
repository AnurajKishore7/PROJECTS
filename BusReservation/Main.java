package BusReservation;

import java.sql.SQLException;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        BusDAO busDao = new BusDAO();
        Scanner sc = new Scanner(System.in);

        try {
            // Display bus information
            busDao.displayBusInfo();

            int userOp;
            do {
                System.out.println("\n1. Book a seat\n2. Exit");
                System.out.print("Enter your choice: ");
                userOp = sc.nextInt();

                if (userOp == 1) {
                    handleBooking(sc);
                } else if (userOp != 2) {
                    System.out.println("Invalid option. Please try again.");
                }
            } while (userOp == 1);

            System.out.println("Thank you for visiting. Have a great day!");

        } catch (SQLException e) {
            System.err.println("Database error: Unable to process the request. Please contact support.");
            e.printStackTrace();
        } catch (Exception e) {
            System.err.println("An unexpected error occurred. Please try again later.");
            e.printStackTrace();
        } finally {
            sc.close();
            try {
                DbConnection.closeConnection(); 
            } catch (SQLException e) {
                System.err.println("Error while closing the database connection.");
                e.printStackTrace();
            }
        }
    }

    private static void handleBooking(Scanner sc) throws SQLException {
        Booking booking = new Booking(sc);

        if (booking.isAvailable()) {
            BookingDAO bookingDao = new BookingDAO();
            Booking confirmedBooking = bookingDao.addBooking(booking);

            System.out.println("\nBooking confirmed! Thank you for choosing our service.");
            // Display ticket details
            confirmedBooking.displayTicketDetails();
        } else {
            System.out.println("Sorry, the bus is fully booked. Please try another bus or select a different date.");
        }
    }
}
