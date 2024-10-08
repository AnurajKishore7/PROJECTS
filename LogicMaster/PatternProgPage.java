import java.util.Scanner;
import java.util.InputMismatchException;

class PatternProgPage {
    static Scanner in = new Scanner(System.in);

    public static void patternProg() throws Exception {
        boolean flag = true;

        do {
            System.out.println();
            System.out.println("----------------------------");
            System.out.println("1. Square Fill Pattern");
            System.out.println("2. Number Increasing Pyramid Pattern");
            System.out.println("3. Triangle Star Pattern");
            System.out.println("4. Hour Glass Star Pattern");
            System.out.println("5. Zero to One Triangle Pattern");
            System.out.println("6. Exit");
            System.out.println("----------------------------");
            System.out.println();

            try {
                System.out.print("Choose a pattern program: ");
                int pattern = in.nextInt(); // Expecting integer input

                switch (pattern) {
                    case 1: // Square Fill
                        executePattern(1);
                        break;
                    case 2: // Number Increasing Pyramid
                        executePattern(2);
                        break;
                    case 3: // Triangle Star
                        executePattern(3);
                        break;
                    case 4: // Hour Glass
                        executePattern(4);
                        break;
                    case 5: // Zero to One Triangle
                        executePattern(5);
                        break;
                    case 6: // Exit
                        flag = false;
                        break;
                    default:
                        System.out.println("Invalid choice. Please select a valid option.");
                }
            } catch (InputMismatchException e) {
                System.out.println("Error: Invalid input. Please enter a valid number.");
                in.next(); // Clear the invalid input from the scanner buffer
            }
        } while (flag);

        exitPatternLogic();
    }

    private static void executePattern(int patternChoice) throws Exception {
        int n = userInput();
        Thread.sleep(1000);
        System.out.println();
        switch (patternChoice) {
            case 1:
                square(n);
                break;
            case 2:
                numberIncreasing(n);
                break;
            case 3:
                triangleStar(n);
                break;
            case 4:
                hourGlass(n);
                break;
            case 5:
                zeroOneTriangle(n);
                break;
        }
    }

    private static int userInput() {
        int n = -1;
        while (n <= 0) { // Ensure positive input
            System.out.print("Enter a positive number n: ");
            n = in.nextInt();
            if (n <= 0) {
                System.out.println("Please enter a positive integer.");
            }
        }
        return n;
    }

    private static void square(int n) { // Square Fill
        for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= n; col++) {
                System.out.print("* ");
            }
            System.out.println();
        }
    }

    private static void numberIncreasing(int n) { // Number Increasing Pyramid
        for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= row; col++) {
                System.out.print(col + " ");
            }
            System.out.println();
        }
    }

    private static void triangleStar(int n) { // Triangle Star Pattern
        for (int row = 1; row <= n; row++) {
            for (int col = 1; col <= n - row; col++) {
                System.out.print("  "); // Print spaces
            }
            for (int col = 1; col <= 2 * row - 1; col++) {
                System.out.print("* "); // Print stars
            }
            System.out.println();
        }
    }

    private static void hourGlass(int n) { // Hour Glass Star Pattern
        for (int row = 1; row <= 2 * n; row++) {
            int spaces = (row <= n) ? row - 1 : 2 * n - row;
            int stars = (row <= n) ? n + 1 - row : row - n;
            for (int col = 1; col <= spaces; col++) {
                System.out.print(" "); // Print spaces
            }
            for (int col = 1; col <= stars; col++) {
                System.out.print("* "); // Print stars
            }
            System.out.println();
        }
    }

    private static void zeroOneTriangle(int n) { // Zero to One Triangle Pattern
        int x = 1;
        for (int row = 0; row < n; row++) {
            for (int col = 0; col <= row; col++) {
                System.out.print(x + " ");
                x = 1 - x; // Toggle between 0 and 1
            }
            System.out.println();
        }
    }

    private static void exitPatternLogic() throws InterruptedException {
        System.out.println();
        System.out.println("Exiting pattern logic page.");
        System.out.print("\t\t<<<<<Redirecting to the category selection.");
        Thread.sleep(700);
        for (int i = 0; i < 3; i++) {
            System.out.print(" .");
            Thread.sleep(700);
        }
        System.out.println();
    }
}
