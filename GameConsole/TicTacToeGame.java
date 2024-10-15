import java.util.Arrays;
import java.util.Scanner;
import java.util.InputMismatchException;

public class TicTacToeGame {
    static Scanner in = new Scanner(System.in);

    public static void playGame() {
        char[][] board = new char[3][3];
        for (char[] chars : board) {
            Arrays.fill(chars, ' ');
        }

        char player = 'X';
        boolean gameOver = false;

        while (!gameOver) {
            printBoard(board);
            System.out.println("Player " + player + " enter row and column (0-2):");
            int row = -1;
            int col = -1;

            try {
                row = in.nextInt();
                col = in.nextInt();
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter integers for row and column.");
                in.nextLine(); // Clear the invalid input
                continue; // Skip to the next iteration of the loop
            }

            // Validate input
            if (row >= 0 && row < 3 && col >= 0 && col < 3) {
                if (board[row][col] == ' ') {
                    board[row][col] = player;
                    gameOver = checkWin(board, player);

                    if (gameOver) {
                        System.out.println("Player " + player + " has won the game!!!");
                    } else if (isBoardFull(board)) {
                        System.out.println("The game is a draw!");
                        gameOver = true;
                    } else {
                        player = (player == 'X') ? 'O' : 'X';
                    }
                } else {
                    System.out.println("Invalid input. Cell already taken. Try again.");
                }
            } else {
                System.out.println("Invalid input. Enter row and column between 0 and 2.");
            }
        }
        printBoard(board);
    }

    private static void printBoard(char[][] board) {
        for (int row = 0; row < board.length; row++) {
            for (int col = 0; col < board[row].length; col++) {
                System.out.print(board[row][col]);
                if (col < board[row].length - 1)
                    System.out.print(" | ");
            }
            System.out.println();
            if (row < board.length - 1)
                System.out.println("---------");
        }
    }

    private static boolean checkWin(char[][] board, char player) {
        // Check rows
        for (int row = 0; row < board.length; row++) {
            if (board[row][0] == player && board[row][1] == player && board[row][2] == player)
                return true;
        }
        // Check columns
        for (int col = 0; col < board[0].length; col++) {
            if (board[0][col] == player && board[1][col] == player && board[2][col] == player)
                return true;
        }
        // Check diagonals
        if ((board[0][0] == player && board[1][1] == player && board[2][2] == player) ||
                (board[0][2] == player && board[1][1] == player && board[2][0] == player)) {
            return true;
        }

        return false;
    }

    private static boolean isBoardFull(char[][] board) {
        for (int row = 0; row < board.length; row++) {
            for (int col = 0; col < board[row].length; col++) {
                if (board[row][col] == ' ') {
                    return false;
                }
            }
        }
        return true;
    }
}