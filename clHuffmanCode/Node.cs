namespace clHuffmanCode
{
    public class Node
    {
        public string Character { get; set; }
        public int Frequency { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(string character, int frequency)
        {
            Character = character;
            Frequency = frequency;
        }

        public Node(Node left, Node right)
        {
            Left = left;
            Right = right;
        }
    }
}