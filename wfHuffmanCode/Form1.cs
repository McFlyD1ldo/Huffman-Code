using AngleSharp.Text;
using clHuffmanCode;
using System.Text;

namespace wfHuffmanCode
{
    public partial class Form1 : Form
    {
        List<string> tree;
        List<byte> bytes;
        int lastAction = 3;
        string text;
        string filePath;
        string treePath;
        public Form1()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new("de-DE");
            this.Opacity = 0.95;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //load file into the text box. Use Latin1 Encoding to prevent errors mit הצü
                rtbInput.Text = Encoding.Latin1.GetString(File.ReadAllBytes(openFileDialog1.FileName));
                filePath = openFileDialog1.FileName;
            }
            //optionally load the tree file aswell 
            if (MessageBox.Show("Should the tree also be loaded?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    treePath = openFileDialog1.FileName;
                    tree = Encoding.Latin1.GetString(File.ReadAllBytes(treePath)).Split("\n").ToList();
                }
            }
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            //check if theres already been an input and compress this or tell the user to load a file or enter text
            if (rtbInput.Text != "")
            {
                Dictionary<string, string> dict = new();
                Encrypter encrypter = new();
                string input = rtbInput.Text;
                input = encrypter.CountChars(input);
                dict = encrypter.CreateCode();
                bytes = encrypter.CreateBinary(input, dict);
                tree = encrypter.WriteTree(dict);
                lastAction = 0;
                rtbInput.Text = Encoding.Latin1.GetString(bytes.ToArray());
            }
            else MessageBox.Show("Please enter some text first or load a text file using the \"load from file\" button");
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                //depending on the last action, open the dialogues to save the files/file
                //0 = compress
                if (lastAction == 0)
                {
                    saveFileDialog1.DefaultExt = ".huff";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK) File.WriteAllBytes(saveFileDialog1.FileName, bytes.ToArray());
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK) File.WriteAllLines(saveFileDialog1.FileName, tree);
                    treePath = saveFileDialog1.FileName;                    
                    FileInfo fi = new(filePath);
                    FileInfo fi2 = new(treePath);
                    MessageBox.Show($"File size before compression: {fi.Length} bytes\n" +
                                    $"File size after compression: {bytes.Count + fi2.Length} bytes\n" +
                                    $"Thats a compression of {Math.Round(100 - ((bytes.Count + fi2.Length) / (double)fi.Length) * 100,2)}%");
                }
                //1 = decompress
                else if (lastAction == 1)
                {
                    saveFileDialog1.DefaultExt = ".txt";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK) File.WriteAllText(saveFileDialog1.FileName, text);
                }
                //if there has not been any action, tell the user to perform one first
                else MessageBox.Show("Please compress or decompress a file first");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            Encrypter encrypter = new();
            if (tree != null) text = encrypter.Decode(treePath, filePath);
            else if (openFileDialog1.ShowDialog() == DialogResult.OK) encrypter.Decode(openFileDialog1.FileName, filePath);
            lastAction = 1;
            rtbInput.Text = text;
        }
    }
}