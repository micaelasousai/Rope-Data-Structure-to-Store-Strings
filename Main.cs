// Program description:
// This program represents the rope data structure used to store strings.
// Multiple methods to manipulate strings have been defined.

using System;

public static class A2
{
    public static void Main()
    {
        // Build rope structures
        Rope test1 = new Rope("hello_my_name_is_micaela_sousa");
        Rope test2 = new Rope("hello_bp");

        // Testing Rope constructor, Build and PrintRope
        test1.PrintRope();
        test2.PrintRope();

        // Test substring function
        string firstname = test1.Substring(17, 23);
        string hello = test1.Substring(0, 4);
        // Print strings obtained
        Console.WriteLine(hello);
        Console.WriteLine(firstname);

        // Print Rope Test 2
        test2.PrintRope();

        // Testing Reverse method
        test1.Reverse();
        test2.Reverse();
        // Print reversed ropes
        test1.PrintRope();
        test2.PrintRope();

        // Test substring function
        string prof = test2.Substring(6, 7);
        string str = test1.Substring(2, 4);
        // print substrings obtained
        Console.WriteLine(prof);
        Console.WriteLine(str);

        // Testing index of function 
        int ind_l = test1.IndexOf('l');
        int ind_a = test1.IndexOf('a');
        int ind_b = test2.IndexOf('b');
        // Print indecis obtained
        Console.WriteLine(ind_l);
        Console.WriteLine(ind_a);
        Console.WriteLine(ind_b);

        // Testing Reverse function
        // Testing for one node (reverses string stored inside)
        Rope toReverse = new Rope("reverse");
        toReverse.Reverse();
        toReverse.PrintRope();

        // Testing for multiple Node 
        Rope toReverse2 = new Rope("this_is_to_test_if_reverse_works_properly.");
        toReverse2.Reverse();
        toReverse2.PrintRope();

        // Test Rebalance
        //Rope testrebalance = new Rope("");
        //testrebalance.TestRebalance();

        // Test Concatenate
        //Rope testconcat = new Rope("");
        //testconcat.TestConcatenate();

        // Testing for CharAt
        Rope myRope = new Rope("Hello World!");
        Console.WriteLine($"character is: {myRope.CharAt(0)}");
        Console.WriteLine($"character is: {myRope.CharAt(4)}");
        Console.WriteLine($"character is: {myRope.CharAt(111)}");
        Console.WriteLine($"character is: {myRope.CharAt(-5)}");

        // Find Testing
        // Testing cases to find the substring in the string
        string Test1 = "World";
        string Test2 = "ello";
        string Test3 = "lo W";
        string Test4 = "elllo";
        string Test5 = "fff";
        // Find Test 1
        int findMyRope1 = myRope.Find(Test1);
        Console.WriteLine($"Index of the substring '{Test1}' in the string is: {findMyRope1}");
        // Find Test 2
        int findMyRope2 = myRope.Find(Test2);
        Console.WriteLine($"Index of the substring '{Test2}' in the string is: {findMyRope2}");
        // Find Test 3
        int findMyRope3 = myRope.Find(Test3);
        Console.WriteLine($"Index of the substring '{Test3}' in the string is: {findMyRope3}");
        // Find Test 4
        int findMyRope4 = myRope.Find(Test4);
        Console.WriteLine($"Index of the substring '{Test4}' in the string is: {findMyRope4}");
        // Find Test 5
        int findMyRope5 = myRope.Find(Test5);
        Console.WriteLine($"Index of the substring '{Test5}' in the string is: {findMyRope5}");

        // Length Testing
        // Testing to get the total length of the string
        // Length Test 1
        int totalLength1 = myRope.Length();
        Console.WriteLine($"The length of the string is: {totalLength1}");
        // Length Test 2
        int totalLength2 = anotherRope.Length();
        Console.WriteLine($"The length of the string is: {totalLength2}");

        //Testing ToString
        Rope anotherRope = new Rope("This is just a test case with lots of characters");
        Rope exampleNull = new Rope("");
        Console.WriteLine(myRope.ToString());
        Console.WriteLine(anotherRope.ToString());
        Console.WriteLine(exampleNull.ToString());


        /*//////////////////////// These are the test cases that we used ////////////////////////////////
//ropes used:
Rope originalRope = new Rope("Hello World!!!");
Rope anotherRope = new Rope("This is just a test case with lots of characters");
Rope toReverse2 = new Rope("this_is_to_test_if_reverse_works_properly.");
Rope exampleNull = new Rope("");






//test case 1
//testing the rope method, PrintRope, and Build method
anotherRope.PrintRope();


//test case 2
//testing the insert method at the beginning of the string
Rope toInsert1 = new Rope("_world!");
toInsert1.Insert("Hello", 0);
toInsert1.PrintRope();


//test case 3
//testing the insert method in the middle of the string
Rope toInsert2 = new Rope("Testing_is_important!");
toInsert2.Insert("very_", 10);
toInsert2.PrintRope();


//test case 4
//testing the insert method at the end of the string
Rope toInsert3 = new Rope("This_is_a_test_for_");
toInsert3.Insert("insert", 18);
toInsert3.PrintRope();


//test case 5
//testing the insert method with an invalid index (out of range)
Rope toInsert4 = new Rope("Computer");
toInsert3.Insert("Science", 10);
toInsert3.PrintRope();


//test case 6
//testing the insert method with an invalid index (negative index)
Rope toInsert5 = new Rope("Computer");
toInsert3.Insert("Science", -1);
toInsert3.PrintRope();


//test case 7
//testing the insert method with an invalid string (null)
Rope toInsert6 = new Rope("Computer");
toInsert6.Insert(null, 10);
toInsert6.PrintRope();


//test case 8
//testing the insert method with an invalid string (empty string)
Rope toInsert7 = new Rope("Computer");
toInsert7.Insert("", 10);
toInsert7.PrintRope();


//test case 9
//deleting the substring from the left subtree
originalRope.Delete(3, 9);
string originalRopeOutput = originalRope.ToString();
Console.WriteLine($"The result after deletion is {originalRopeOutput}");
originalRope.PrintRope();


//test case 10
//deleting the substring from the right subtree
originalRope.Delete(8, 10);
Console.WriteLine($"The result after deletion is {originalRopeOutput}");
originalRope.PrintRope();


//test case 11
//deleting the substring from the middle of the subtree
anotherRope.Delete(21, 26);
string anotherRopeOutput = anotherRope.ToString();
Console.WriteLine($"The result after deletion is: '{anotherRopeOutput}'");
anotherRope.PrintRope();


//test case 12
//deleting a substring at an invalid index
originalRope.Delete(7, 26);
//string originalRopeOutput = originalRope.ToString();
Console.WriteLine($"The result after deletion is {originalRopeOutput}");
originalRope.PrintRope();


//test case 13
//testing the Find method and returning the substring of an index in the string
string String1 = "test";
int findMyRope = anotherRope.Find(String1);
string printRope = anotherRope.ToString();
Console.WriteLine($"Index of the substring '{String1}' in the string of '{printRope}' is: {findMyRope}");


//test case 14
//testing the Find method and returning the substring of an invalid index
string String2 = "hi world";
int findMyRope2 = anotherRope.Find(String2);
string printRope2 = anotherRope.ToString();
Console.WriteLine($"Index of the substring '{String2}' in the string of '{printRope2}' is: {findMyRope2}");


//test case 15
//testing the Find method and returning the index of a null substring
string String3 = "";
int findMyRope3 = anotherRope.Find(String3);
string printRope3 = anotherRope.ToString();
Console.WriteLine($"Index of the substring '{String3}' in the string of '{printRope3}' is: {findMyRope3}");


//test case 16
//testing the CharAt method and checking its return of a character with a valid index
Console.WriteLine($"character is: {anotherRope.CharAt(8)}");


//test case 17
//testing the CharAt method and checking its return of a character at an index that is greater than the string’s length
Console.WriteLine($"character is: {anotherRope.CharAt(111)}");


//test case 18
//testing the CharAt method and checking its return of a character at a negative index
Console.WriteLine($"character is: {anotherRope.CharAt(-5)}");


//test case 19
//testing the IndexOf method and checking its return of the index of the first occurrence of character
int Index_s = anotherRope.IndexOf('s');
Console.WriteLine($"The index of character 's' is at index {Index_s}");


//test case 20
//testing the IndexOf method and checking its return of the index of a character that does not exist in the string
int Index_z = anotherRope.IndexOf('z');
Console.WriteLine($"The index of character 'z' is at index {Index_z}");


//test case 21
//Testing the Reverse method with multiple leafnode
toReverse2.Reverse();
toReverse2.PrintRope();


//test case 22
//testing the Length method of a string 
int totalLength = anotherRope.Length();
Console.WriteLine($"The length of the string is: {totalLength}");


//test case 23
//testing the Length method of a null string
int nullLength = exampleNull.Length();
Console.WriteLine($"The length of the string is: {nullLength}");


//test case 24
//Testing the ToString method of a string 
Console.WriteLine(anotherRope.ToString());


//test case 25
//testing the ToString method of a null string 
Console.WriteLine(exampleNull.ToString());


//test case 26
//testing the PrintRope method with 1 leafnode (string that is less than 10 char)
Rope smallTree = new Rope("Hello");
smallTree.PrintRope();


//test case 28
//testing the Split method for an index on the left side of the tree


//test case 29
//testing the Split method for an index on the right side of the tree


//test case 30
//testing the Split method for an index in the middle of the tree (i.e., in the middle of the leaf node)

*/
        //Testing Split Method 
        //for right part ind = 3
        //for left part ind = 1
        //Rope testSplit = new Rope("HelloThere");
        //testSplit.TestSplit();    }


    }
}
