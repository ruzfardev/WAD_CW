-- Insert sample data into the Categories table
INSERT INTO Categories (CategoryName) VALUES ('Breakfast'), ('Lunch'), ('Dinner'), ('Desserts'), ('Beverages'), ('Appetizers'), ('Snacks'), ('Salads'), ('Soups'), ('Vegetarian');

-- Insert sample data into the Users table
INSERT INTO Users (FirstName, LastName, Email, Password) VALUES 
    ('John', 'Doe', 'john.doe@example.com', 'password1'),
    ('Jane', 'Doe', 'jane.doe@example.com', 'password2'),
    ('Bob', 'Smith', 'bob.smith@example.com', 'password3'),
    ('Alice', 'Johnson', 'alice.johnson@example.com', 'password4'),
    ('David', 'Lee', 'david.lee@example.com', 'password5');

-- Insert sample data into the Recipes table
INSERT INTO Recipes (RecipeName, Description, Ingredients, CookingTime, ServingSize, UserId, CategoryId) VALUES 
    ('Omelette', 'A simple breakfast dish made with eggs and cheese', '3 eggs, 1/2 cup shredded cheese, salt, pepper', 10, 1, 1, 1),
    ('Grilled Cheese Sandwich', 'A classic lunch sandwich made with bread and cheese', '2 slices of bread, 1/2 cup shredded cheese, butter', 5, 1, 2, 2),
    ('Spaghetti Bolognese', 'A hearty pasta dish with meat sauce', '1 lb ground beef, 1 can diced tomatoes, garlic, onion, spaghetti', 30, 4, 3, 3),
    ('Chocolate Cake', 'A rich and decadent dessert cake made with chocolate', '1 1/2 cups flour, 1 cup sugar, 3/4 cup cocoa powder, eggs, butter', 60, 8, 4, 4),
    ('Iced Coffee', 'A refreshing cold coffee drink', '1 cup cold coffee, 1/2 cup milk, sugar, ice', 5, 1, 1, 5),
    ('Guacamole', 'A delicious dip made with avocados and spices', '2 ripe avocados, 1/2 onion, garlic, lime juice, salt', 15, 4, 2, 6),
    ('Chips and Salsa', 'A popular Mexican appetizer', 'Tortilla chips, salsa', 5, 1, 3, 7),
    ('Hummus', 'A healthy dip made with chickpeas and spices', '1 can chickpeas, garlic, lemon juice, olive oil, salt', 10, 4, 4, 8),
    ('Tomato Soup', 'A comforting soup made with fresh tomatoes', '4-5 ripe tomatoes, onion, garlic, chicken broth, cream', 30, 4, 5, 9),
    ('Veggie Burger', 'A delicious vegetarian burger made with vegetables and grains', '1 can black beans, quinoa, breadcrumbs, onion, spices', 20, 4, 2, 10),
    ('Chicken Stir-Fry', 'A quick and easy Asian-inspired dish', '1 lb chicken breast, vegetables, soy sauce, rice', 20, 4, 1, 1),
	('Caesar Salad', 'A classic salad made with romaine lettuce, croutons, and Caesar dressing', '1 head romaine lettuce, croutons, Caesar dressing', 10, 2, 2, 7),
    ('Beef Stroganoff', 'A hearty dish made with beef and mushrooms', '1 lb beef sirloin, mushrooms, sour cream, egg noodles', 40, 4, 3, 8),
    ('Minestrone Soup', 'A flavorful Italian soup with vegetables and pasta', '1 can diced tomatoes, zucchini, carrots, celery, pasta', 30, 4, 4, 9),
    ('Grilled Salmon', 'A healthy and delicious fish dish', '1 lb salmon fillets, lemon, garlic, olive oil', 15, 4, 5, 10),
    ('Pesto Pasta', 'A flavorful pasta dish made with fresh basil pesto', '1 lb pasta, fresh basil, pine nuts, Parmesan cheese, olive oil', 20, 4, 2, 1),
    ('Tacos', 'A popular Mexican dish made with seasoned meat and toppings', '1 lb ground beef or chicken, taco shells, toppings (lettuce, cheese, tomato, etc.)', 20, 4, 3, 2),
    ('Margarita Pizza', 'A classic pizza made with fresh tomato sauce and mozzarella cheese', '1 pizza crust, tomato sauce, mozzarella cheese, basil', 15, 4, 4, 3),
    ('Brownies', 'A delicious chocolate dessert', '1 1/2 cups sugar, 3/4 cup flour, 3/4 cup cocoa powder, eggs, butter', 30, 12, 4, 4),
    ('Smoothie', 'A healthy drink made with fruit and yogurt', '1 cup frozen berries, 1 banana, yogurt, honey', 5, 1, 5, 5),
    ('Stuffed Mushrooms', 'A tasty appetizer made with mushrooms and cheese', '1 lb mushrooms, cream cheese, garlic, breadcrumbs', 25, 4, 2, 6);

-- Insert sample data into the Bookmarks table
INSERT INTO Bookmarks (UserId, RecipeId) VALUES
(1, 1),
(1, 3),
(2, 5),
(3, 7),
(3, 9),
(4, 11),
(5, 13),
(5, 15),
(2, 18),
(4, 20);
