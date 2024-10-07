public enum Restaurant {
    ARK_MULTICUISINE(new Dish[]{
            new Dish("Butter Chicken with Naan", 349),
            new Dish("Grilled Paneer Tikka", 269),
            new Dish("Mediterranean Pasta", 319)
    }),
    SARAVANA_BHAVAN(new Dish[]{
            new Dish("Masala Dosa", 199),
            new Dish("Paneer Butter Masala", 299),
            new Dish("Veg Biryani", 249)
    }),
    OCEAN_DELIGHTS(new Dish[]{
            new Dish("Grilled Salmon", 999),
            new Dish("Lobster Thermidor", 1499),
            new Dish("Shrimp Scampi", 849)
    }),
    CHOP_CHOP_HOUSE(new Dish[]{
            new Dish("Kung Pao Chicken", 299),
            new Dish("Vegetable Spring Rolls", 249),
            new Dish("Chicken Fried Rice", 199)
    }),
    JUICE_BOX(new Dish[]{
            new Dish("Mango Smoothie", 149),
            new Dish("Orange Juice", 129),
            new Dish("Mixed Berry Shake", 99)
    });

    private final Dish[] dishes;

    Restaurant(Dish[] dishes) {
        this.dishes = dishes;
    }

    public Dish[] getDishes() {
        return dishes;
    }
}
