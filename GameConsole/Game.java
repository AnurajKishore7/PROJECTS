import java.util.InputMismatchException;
import java.util.Scanner;

public class Game {
    static Scanner sc = new Scanner(System.in);

    public static void main(String[] args) {
        gameLoop();
    }

    public static void gameLoop() {
        int ui = -1; // Initialize to an invalid choice
        do {
            System.out.println();
            System.out.println("\t\tPlease select a game to play: \n1 for Tic Tac Toe Game, \n2 for Rock-Paper-Scissors Game, \n3 for Number Guessing Game, \n4 to Exit!!!");

            ui = userInput("Enter your choice: "); // Provide the prompt message here

            try {
                switch (ui) {
                    case 1:
                        TicTacToeGame.playGame();
                        break;
                    case 2:
                        RockPaperScissorsGame.rockPaperScissors();
                        break;
                    case 3:
                        NumberGuessingGame.numGuess();
                        break;
                    case 4:
                        System.out.println("\tExiting the game. See you next time!");
                        break; // Exit the loop and terminate the program
                    default:
                        System.out.println("Invalid selection. Please choose 1 for Number Guessing Game, 2 for Rock-Paper-Scissors Game, 3 for Tic Tac Toe Game, or 4 to Exit!!!");
                }
            } catch (Exception e) {
                System.out.println("An unexpected error occurred: " + e.getMessage());
            }
        } while (ui != 4);
    }

    public static int userInput(String prompt) {
        System.out.print(prompt);
        int input = -1; // Default to invalid input
        while (true) {
            try {
                input = sc.nextInt();
                sc.nextLine();  // Clear the buffer
                return input; // Return valid input
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter a number.");
                sc.nextLine();  // Clear the invalid input
            }
        }
    }
}
