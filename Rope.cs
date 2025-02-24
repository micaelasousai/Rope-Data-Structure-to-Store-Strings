// Rope Class

// Program description:
// This program represents the rope data structure used to store strings.
// Multiple methods to manipulate strings have been defined.

using System;

public class Rope
{
    private class Node
    {
        public string s; // only stored in a leaf node
        public int length; // augmented data, length of the string stored in the subtree
        public Node left, right;

        // Create constructor
        public Node(string s)
        {
            this.s = s;
            length = s.Length;
            left = null;
            right = null;
        }
    }
    // Create root node
    private Node root = new Node("*");  // Initialize root to new node with default value for s "*"
    
    // Set the maximum no. of characters to be put in leaf nodes
    static readonly int MAX_LEAF_LEN = 10;

    // Constructor for Rope
    // Create a balanced rope from a given string S.
    public Rope(string S)
    {
        root = Build(S, 0, S.Length - 1);
    }

    // Build function
    // Recursively build a balanced rope for S[i, j] 
    // return its root (part of the constructor). 
    private Node Build(string s, int i, int j)
    {
        // Check for conflicting range 
        // If j is smaller than i, return null
        if (i > j)
            return null;

        Node temp = new Node("*"); // * DEFAULT
        temp.left = temp.right = null;

        // If there are more than 10 characters in between i and j
        if (((j - i) + 1) > MAX_LEAF_LEN)
        {
            temp.s = "*";
            temp.length = (j - i) + 1;
            int mid = (int)Math.Floor((i + j) / 2.0);
            temp.left = Build(s, i, mid);
            temp.right = Build(s, mid + 1, j);
        }
        // Leaf node
        else
        {
            temp.length = (j - i) + 1; // +1 TO MAKE IT INCUSIVE
            string substr = "";
            for (int x = i; x <= j; x++)
                substr += s[x];
            temp.s = substr;
        }

        return temp;
    }

    // Concatenate function
    // Return the root of the rope constructed by concatenating two ropes with roots p and q
    private Node Concatenate(Node p, Node q)
    {
        // Create a new node
        Node temp = new Node("*");

        if (p != null && q != null)
        {
            temp.left = p;
            temp.right = q;
        }
        else
        {
            Console.WriteLine("ERROR: Could not concatenate the ropes. Make sure to pass valid rope structures.");
            return null;
        }

        // update length
        temp.length = p.length + q.length;

        // return the new root
        return temp;
    }

    public void Insert(string S, int i)
    {
        if (string.IsNullOrEmpty(S))
        {
            Console.WriteLine("ERROR: Please pass a valid string to be inserted.");
            return;
        }

        if (i < 0 || i > root.length)
        { // Ensure 'i' can be equal to 'root.length' to allow insertion at the end.
            Console.WriteLine("ERROR: Please provide a valid index to insert the string.");
            return;
        }

        // If inserting at the start or end, no need to split
        if (i == 0)
        {
            Rope toInsert = new Rope(S);
            root = Concatenate(toInsert.root, root);
        }
        else if (i == root.length)
        {
            Rope toInsert = new Rope(S);
            root = Concatenate(root, toInsert.root);
        }
        else
        {
            // Split the current rope at index 'i'
            Node rightPart = Split(root, i);

            // Create a new rope from the string to be inserted
            Rope toInsert = new Rope(S);

            // Concatenate the left part (already modified in place by Split), the new rope, and the right part
            Node temp = Concatenate(root, toInsert.root); // Note: 'root' here is now the left part after split
            root = Concatenate(temp, rightPart);
        }
    }

    
    // Substring function
    // Return the substring S[i, j]
    public string Substring(int i, int j)
    {
        // Implementing this function is straightforward
        // Traverse the rope to find the corresponding leaf nodes that cover the substring
        // Concatenate the substrings from those leaf nodes and return the result
        return SubstringHelper(root, i, j);
    }

    // Recursively finds and concatenates the substrings corresponding to the range [i, j]
    private string SubstringHelper(Node node, int i, int j)
    {

        // Process leaf node
        if (node.left == null && node.right == null)
        {
            string substr = "";
            for (int x = i; x <= j; x++)
                substr += node.s[x];
            return substr;
        }

        // Calculate the start index of the current node in the rope.
        int nodeStart = (node.left != null) ? node.left.length : 0;

        // Check if the desired substring [i, j] falls entirely within the left subtree of the current node.
        if (j < nodeStart)
            return SubstringHelper(node.left, i, j);
        // Check if the desired substring [i, j] falls entirely within the right subtree of the current node.
        else if (i >= nodeStart)
            // if (i >= nodeStart + node.s.Length)
            return SubstringHelper(node.right, i - nodeStart, j - nodeStart); // [0, 3]
        else
        {
            // If the desired substring [i, j] spans both the left and right subtrees of the current node,
            // recursively concatenate the substrings from both subtrees.
            string leftSub = SubstringHelper(node.left, i, nodeStart - 1);
            string rightSub = SubstringHelper(node.right, 0, j - nodeStart);
            // string rightSub = SubstringHelper(node.right, nodeStart, j); // [9, 12]
            return leftSub + rightSub;
        }

    }

