import java.util.Scanner;

public class NumberGuessingGame {
    static Scanner sc = new Scanner(System.in);

    public static void numGuess() {
        System.out.println();
        System.out.println("\t\tWelcome to the Number Guessing Game! :)");
        System.out.println();
        System.out.println("I have selected a number between 1 and 10 (inclusive). Can you guess it?");
        System.out.println();

        int num = (int) (Math.random() * 10 + 1);
        int guess;
        int count = 0;

        do {
            guess = Game.userInput("Enter your guess: "); // Provide the prompt message here
            if (guess >= 1 && guess <= 10) {
                if (guess == num) {
                    System.out.println("Congratulations! You guessed the correct number!");
                    break;
                } else if (guess < num) {
                    System.out.println("Too low!");
                } else {
                    System.out.println("Too high!");
                }
                count++;
                System.out.println("\tYou've used " + count + " out of 3 attempts. Keep guessing!");
                System.out.println();
            } else {
                System.out.println("Invalid input. Please enter a valid number (1-10).");
            }
        } while (count < 3);

        if (count == 3) {
            System.out.println("Sorry, you've used all your attempts. The correct number was " + num);
        } else {
            System.out.println("Thank you for playing the Number Guessing Game!");
        }

        replay();
    }

    public static void replay() {
        char choice = 'n'; // Initialize to 'n'
        while (true) {
            System.out.println();
            System.out.print("Would you like to play again? (y/n): ");
            try {
                choice = sc.next().charAt(0);
                if (choice == 'y' || choice == 'Y') {
                    numGuess(); // Restart the game
                } else if (choice == 'n' || choice == 'N') {
                    System.out.println("Exiting the game. See you next time!");
                    break; // Exit the replay
                } else {
                    System.out.println("Invalid choice. Please enter 'y' or 'n'.");
                }
            } catch (Exception e) {
                System.out.println("An unexpected error occurred: " + e.getMessage());
                sc.nextLine(); // Clear the invalid input
            }
        }
    }
}
