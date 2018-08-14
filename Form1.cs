using System;
using System.Windows.Forms;

namespace MindGame
{
    public partial class Form1 : Form
    {
        public Button[] buttons = new Button[16];
        public int score = 0;
        public int[] positions = new int[16];
        public int moveCount = 0;
        public int currentSelected;
        public Button currentSelectedButton;
        System.Timers.Timer timer = new System.Timers.Timer();
        System.Timers.Timer startGameTimer = new System.Timers.Timer();
        Button currentButton;
        int[] randomNumbers = new int[16];

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }
        public Form1()
        {
            InitializeComponent();
            //this.PlayGame.Enabled = false;
            timer.Interval = 2000;
            startGameTimer.Interval = 3000;

            tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel1.RowStyles.Clear();
            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            randomNumbers = GetRandomNumbers(8);
            for (var i = 0; i < 16; i++)
            {
                buttons[i] = new Button();
                //if (i <= 7)
                //{
                //    buttons[i].Text = (i + 1).ToString();
                //    positions[i] = i + 1;
                //}
                //else
                //{
                //    buttons[i].Text = randomNumbers[i - 8].ToString();
                //    positions[i] = randomNumbers[i - 8];
                //}
                buttons[i].Text = randomNumbers[i].ToString();
                positions[i] = randomNumbers[i];

                buttons[i].Name = i.ToString();
                buttons[i].Visible = true;
                buttons[i].Click += PlayMove;
                buttons[i].Enabled = false;
                buttons[i].Height = 60;
                buttons[i].Width = 60;
                this.tableLayoutPanel1.Controls.Add(buttons[i]);
            }
            this.StartGame.Enabled = false;
            //this.PlayGame.Enabled = true;
            this.Controls.Add(tableLayoutPanel1);

            // startGameTimer.Stop();
            startGameTimer.Start();
            startGameTimer.Elapsed += ResetButtonText;
        }

        private void PlayMove(object sender, EventArgs e)
        {
            currentButton = (Button)sender;
            string buttonName = ((Button)sender).Name;
            if (moveCount % 2 == 0)
            {
                currentSelectedButton = (Button)sender;
                //currentSelected = int.Parse(buttonName);
                currentSelected = positions[int.Parse(buttonName)];
                currentSelectedButton.Text = currentSelected.ToString();
                currentSelectedButton.Enabled = false;
                currentSelectedButton.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                currentButton.Text = positions[int.Parse(currentButton.Name.ToString())].ToString();
                if (positions[int.Parse(buttonName)] == currentSelected)
                {
                    this.score = this.score + 2;
                    currentSelectedButton.Enabled = false;
                    ((Button)sender).Enabled = false;
                    ((Button)sender).Text = currentSelected.ToString();
                    ((Button)sender).BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    currentSelectedButton.Enabled = true;
                    // currentSelectedButton.Text = "";
                    timer.Stop();
                    timer.Start();
                    timer.Elapsed += ClearButtonText;
                }
                this.CurrentSelectedLabel.Text = "";
                currentSelectedButton.BackColor = DefaultBackColor;
            }
            moveCount++;
            this.MoveLabel.Text = "Moves:" + moveCount.ToString();
            this.ScoreLabel.Text = "Score: " + score.ToString();
            if (score == 16)
            {
                MessageBox.Show("Congratulations you win!! Total Moves: " + moveCount);
                this.Visible = false;
            }
        }

        private static int[] GetRandomNumbers(int n)
        {
            //int[] randomNumbersArray = new int[n];
            //for (int index = 0; index < n;)
            //{
            //    int number = random.Next(1, 9);
            //    if (!randomNumbersArray.Contains(number))
            //    {
            //        randomNumbersArray[index] = number;
            //        index++;
            //    }
            //}
            Random random = new Random();
            int[] randomNumbers = new int[16];
            for (int i = 1; i <= 16; i = i + 2)
            {
                randomNumbers[i - 1] = i;
                randomNumbers[i] = i;
            }
            int num;
            int temp;
            for (int i = 1; i <= 10; i++)
            {
                num = random.Next(1, 9);
                temp = randomNumbers[i - 1];
                randomNumbers[i - 1] = randomNumbers[num - 1 + 8];
                randomNumbers[num - 1 + 8] = temp;
            }
            return randomNumbers;
            // return randomNumbersArray;
        }
        //private void PlayGame_Click(object sender, EventArgs e)
        //{
        //    for (var i = 0; i < 16; i++)
        //    {
        //        buttons[i].Text = "";
        //        buttons[i].Enabled = true;
        //    }
        //    this.PlayGame.Enabled = false;
        //}

        public void ClearButtonText(Object source, System.Timers.ElapsedEventArgs e)
        {
            currentButton.Text = "";
            currentSelectedButton.Text = "";
            timer.Stop();
        }

        private void EndGame_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Moves: " + moveCount + "  Score: " + score);
            this.Visible = false;
        }

        public void ResetButtonText(Object source, System.Timers.ElapsedEventArgs e)
        {
            for (var i = 0; i < 16; i++)
            {
                buttons[i].Text = "";
                buttons[i].Enabled = true;
            }
            startGameTimer.Stop();
        }

    }
}