    //ToString function
    //Return the string represented by the current rope (4 marks)
    public string ToString()
    {
        return ToString(root);
    }


    private string ToString(Node node)
    {
        if(node == null) //if node does not exist
        {
            Console.WriteLine("The string is empty");
            return string.Empty; //return an empty string
        }
        if(node.left == null && node.right == null) //to check if the node is a leaf node --> leaf node is where the substring is stored
        {
            return node.s; //if it's in the leaf node, return the substring
        }

        return ToString(node.left) + ToString(node.right); //returning the left substring and right substring
    }

    //Length function
    //it returns the length of the string 
    public int Length()
    {
        return Length(root);
    }

    private int Length(Node node)
    {
        if (node == null) //if the node is null, return the length to be 0
        {
            return 0;
        }
        if(node.left == null && node.right == null) //to check if the node is a leaf (where substring is stored), if it is the leaf, return the length
        {
            return node.length;
        }

        return node.length = Length(node.left) + Length(node.right); //adds the length of the left node and the right node
    }


    //CharAt function
    //return the character at index i (3 marks)
    public char CharAt(int i)
   {
       return CharAt(root, i);
   }


   private char CharAt(Node newNode, int i)
   {
       if (newNode == null)//if the node is null
        {
            return ' ';
        } 

       if (newNode.left == null) // to check if it has reached the left node. If it has not fully reached the left node, then we're still in the internal nodes
       {
           if (i < newNode.s.Length && i >= 0) //if the index is within the bounds of the string, checks error handling for negative index
            {
                return newNode.s[i]; //return the character in the string of the index given
            }
             //if the index is out of bounds
             else
            {
                Console.WriteLine("The index inputted is not within bounds");
                return ' ';
            }    
       }
       else
       {
           if (i < newNode.left.length)// if the character is on the left subtree
            {
               return CharAt(newNode.left, i); //recursively checks the left subtree
            }
           else //if the character is on the right subtree
           {
               return CharAt(newNode.right, i - newNode.left.length); //recursively check the right subtree
           }
       }
   } 
 

    // IndexOf function
    // Return the index of the first occurrence of character c
    // Search the leaf nodes until you find the char you are looking for, keep track of the indecis (keep adding 1 as traverse the tree, keep a counter)
    public int IndexOf(char c)
    {
        return IndexOf(root, c);
    }

    private int IndexOf(Node node, char c)
    {
        if (node == null)
        {
            return -1; // Character not found in the rope
        }

        // If node is leaf node, check its contents
        if (node.left == null && node.right == null)
        {
            for (int i = 0; i < node.s.Length; i++)
            {
                if (node.s[i] == c)
                    return i; // Character found in this leaf node
            }
        }
        else
        {
            int leftIndex = IndexOf(node.left, c);
            int rightIndex = IndexOf(node.right, c);

            // Compare indecis and return corresponding index
            // Check if character found to the left
            if (leftIndex >= 0)
            {
                return leftIndex;
            }
            // Check if character found to the right
            else if (rightIndex >= 0)
            {
                return rightIndex + node.left.length;
            }
            else
            {
                // Character not found
                return -1;
            }
        }
    
        return -1;
    }
    

    // Reverse function
    // Reverse the string represented by the current rope
    public void Reverse()
    {
        if (root == null)
        {
            return;
        }
    
        //Node p = root;
    
        Reverse(root);
    }
    
