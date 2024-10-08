import java.util.Scanner;
import java.util.InputMismatchException;

class LogicMaster {
    static Scanner in = new Scanner(System.in);

    public static void main(String[] args) throws Exception {
        boolean flag = true;

        do {
            System.out.println();
            System.out.println("\t\t==================================");
            System.out.println("\t\t    Welcome to Logic Master!!!     ");
            System.out.println("\t\t==================================");
            System.out.println();
            System.out.println("Please choose an option:");
            System.out.println("----------------------------");
            System.out.println("1. Sign Up");
            System.out.println("2. Log In");
            System.out.println("3. Forgot Credentials");
            System.out.println("4. Exit");
            System.out.println("----------------------------");
            System.out.println();
            try {
                System.out.print("Enter your choice: ");
                int user = in.nextInt(); // Expecting integer input

                switch (user) {
                    case 1: {
                        Credentials.signUp();
                        break;
                    }
                    case 2: {
                        Credentials.login();
                        break;
                    }
                    case 3: {
                        Credentials.forgot();
                        break;
                    }
                    case 4: {
                        System.out.println();
                        System.out.println("=================================");
                        System.out.println("  Thank you for using Logic Master!");
                        System.out.println("  We hope to see you again soon.");
                        System.out.println("=================================");
                        flag = false; // Exit the loop and end the program
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
    }
}






