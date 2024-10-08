import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.InputMismatchException;
import java.util.Scanner;

class Credentials {
    static Scanner in = new Scanner(System.in);
    static String db_sid, db_pwd; // Changed to String for complex passwords
    static long db_contact;
    static boolean did_signUp;

    public static void signUp() throws Exception { // SignUp Page
        if (did_signUp) { // already registered
            System.out.println("Account already exists. Please try logging in or use 'Forgot Credentials' if needed.");
        } else {
            System.out.print("Enter your userID: ");
            db_sid = in.next();
            System.out.print("Enter your contact number: ");
            db_contact = in.nextLong();
            System.out.print("Set your password: ");
            db_pwd = in.next(); // Allows for complex passwords
            System.out.println();
            System.out.print("\t\tProcessing.");
            Thread.sleep(700);
            System.out.print(" .");
            Thread.sleep(700);
            System.out.print(" .");
            Thread.sleep(700);
            System.out.print(" .");
            System.out.println();
            System.out.println("\t\tLogin successful!");

            did_signUp = true;
        }
    }

    public static boolean didAccountExists() { // New or Old User
        return did_signUp;
    }

    public static void login() throws Exception {
        if (did_signUp) { // account exists
            System.out.print("Enter your userID: ");
            String sid = in.next();

            System.out.print("Set your password: ");
            String pwd = in.next(); // Changed to String

            if (sid.equals(db_sid) && pwd.equals((db_pwd))) {
                boolean flag = true;
                System.out.println("\t\tLogin Successful!");
                do {
                    System.out.println();
                    System.out.println("----------------------------");
                    System.out.println("1. Number Logic Programs");
                    System.out.println("2. Pattern Logic Programs");
                    System.out.println("3. Exit");
                    System.out.println("----------------------------");
                    System.out.println();
                    try {
                        System.out.print("Choose a category: ");
                        int category = in.nextInt(); // Expecting integer input

                        switch (category) {
                            case 1: {
                                NumberProgPage.numberProg();
                                break;
                            }
                            case 2: {
                                PatternProgPage.patternProg();
                                break;
                            }
                            case 3: {
                                flag = false;
                                break;
                            }
                            default: {
                                System.out.println();
                                System.out.println("Invalid choice. Please select a valid option.");
                            }
                        }
                    } catch (InputMismatchException e) {
                        System.out.println();
                        System.out.println("Error: Invalid input. Please enter a valid number.");
                        in.next(); // Clear the invalid input from the scanner buffer
                    }
                } while (flag);
                System.out.println();
                System.out.println("Exiting category selection.");
                System.out.print("\t\t<<<<<Redirecting to the homepage.");
                Thread.sleep(700);
                System.out.print(" .");
                Thread.sleep(700);
                System.out.print(" .");
                Thread.sleep(700);
                System.out.print(" .");
                Thread.sleep(1000);
                System.out.println();

            } else { // incorrect credentials
                System.out.println();
                System.out.println("\t\tLogin failed!!! Please check your credentials.");
            }
        } else { // account not exists
            System.out.println();
            System.out.println("No account found. Please sign up first before attempting to log in.");
        }
    }

    public static void forgot() throws Exception {
        if (did_signUp) { // account exists
            System.out.print("Enter your registered contact number: ");
            long user_contact = in.nextLong();

            if (user_contact == db_contact) {
                System.out.println();
                System.out.println("OTP to reset your credentials have been sent to your contact number!");
                int otp = (int) (Math.random() * 1000 + 1000);
                System.out.print("Enter the OTP to reset your credentials (" + otp + ") : "); // OTP verification
                int user_otp = in.nextInt();

                if (user_otp == otp) {
                    System.out.print("Enter your new userID: ");
                    db_sid = in.next();
                    System.out.print("Enter your contact number: ");
                    db_contact = in.nextLong();
                    System.out.print("Set your new password: ");
                    db_pwd = in.next(); // Allows for complex passwords
                    System.out.println();
                    System.out.print("\t\tUpdating.");
                    Thread.sleep(700);
                    System.out.print(" .");
                    Thread.sleep(700);
                    System.out.print(" .");
                    Thread.sleep(700);
                    System.out.print(" .");
                    System.out.println();
                    System.out.println("Your credentials have been successfully reset. You can now log in with your new details.");

                } else { // incorrect OTP
                    System.out.println();
                    System.out.println("Invalid OTP entered.");
                }
            } else { // incorrect contact number
                System.out.println();
                System.out.println("Entered contact number not found. Please check your details and try again, or sign up if you haven't registered.");
            }

        } else { // account not exists
            System.out.println();
            System.out.println("No account found. Please sign up first before attempting to log in.");
        }
    }
}