    private void Reverse(Node p)
    {
        if (p == null)
            return;
    
        // Leaf node: reverse string stored in node
        if (p.left == null && p.right == null)
        {
            string reversed = "";
            for (int i =  p.s.Length - 1; i >= 0; i--)
            {
                // reversed.Append(p.s[i]);
                reversed += p.s[i];
            }
            p.s = reversed;
        }
        else
        {
            // Nodes with children: swap left and right nodes
            Node temp = p.left;
            p.left = p.right;
            p.right = temp;
        }
            
        // Go to the left subtree
        Reverse(p.left);
    
        // Go to right subtree
        Reverse(p.right);
    }

// Split function
    private Node Split(Node p, int i)
    {
        // if node is null
        if (p == null)
        {
            return null;
        }

        // split index is within a leaf node's string.
        if (p.left == null && p.right == null)
        {
            if (i < p.s.Length)
            {
                
                Node rightPart = new Node(p.s.Substring(i));
                // Update the original node to reflect the left part of the split
                p.s = p.s.Substring(0, i);
                p.length = p.s.Length;
                // Since this is a leaf node being split, return the newly created right part
                return rightPart;
            }
            else
            {
                return null;
            }
        }

        // Determine if split index falls within the left subtree.
        int leftLength = p.left != null ? p.left.length : 0;
        if (i < leftLength)
        {
            Node splitRightSubtree = Split(p.left, i);
            if (splitRightSubtree != null)
            {
                Node newParent = new Node ("*");
                newParent.left = splitRightSubtree; // Assign the right part of the split as the left child of the new parent.
                newParent.right = p.right; // Keep the existing right subtree as the right child.
                p.right = null; // Detach the original right subtree from p, as it's now attached to newParent.
                Length(newParent); // Update the lengths of the newParent and its subtree.
                return newParent; 
            }
        }
        else if (i > leftLength)
        {
            // Split index is in the right subtree
            return Split(p.right, i - leftLength); // Adjust the index for the right subtree and continue splitting.
        }
        // Case where i == leftLength
        return p.right;
    }

    
    //creating a Find method 
    public int Find(Node node, string substring)
    {
        for (int i = 0; i <= node.length - substring.Length; i++) //it iterates the characters of the substring that's stored in the node
        {
            bool exist = true; //creating a boolean statement to check if the character exists
            for (int j = 0; j < substring.Length; j++) //checks if the substring length is greater than j
            {
                if (CharAt(i + j) != substring[j]) //using the CharAt method - it recursively traverse the tree to find the character and compares the character
                {
                    exist = false;
                    break;
                }
            }

            if (exist)
            {
                return i; // Found the substring starting at index i
            }
        }

        Console.WriteLine("The substring does not exist in the string.");
        return -1;
    }

    // Rebalance function
    // Rebalance the rope using the algorithm found on pages 1319-1320 of Boehm et al. 
    private Node Rebalance()
    {
            
        Node p = root;

        // Initialize a list
        // This list will represent the ranges of the fibonacci numbers
        Node[] balancedRope = new Node[20];

        // Call recursive Rebalance
        Rebalance(p, balancedRope);

        // Check one last time that rope rebalanced
        for (int i = 0; i < p.length; i++)
        {
            // if there are values not null values, concatenate them to the right
            if (balancedRope[i] != null)
            {
                // Find the next non-null node
                int j = i + 1;

                while (j < p.length && balancedRope[j] == null)
                {
                    j++;
                }

                // Check if non-null was found
                if (j < p.length)
                {
                    Node temp = Concatenate(balancedRope[j], balancedRope[i]);
                    balancedRope[i] = null;
                    balancedRope[j] = null;
                    InsertNode(temp, balancedRope); // Call InsertNode for temp as length has changed and might need to be stored in another index
                }
            }
        }

        bool ropeFound = false;
        int indexStored = 0;

        while (ropeFound == false)
        {
            if (balancedRope[indexStored] != null)
                ropeFound = true;
            else
                indexStored++;
        }

        p = balancedRope[indexStored];

        return p;

    }

    // Create private Rebalance takes one parameter p
    private void Rebalance(Node p, Node[] balancedRope)
    {
        // If the node is null, return
        if (p == null)
            return;
        
        // Process each leaf node and store them in the list
        if (p.left == null && p.right == null)
            InsertNode(p, balancedRope);

        // Traverse the rope
        Rebalance(p.left, balancedRope);
        Rebalance(p.right, balancedRope);
    }

    // Insert Function
    private void InsertNode(Node p, Node[] balancedRope)
    {
        int f0 = 1;
        int f1 = 2;
        int n = -1;

        // Check if length is equal to F0 
        if (p.length == f0)
        {
            n = 0;
        }
        // Check if length is equal to F1 
        else if (p.length == f1)
        {
            n = 1;
        }
        else if (p.length > 2)
        {
            int previous = f0; 
            int current = f1; 

            n = 1;

            bool indexFound = false;

            while (!indexFound)
            {
                int next = previous + current;

                // Check if length is less than or equal to current but less than next
                if (p.length >= current && p.length < next)
                {
                    indexFound = true; 
                    break; 
                }

                // Update Fibonacci numbers for the next iteration
                previous = current;
                current = next;

                n++;
            }
        }
        else
        {
            Console.WriteLine("ERROR: length of the rope stored is not valid.");
            return;
        }

        // Check index n 
        if (balancedRope[n] == null)
        {
            balancedRope[n] = p;
        }
         // Concatenate current node (p) to the right
        else
        {
            // Concatenate p to the node stored at index n
            Node temp = Concatenate(balancedRope[n], p);
            balancedRope[n] = null;     
            // Call InsertNode for temp 
            InsertNode(temp, balancedRope);
        }

        for (int i = 0; i < n; i++)
        {
            // if there are values before we get to the current node, concatenate them to the right
            if (balancedRope[i] != null)
            {
                // Find the next non-null node
                int j = i + 1;

                while(j <= n)
                {
                    if (balancedRope[j] != null)
                        break;
                    else
                        j++;
                }

                // Check if non-null was found
                if (j <= n)
                {
                    Node temp = Concatenate(balancedRope[i], balancedRope[j]);
                    balancedRope[i] = null;
                    balancedRope[j] = null;
                    InsertNode(temp, balancedRope); // Call InsertNode for temp 
                }
            }
        }

        return;
    }

