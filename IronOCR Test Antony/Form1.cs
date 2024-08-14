using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronOcr;

namespace IronOCR_Test_Antony
{
    public partial class Form1 : Form
    {
        public Bitmap _originalImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog to allow the user to select an image file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Set the filter to show only image files
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                // If the user selects a file and clicks OK
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string _path = openFileDialog.FileName;
                    // Load the selected image into the PictureBox
                    _originalImage = new Bitmap(openFileDialog.FileName);                    

                    // Optional: Adjust the PictureBox's SizeMode for better image display
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image= _originalImage;
                }
            }

        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            IronTesseract _ocr = new IronTesseract();
            var _text = _ocr.Read(_originalImage);
            richTextBox1.Text = _text.Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void buttonEmpty_Click(object sender, EventArgs e)
        {
            string[] lines = richTextBox1.Lines;

            string[] _nonEmptyLines = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

            richTextBox1.Lines = _nonEmptyLines;

        }
    }
}
