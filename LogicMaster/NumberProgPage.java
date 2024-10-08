import java.util.InputMismatchException;
import java.util.Scanner;

class NumberProgPage {
    static Scanner in = new Scanner(System.in);

    public static void numberProg() throws Exception {
        boolean flag = true;

        do {
            System.out.println();
            System.out.println("----------------------------");
            System.out.println("1. Prime Number ?");
            System.out.println("2. Perfect Number ?");
            System.out.println("3. Palindrome Number ?");
            System.out.println("4. Neon Number ?");
            System.out.println("5. Spy Number ?");
            System.out.println("6. Exit");
            System.out.println("----------------------------");
            System.out.println();

            try {
                System.out.print("Choose a number logic program:");
                int number = in.nextInt(); // Expecting integer input

                switch (number) {
                    case 1: { // prime
                        int n = userInput();
                        System.out.println();
                        prime(n);
                        break;
                    }
                    case 2: { // perfect
                        int n = userInput();
                        System.out.println();
                        perfect(n);
                        break;
                    }
                    case 3: { // palindrome
                        int n = userInput();
                        System.out.println();
                        pali(n);
                        break;
                    }
                    case 4: { // neon
                        int n = userInput();
                        System.out.println();
                        neon(n);
                        break;
                    }
                    case 5: { // spy
                        int n = userInput();
                        System.out.println();
                        spy(n);
                        break;
                    }
                    case 6: {
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
        System.out.println("Exiting Number Logic Programs.");
    }

    private static int userInput() {
        System.out.print("Enter a number: ");
        return in.nextInt();
    }

    private static void prime(int n) {
        if (n <= 1) {
            System.out.println(n + " is not a prime number.");
            return;
        }
        for (int i = 2; i <= Math.sqrt(n); i++) {
            if (n % i == 0) {
                System.out.println(n + " is not a prime number.");
                return;
            }
        }
        System.out.println(n + " is a prime number.");
    }

    private static void perfect(int n) {
        int sum = 0;
        for (int i = 1; i < n; i++) {
            if (n % i == 0) {
                sum += i;
            }
        }
        if (sum == n) {
            System.out.println(n + " is a perfect number.");
        } else {
            System.out.println(n + " is not a perfect number.");
        }
    }

    private static void pali(int n) {
        int original = n, reverse = 0;
        while (n != 0) {
            int digit = n % 10;
            reverse = reverse * 10 + digit;
            n /= 10;
        }
        if (original == reverse) {
            System.out.println(original + " is a palindrome.");
        } else {
            System.out.println(original + " is not a palindrome.");
        }
    }

    private static void neon(int n) {
        int sum = 0, square = n * n;
        while (square != 0) {
            sum += square % 10;
            square /= 10;
        }
        if (sum == n) {
            System.out.println(n + " is a Neon number.");
        } else {
            System.out.println(n + " is not a Neon number.");
        }
    }

    private static void spy(int n) {
        int sum = 0, product = 1;
        while (n != 0) {
            int digit = n % 10;
            sum += digit;
            product *= digit;
            n /= 10;
        }
        if (sum == product) {
            System.out.println(n + " is a Spy number.");
        } else {
            System.out.println(n + " is not a Spy number.");
        }
    }
}