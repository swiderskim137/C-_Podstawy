namespace Gra0
{
    public partial class Form1 : Form
    {
        private int squareSize = 150;
        private int x = 100;
        private int y = 100;
        public static int width;
        public static int height;


        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            width = this.ClientSize.Width;
            height = this.ClientSize.Height;
            x = (width) / 2;
            y = (height) / 2;
            //this.Invalidate(false);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.FillRectangle(Brushes.Green, (this.ClientSize.Width - squareSize) / 2, (this.ClientSize.Height - squareSize) / 2, squareSize, squareSize);
            e.Graphics.FillEllipse(Brushes.Red, x - 10, y - 10, 20, 20);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    if (x > (this.ClientSize.Width - squareSize) / 2)
                        x -= 10;
                    break;
                case Keys.Right:
                    if (x < (this.ClientSize.Width + squareSize) / 2)
                        x += 10;
                    break;
                case Keys.Up:
                    if (y > (this.ClientSize.Height - squareSize) / 2)
                        y -= 10;
                    break;
                case Keys.Down:
                    if (y < (this.ClientSize.Height + squareSize) / 2)
                        y += 10;
                    break;
            }
            this.Invalidate();
            return base.ProcessCmdKey(ref msg, keyData);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            x = (width) / 2;
            y = (height) / 2;
            this.Invalidate();
        }
    }
}