public class Order {
    private Dish dish;
    private int quantity;
    private double totalAmount;

    public Order(Dish dish, int quantity) {
        this.dish = dish;
        this.quantity = quantity;
        this.totalAmount = quantity * dish.getPrice();
    }

    public void printOrderSummary() {
        System.out.println("Dish: " + dish.getName());
        System.out.println("Quantity: " + quantity);
        System.out.printf("Price per Serving: Rs.%.2f%n", dish.getPrice());
        System.out.printf("Total Amount: Rs.%.2f%n", totalAmount);
    }

    public double getTotalAmount() {
        return totalAmount;
    }
}
