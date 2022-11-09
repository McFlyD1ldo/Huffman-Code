using System;
using System.Data.SqlTypes;
using System.Text;

namespace clHuffmanCode
{
    public class Encrypter
    {
        public Dictionary<string, int> dic = new();

        //count the different characters in a string
        public string CountChars(string str)
        {
            str = str.Replace("\r", "");
            foreach (char c in str)
            {
                if (dic.ContainsKey(c.ToString()))
                {
                    dic[c.ToString()]++;
                }
                else
                {
                    dic.Add(c.ToString(), 1);
                }
            }
            SortDic();
            return str;
        }

        //sort the dictionary by the value
        private void SortDic()
        {
            dic = dic.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        }

        /// <summary>
        /// splits the dictionary into 4 other dictionaries
        /// </summary>
        /// <returns>a list of the created dictionaries</returns>
        private List<Dictionary<string, int>> SplitDic()
        {
            List<Dictionary<string, int>> returnList = new();
            returnList.Add(new());
            returnList.Add(new());
            returnList.Add(new());
            returnList.Add(new());
            int i = 0;
            if (dic.Count < 5)
            {
                returnList.Clear();
                returnList.Add(dic);
                return returnList;
            }
            foreach (var val in dic)
            {
                if (i % 4 == 0)
                {
                    returnList[0].Add(val.Key, val.Value);
                    //dic1.Add(val.Key, val.Value);
                }
                else if (i % 4 == 1)
                {
                    returnList[1].Add(val.Key, val.Value);
                   // dic2.Add(val.Key, val.Value);
                }
                else if (i % 4 == 2)
                {
                    returnList[2].Add(val.Key, val.Value);
                    //dic3.Add(val.Key, val.Value);
                }
                else
                {
                    returnList[3].Add(val.Key, val.Value);
                    //dic4.Add(val.Key, val.Value);
                }
                i++;
            }
            return returnList;
        }

        /// <summary>
        /// creates one branch for each dictionary in the list
        /// </summary>
        /// <returns>all the root nodes of the branches</returns>
        private IEnumerable<Node> CreateBranch()
        {
            List<Dictionary<string, int>> dicList = SplitDic();
            foreach (var dic in dicList)
            {
                var nodeStack = new Stack<Node>();
                var nodeQueue = new Queue<Node>();
                foreach (var item in dic)
                {
                    nodeQueue.Enqueue(new Node(item.Key, item.Value));
                }

                var left = nodeQueue.Dequeue();
                var right = nodeQueue.Dequeue();
                nodeStack.Push(new Node(left, right));
                while (nodeQueue.Count > 0)
                {
                    left = nodeStack.Pop();
                    right = nodeQueue.Dequeue();
                    var parent = new Node(left, right);
                    nodeStack.Push(parent);
                }

                yield return nodeStack.Pop();
            }

        }

        /// <summary>
        /// connects the branches with new nodes to complete the tree
        /// </summary>
        /// <param name="branches">List of branches/nodes</param>
        /// <returns>the final root node of the finished tree</returns>
        private Node CreateTree()
        {
            List<Node> branches = CreateBranch().ToList();
            if (branches.Count == 1) return branches.ElementAt(0);
            Node root = new(null, null);
            Node tempNode = new(branches.ElementAt(2), branches.ElementAt(3));
            root = new Node(new(branches.ElementAt(0), branches.ElementAt(1)), tempNode);
            return root;
        }

        /// <summary>
        /// generates the bit code for each letter in the tree
        /// </summary>
        /// <param name="root">root node of the tree</param>
        /// <returns>a dictionary containing the letters and their bit code as string</returns>
        public Dictionary<string, string> CreateCode()
        {
            Node root = CreateTree();
            var code = new Dictionary<string, string>();
            CreateCode(root, code, "");
            return code;
        }


        private void CreateCode(Node node, Dictionary<string, string> code, string s)
        {
            if (node.Left == null && node.Right == null)
            {
                code.Add(node.Character, s);
                return;
            }

            CreateCode(node.Left, code, s + "0");
            CreateCode(node.Right, code, s + "1");
        }

        /// <summary>
        /// writes the complete dictionary as a String List
        /// </summary>
        /// <param name="dict">the dictionary representing the tree</param>
        /// <returns>String List describing the tree</returns>
        public List<string> WriteTree(Dictionary<string, string> dict)
        {
            List<string> tree = new();
            {
                foreach (var item in dict)
                {
                    tree.Add(item.Key + item.Value);
                }
            }
            return tree;
        }

        /// <summary>
        /// replaces the characters in input with the values from our dictionary and converts those into bytes
        /// </summary>
        /// <param name="input">the text to be encoded</param>
        /// <param name="dict">dictionary representing our tree</param>
        /// <returns>The text data as List of bytes</returns>
        public List<byte> CreateBinary(string input, Dictionary<string, string> dict)
        {
            List<string> strBytes = new();
            List<byte> bytes = new();
            StringBuilder sb = new();
            string strbyte = "";
            foreach (char c in input) sb.Append(dict[c.ToString()]);
            strbyte = sb.ToString();
            for (int x = 0; x < sb.Length - (sb.Length % 8); x += 8)
            {
                strBytes.Add(strbyte.Substring(x, 8));
            }
            if (sb.Length % 8 > 0) strBytes.Add(strbyte.Substring(sb.Length - (sb.Length % 8)));
            foreach (string s in strBytes)
            {
                bytes.Add(Convert.ToByte(s, 2));
            }
            return bytes;
        }

        /// <summary>
        /// reads the tree values out of a stringlist
        /// </summary>
        /// <param name="tree">String List containing the tree values</param>
        /// <returns>dictionary representing the tree</returns>
        public Dictionary<string, string> ReadTree(string[] tree)
        {
            Dictionary<string, string> dict = new();
            for (int i = 0; i < tree.Length; i++)
            {
                if (tree[i] == "")
                {
                    dict.Add("\n", tree[i + 1]);
                    i++;
                }
                else dict.Add(tree[i].Substring(0, 1), tree[i].Substring(1));
            }
            return dict;
        }

        /// <summary>
        /// converts the bytes from a file into a string that represents the byte values
        /// </summary>
        /// <param name="path">filepath to read from</param>
        /// <returns>a string consisting of 0s and 1s eg. 0111101101010101110000</returns>
        public string ReadBinary(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            StringBuilder sb = new();
            foreach (byte b in bytes)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            string tmp = sb.ToString();
            return tmp;
        }

        /// <summary>
        /// replaces the binary values with the characters in our dictionary
        /// </summary>
        /// <param name="treePath">the path of the tree file</param>
        /// <param name="filePath">the path of our file to decode</param>
        /// <returns>the decoded text as string</returns>
        public string Decode(string treePath, string filePath)
        {
            Dictionary<string, string> dict = ReadTree(File.ReadAllLines(treePath));
            string input = ReadBinary(filePath);
            StringBuilder sb = new();
            string temp = "";
            foreach (char c in input)
            {
                temp += c;
                if (dict.ContainsValue(temp))
                {
                    sb.Append(dict.FirstOrDefault(x => x.Value == temp).Key);
                    temp = "";
                }
            }
            return sb.ToString();
        }
    }
}