        // Delete function
    // Delete the substring S[i, j] (5 marks)
    public void Delete(int i, int j)
    {
        if (i < 0 || j >= root.length) //if the indices to delete is out of bounds, the indices are invalid
        {
            Console.WriteLine("Invalid indices.");
            return;
        }
        else
        {
            root = Delete(root, i, j);
        }

    }

    private Node Delete(Node node, int i, int j)
    {
        if (node == null) //if the node is null, return null
        {
            return null;
        }

        if (node.left == null && node.right == null) // if the node is a leaf node --> where the substrings are
        { 
            if (j < node.s.Length) //if the range for deletion is within the bounds of the node of the string
            {
                string leftPart; //gets the left part before index i; (this is the left side that will be concatenated)
                if (i > 0)
                {
                    leftPart = node.s.Substring(0, i); 
                }
                else //returns empty string
                {
                    leftPart = "";
                }

                string rightPart;
                if (j < node.s.Length - 1) //gets the right part of the substring after index j (this is the right side that will be concatenated)
                {
                    rightPart = node.s.Substring(j + 1);
                }
                else
                {
                    rightPart = "";
                }
                node.s = leftPart + rightPart; //concatenates the leftPart and the rightPart of the string
                node.length = node.s.Length; //getting the new modified length
            }
            return node;
        }

        int leftLength;
        if (node.left != null) //if the length of the left subtree is not null
        {
            leftLength = node.left.length; //gets the total length of the substring on the left subtree
        }
        else // if left subtree is null, then return its length of 0
        {
            leftLength = 0;
        }

        if (j < leftLength) //the deletion is only on the left subtree
        { 
            node.left = Delete(node.left, i, j);
        }
        else if (i >= leftLength) //the deletion is only on the right subtree
        { 
            node.right = Delete(node.right, i - leftLength, j - leftLength);
        }
        else //the deletion is on both sides of the subtree (the middle of left and right)
        { 
            node.left = Delete(node.left, i, leftLength - 1);
            node.right = Delete(node.right, 0, j - leftLength);
        }

        
        Length(node); //update length

        return node;
    }

    // Print Rope function
    // Public Print
    // Print the augmented binary tree of the current rope
    // Calls Private Print to carry out the actual print
    public void PrintRope()
    {
        PrintRope(root, 0);
    }

    // Private Print
    private void PrintRope(Node root, int index)
    {
        if (root != null)
        {
            // Print the right subtree first
            PrintRope(root.right, index + 1);

            // Indent based on depth
            Console.Write(new string(' ', index * 4));

            // Print node details
            Console.WriteLine($"{root.s} [{root.length}]");

            // Print the left subtree
            PrintRope(root.left, index + 1);
        }
        else
        {
            Console.WriteLine("");
        }

        return;
    }

    // TESTING METHODS

    // Method to test Rebalance 
    public void TestRebalance()
    {
        // Test Rebalance
        Rope a = new Rope("a");
        Rope bc = new Rope("bc");
        Rope d = new Rope("d");
        Rope ef = new Rope("ef");

        // Create unbalanced tree
        d.root = Concatenate(d.root, ef.root);
        bc.root = Concatenate(bc.root, d.root);
        a.root = Concatenate(a.root, bc.root);

        a.root = a.Rebalance();
        a.PrintRope();
    }

    //  Method to Test Concatenate
    public void TestConcatenate()
    {
        // Create two ropes
        Rope left = new Rope("Hello_");
        Rope right = new Rope("World");

        // Create rope that will store the new combined ropes
        Rope concatenation = new Rope("");

        // Call function concatenate
        concatenation.root = Concatenate(left.root, right.root);

        // Print new rope
        concatenation.PrintRope();
    }
    
    //  Method to Test Split
    public void TestSplit()
    {
         Node hello = new Node("HelloThere");
         int ind = 1;
         Rope output = new Rope("");
         output.root = Split(hello, ind);
         output.PrintRope();
     }
    
}








