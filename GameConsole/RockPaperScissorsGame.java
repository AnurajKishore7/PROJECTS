import java.util.Scanner;

public class RockPaperScissorsGame {
    static Scanner sc = new Scanner(System.in);

    public static void rockPaperScissors() {
        System.out.println();
        System.out.println("\t\tWelcome to the Rock-Paper-Scissors Game!");
        System.out.println();
        System.out.println("The winner will be selected based on the best of 3 games.");
        System.out.println();

        int count = 1;
        int uwin = 0;
        int cwin = 0;

        while (count <= 3) {
            System.out.println("----------------------------");
            System.out.println("Please choose: \n1 for Rock, \n2 for Paper, \n3 for Scissors.");
            int guess = Game.userInput("Enter your choice: "); // Provide the prompt message here

            if (guess >= 1 && guess <= 3) {
                int comp = (int) (Math.random() * 3 + 1);
                System.out.println("Round :" + count);
                System.out.println("You chose: " + guess);
                System.out.println("The computer chose: " + comp);

                if (guess == comp) {
                    System.out.println("It's a tie! You both chose " + guess);
                } else if ((guess == 1 && comp == 3) || (guess == 2 && comp == 1) || (guess == 3 && comp == 2)) {
                    System.out.println("You win this round! Your choice beats Computer's choice.");
                    uwin++;
                } else {
                    System.out.println("You lose this round! Computer's choice beats Your choice.");
                    cwin++;
                }
            } else {
                System.out.println("Invalid input. Please enter 1 for Rock, 2 for Paper, or 3 for Scissors.");
                continue; // Re-prompt for valid input
            }

            count++;
        }

        System.out.println();
        System.out.print("\tResult of the game: ");
        if (uwin == cwin)
            System.out.println("It's a tie!");
        else if (uwin > cwin)
            System.out.println("You win the game!");
        else
            System.out.println("You lose the game!");
        System.out.println();
        System.out.println("Thank you for playing the Rock-Paper-Scissors Game!");

        replay();
    }

    public static void replay() {
        char choice = 'n'; // Initialize to 'n'
        while (true) {
            System.out.print("Would you like to play again? (y/n): ");
            try {
                choice = sc.next().charAt(0);
                if (choice == 'y' || choice == 'Y') {
                    rockPaperScissors(); // Restart the game
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
