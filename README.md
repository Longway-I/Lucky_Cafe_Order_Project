# Lucky_Cafe_Order_Project
# Lucky Cafe Order

A small cafe order program made with C# Windows Forms (one form only).

The worker enters the customer's name, chooses one drink, enters the quantity, and can select the student member discount. The program calculates the price, makes a lucky number for each drink, shows the result in a ListBox, and can save or load the order from a text file.

## Student Information

- **Full Name:** Your Full Name
- **Student ID:** Your Student ID
- **Class:** Your Class

## Features

- Customer name, drink type (Tea, Coffee, Juice), and quantity input
- Student Member discount (10% off)
- A random lucky number from 1 to 50 for each drink
- Order list shown in a ListBox
- Save the order to `orders.txt`
- Load the order from `orders.txt`
- Clear button to reset the form

## Prices

| Drink  | Price |
|--------|-------|
| Tea    | $1    |
| Coffee | $2    |
| Juice  | $3    |

## How to Use

1. Enter the **Customer Name**.
2. Choose one **Drink Type**.
3. Enter the **Quantity** (a number of 1 or more).
4. Check **Student Member (10% Off)** if the customer is a student.
5. Click **Calculate Order**. The order lines appear in the Order List, and the Total Price and Lucky Message appear at the bottom.
6. Click **Save to File** to save the order to `orders.txt`.
7. Click **Load from File** to show the saved orders in the Order List.
8. Click **Clear** to reset the form.

## Lucky Rule

If any lucky number is **7** or **17**, the message is **You got a Free Cookie!**. Otherwise the message is **No prize this time.**

## Example

Input: Customer Name `Ahmed Ali`, Drink `Tea`, Quantity `2`, Student Member checked.

Order List:

```
1) Ahmed Ali - Tea - Lucky: 17 - $1.00
2) Ahmed Ali - Tea - Lucky: 42 - $1.00
```

Total Price: **$1.80**

Lucky Message: **You got a Free Cookie!**

## Error Messages

- Empty Customer Name shows an error.
- Quantity that is not a number, or less than 1, shows an error.
- No drink selected shows an error.
- Save with an empty list shows "No order to save."
- Load without `orders.txt` shows "No file found."

## Technologies

- C#
- Windows Forms (.NET Framework)
- Visual Studio

## How to Run

1. Download or clone this repository.
2. Open the `.sln` file in Visual Studio.
3. Press **F5** to run the program.
