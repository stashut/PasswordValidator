# Password Validator using Regular Expressions
This C# code validate passwords based on specific requirements using regular expressions. 

## How it works
The code reads the contents of the passwords.txt file and iterates through each line.

For each line, the IsValidPassword function is called, which uses regular expressions to parse the requirement and validate the password.

The regular expression (\w)\s+(\d+)-(\d+) captures the required character, minimum count, and maximum count from the requirement part.

The code then counts the occurrences of the required character in the password and checks if the count falls within the specified range.

If the password meets the requirements, the IsValidPassword function returns true, and the password along with the character count is printed.

At the end, the total number of valid passwords is displayed.
