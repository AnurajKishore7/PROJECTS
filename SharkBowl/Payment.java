import java.util.InputMismatchException;
import java.util.Random;
import java.util.Scanner;

public class Payment {
    private static Scanner sc = new Scanner(System.in);

    public boolean processPayment(double amount) {
        System.out.println("\nPayment Options:");
        System.out.println("1. Debit/Credit Card");
        System.out.println("2. UPI (GPay/PayTM)");
        System.out.println("3. Net Banking");
        System.out.print("Please choose your payment option: ");

        int paymentChoice = -1;
        while (true) {
            try {
                paymentChoice = sc.nextInt();
                if (paymentChoice < 1 || paymentChoice > 3) {
                    throw new IllegalArgumentException("Invalid payment option selected.");
                }
                break; // Exit loop if input is valid
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter a number.");
                sc.next(); // Clear invalid input
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }

        System.out.print("Please enter the amount to pay (Rs." + amount + "): ");
        double paymentAmount = -1;
        while (true) {
            try {
                paymentAmount = sc.nextDouble();
                if (paymentAmount != amount) {
                    throw new IllegalArgumentException("Error: Payment amount does not match the bill amount.");
                }
                break; // Exit loop if input is valid
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter a valid amount.");
                sc.next(); // Clear invalid input
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }

        System.out.println("Processing payment...");
        pause(1000);

        Random rand = new Random();
        int otp = 100000 + rand.nextInt(900000);
        System.out.println("An OTP has been sent to your registered mobile number.");
        // Display the generated OTP (for testing)
        System.out.println("Your OTP is: " + otp);
        System.out.print("Enter OTP: ");
        int enteredOtp = -1;
        while (true) {
            try {
                enteredOtp = sc.nextInt();
                break; // Exit loop if input is valid
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter the OTP.");
                sc.next(); // Clear invalid input
            }
        }

        if (enteredOtp == otp) {
            System.out.println("Payment successful.");
            return true;
        } else {
            System.out.println("Invalid OTP.");
            return false;
        }
    }

    private static void pause(int milliseconds) {
        try {
            Thread.sleep(milliseconds);
        } catch (InterruptedException e) {
            Thread.currentThread().interrupt();
        }
    }
}
