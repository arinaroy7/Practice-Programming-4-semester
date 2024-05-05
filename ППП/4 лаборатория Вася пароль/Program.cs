using System;

class Program {
    static void Main() {
        int n = 3; 
        char[] password = new char[n];
        GeneratePasswords(password, 0, 'a', 'c');
    }

    static void GeneratePasswords(char[] password, int position, char startChar, char endChar) {
        if (position == password.Length) {
            Console.WriteLine(password);
            return;
        }

        for (char c = startChar; c <= endChar; c++) {
            password[position] = c;
            GeneratePasswords(password, position + 1, c, endChar);
        }
    }
}
