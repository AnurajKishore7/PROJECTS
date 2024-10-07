import java.util.InputMismatchException;
import java.util.Scanner;

public class Main {
    static Scanner sc = new Scanner(System.in);

    public static void main(String[] args) {
        double billAmount = 0;
        System.out.println();
        System.out.println("*********************************************************");
        System.out.println("\t\tWelcome to Shark Bowl!");
        System.out.println("\tYour ultimate destination for delicious meals!");
        System.out.println("*********************************************************");
        System.out.println();
        System.out.println("\tWe bring the ocean's finest cuisine right to your screen!");
        System.out.println("     Dive into our variety of restaurants and satisfy your cravings.");
        System.out.println();

        int ui = getRestaurantChoice();
        if (ui < 1 || ui > Restaurant.values().length) {
            System.out.println("Invalid Restaurant Selection");
            return;
        }

        Restaurant selectedRestaurant = Restaurant.values()[ui - 1];
        Dish[] menu = selectedRestaurant.getDishes();
        int dishChoice = getDishChoice(menu);
        if (dishChoice < 1 || dishChoice > menu.length) {
            System.out.println("Invalid Dish Selection");
            return;
        }

        Dish selectedDish = menu[dishChoice - 1];
        int quantity = getQuantity();
        Order order = new Order(selectedDish, quantity);
        order.printOrderSummary();

        Payment payment = new Payment();
        if (payment.processPayment(order.getTotalAmount())) {
            System.out.println("Order confirmed.");
            System.out.println("Thank you for choosing Shark Bowl.");
            System.out.println("Your food will be delivered to your address shortly.");
        } else {
            System.out.println("Payment failed.");
        }
    }

    private static int getRestaurantChoice() {
        System.out.println("Please choose a restaurant:");
        int index = 1;
        for (Restaurant restaurant : Restaurant.values()) {
            System.out.println(index++ + ". " + restaurant.name().replace('_', ' '));
        }
        System.out.print("Enter your choice: ");
        int choice = -1;
        while (true) {
            try {
                choice = sc.nextInt();
                if (choice < 1 || choice > Restaurant.values().length) {
                    throw new IllegalArgumentException("Invalid restaurant selection. Please choose a valid option.");
                }
                break; // Exit loop if input is valid
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter a number.");
                sc.next(); // Clear invalid input
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }
        return choice;
    }

    private static int getDishChoice(Dish[] menu) {
        System.out.println("Please choose a dish:");
        for (int i = 0; i < menu.length; i++) {
            System.out.printf("%d. %s - Rs.%.2f%n", (i + 1), menu[i].getName(), menu[i].getPrice());
        }
        System.out.print("Enter your choice: ");
        int choice = -1;
        while (true) {
            try {
                choice = sc.nextInt();
                if (choice < 1 || choice > menu.length) {
                    throw new IllegalArgumentException("Invalid dish selection. Please choose a valid option.");
                }
                break; // Exit loop if input is valid
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter a number.");
                sc.next(); // Clear invalid input
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }
        return choice;
    }

    private static int getQuantity() {
        System.out.print("Enter quantity: ");
        int quantity = -1;
        while (true) {
            try {
                quantity = sc.nextInt();
                if (quantity < 1) {
                    throw new IllegalArgumentException("Quantity must be at least 1.");
                }
                break; // Exit loop if input is valid
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter a number.");
                sc.next(); // Clear invalid input
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }
        return quantity;
    }
}
